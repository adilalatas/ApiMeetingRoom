import React, { useState, useEffect } from 'react';
import { Container } from 'react-bootstrap';
import MeetingRoomService from "../../services/MeetingRoomService.js"
import MeetingService from "../../services/MeetingService.js"
import Meetingroom from './meetingroom.jsx';
import '../../assest/css/anasayfa.css';
import RoomPopup from './RoomPopup.jsx';


function Anasayfa() {

    const meetingRoomService = new MeetingRoomService();
    const meetingService = new MeetingService();
    const [meetingRooms, setMeetingRooms] = useState([]);
    const [meetings, setMeetings] = useState([]);
    const [currentTime, setCurrentTime] = useState(formatCurrentTime(new Date()));
    const [activeMeeting, setActiveMeeting] = useState([]);
    const [roomandMeeting, setRoomandMeeting] = useState([]);
    const [selectRoom, setSelectRoom] = useState({});
    const [roomModalShow, setRoomModalShow] = useState(false);
    const [currentDay, setCurrentDay]=useState(formatCurrentDay(new Date()));
    const [control, setControl] = useState(0);



    useEffect(() => {
        const fetchData = async () => {
            let meetingdata=await meetingService.getMeeting();
            let meetinroomgdata=await meetingRoomService.getMeetingRooms();

            setMeetingRooms(meetinroomgdata.data);
            setMeetings(meetingdata.data);
        };
        fetchData();
    }, [control]);

    function cont(){
        setControl(prevValue => prevValue + 1);
    }


    useEffect(() => {
        const intervalId = setInterval(() => {
            let now = new Date();
            const formattedCurrentTime = formatCurrentTime(now);
            setCurrentTime(formattedCurrentTime);
            const timePart = formattedCurrentTime.split("T")[0];
            if(timePart!==currentDay){
                setCurrentDay(timePart);
            }
        }, 1000);
        return () => clearInterval(intervalId);
    }, [currentTime]);

    useEffect(() => {
        const updatedMeetingRooms = meetingRooms.map(meetingroom => {
            let cont = false;
            if((meetings.length!==0)&&(meetings!==undefined)){
                meetings.forEach(meeting => {
                    if (meetingroom.id === meeting.roomId) {
                        if (currentTime >= meeting.startDate && currentTime < meeting.endDate) {
                            cont = true;
                        }
                    }
                });
            }
            return { ...meetingroom, active: cont };

          
        });
        setMeetingRooms(updatedMeetingRooms);
        const updatedActiveMeetings = meetings.filter(meeting => {
            return currentTime >= meeting.startDate && currentTime < meeting.endDate;
        });
        setActiveMeeting(updatedActiveMeetings);
    }, [currentTime, meetings]);


    useEffect(() => {
        const RoomandMeetings = meetingRooms.map(room => {
            const activemeeting = activeMeeting.find(meet => room.id === meet.roomId);
            return { ...room, activemeeting };
        });
        setRoomandMeeting(RoomandMeetings);
    }, [activeMeeting]);

    useEffect(() => {
        if (selectRoom.room !== undefined) {
            let selectroom = roomandMeeting.find(room => selectRoom.room.id === room.id);
            setSelectRoom({ room:selectroom});
        }

    }, [roomandMeeting]);

    function SelectRoom(room) {
        let selectmeeting = meetings.filter(meet => room.id === meet.roomId && meet.startDate.split("T")[0] === currentDay);
        selectmeeting.sort((a, b) => new Date(a.startDate) - new Date(b.startDate));
        setSelectRoom({ room, selectmeeting });
        setRoomModalShow(true);
    }

    function formatCurrentTime(date) {
        const year = date.getFullYear();
        const month = ("0" + (date.getMonth() + 1)).slice(-2);
        const day = ("0" + date.getDate()).slice(-2);
        const hours = ("0" + date.getHours()).slice(-2);
        const minutes = ("0" + date.getMinutes()).slice(-2);
        return `${year}-${month}-${day}T${hours}:${minutes}:00`;
    }

    function formatCurrentDay(date) {
        const year = date.getFullYear();
        const month = ("0" + (date.getMonth() + 1)).slice(-2);
        const day = ("0" + date.getDate()).slice(-2);
        return `${year}-${month}-${day}`;
    }

    useEffect(() => {
        if (selectRoom.room !== undefined) {
            const selectmeeting = meetings.filter(meet =>
                
                selectRoom.room.id === meet.roomId && meet.startDate.split("T")[0] === currentDay
            );
            selectmeeting.sort((a, b) => new Date(a.startDate) - new Date(b.startDate));
            setSelectRoom(prevState => ({ ...prevState, selectmeeting }));
        }
    }, [currentDay, meetings, selectRoom.room, control]);
    return (
        <Container fluid className='anasayfa'>
           

            <Meetingroom Meetingrooms={roomandMeeting} selectroom={SelectRoom} />
            {roomModalShow && (
                <RoomPopup
                    show={roomModalShow} control={cont} selectroom={selectRoom} rooms={roomandMeeting} time={currentTime} onHide={() => setRoomModalShow(false)}
                />
            )}



        </Container>
    );
}

export default Anasayfa;