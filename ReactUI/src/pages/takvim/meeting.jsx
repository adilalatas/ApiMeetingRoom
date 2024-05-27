import React, { useEffect, useState } from 'react';
import { Card, Col, Row } from 'react-bootstrap';
import MeetingRoomService from "../../services/MeetingRoomService.js"
import MeetingService from "../../services/MeetingService.js";
import trMessages from "devextreme/localization/messages/tr.json";
import { locale, loadMessages } from "devextreme/localization";
import { Editing, Scheduler } from 'devextreme-react/scheduler';
import ToplantiEkleModal from '../toplanti/toplantiekle.jsx';
import ToplantiGuncelleModal from '../toplanti/toplantiguncelle.jsx';
import Swal from 'sweetalert2';
import AppointmentTooltip from './AppointmentTooptip.jsx';

export default function Meeting() {
    const meetingService = new MeetingService();
    const meetingRoomService = new MeetingRoomService();
    const [meetingRooms, setMeetingRooms] = useState([]);
    const [meetings, setMeetings] = useState([]);
    const [data, setData] = useState([]);
    const [ekleModalShow, setEkleModalShow] = useState(false);
    const [control, setControl] = useState(0);
    const [startDate, setStartDate] = useState();
    const [endDate, setEndDate] = useState();
    const [guncelleModalShow, setGuncelleModalShow] = useState(false);
    const [guncelmeeting, setGuncelMeeting] = useState();

    useEffect(() => {
        loadMessages(trMessages);
        locale(navigator.language);

    }, [])

    useEffect(() => {


        const fetchData = async () => {

            let meetingdata = await meetingService.getMeeting();
            let meetinroomgdata = await meetingRoomService.getMeetingRooms();

            setMeetings(meetingdata.data);
            setMeetingRooms(meetinroomgdata.data);
        };
        fetchData();
    }, [control])

    useEffect(() => {
        if (meetings.length > 0) {
            const usermeetings = meetings.map(meeting => {
                return { text: meeting.title, startDate: meeting.startDate, endDate: meeting.endDate, description: meeting.content, id: meeting.id, roomId: meeting.roomId, roomName: meeting.roomName };
            })
            setData(usermeetings);

        }
    }, [meetings, control])

    async function toplantiEkle(newmeeting) {
        let conts = await meetingService.addMeeting(newmeeting);
        if (conts) {
            setEkleModalShow(false);
            cont();

        }
    }
    function toplantiDüzenle(meet) {
        setGuncelleModalShow(true);
        setGuncelMeeting(meet);
    }

    async function toplatiGuncelle(meet) {
        let conts = await meetingService.updateMeeting(meet);
        if (conts) {
            setGuncelleModalShow(false);
            cont();
        }
    }

    async function toplantiSil(id) {
        Swal.fire({
            text: "Toplantı Silinecektir. Onaylıyor musun?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Sil",
            cancelButtonText: "İptal"
        }).then((result) => {
            if (result.isConfirmed) {
                let isdeleted = meetingService.deleteMeeting(id);
                if (isdeleted) {
                    cont();
                    setGuncelleModalShow(false);
                    Swal.fire({
                        title: "Silindi!",
                        text: "Toplantınız başarı ile silinmiştir.",
                        icon: "success",
                        confirmButtonText: "Tamam"
                    });
                }
            }
        });
    }
    function cont() {
        setControl(prevValue => prevValue + 1);
    }

    const onAppointmentFormOpening = (e) => {
        if (e.appointmentData.text === undefined) {
            setEkleModalShow(true);
            setStartDate(e.appointmentData.startDate);
            setEndDate(e.appointmentData.endDate);

        }
        else {
            const uppmeet = meetings.find(meet => e.appointmentData.id === meet.id);
            let usecont = meetingService.getUserMeetingCont(uppmeet);
            if (usecont) {
                toplantiDüzenle(uppmeet);
            }
            else {
                Swal.fire({
                    icon: 'error',
                    title: "Yalnızca Size Ait Olan Toplantıları Güncelleyebilirsiniz",
                    showConfirmButton: false,
                    timer: 1500
                });
            }
        }
        e.cancel = true;
    };
//saat düzenlemesi yapılacak
    return (
        <Row>
            <Col>
                <Card className='meeting mb-2'>
                    <Card.Body className='p-5 text-center'>
                        <h1>Takvim</h1>
                        <Scheduler
                            dataSource={data}
                            views={['day', 'week', 'month']}
                            defaultCurrentView="month"
                            defaultCurrentDate={new Date()}
                            startDayHour={8}
                            endDayHour={18}
                            height={600}
                            onAppointmentClick={() => { }}
                            appointmentPopupTemplate={() => { }}
                            onAppointmentFormOpening={onAppointmentFormOpening}
                            appointmentTooltipComponent={AppointmentTooltip}
                        >
                            <Editing
                                allowAdding={true}
                                allowDeleting={false}
                                allowResizing={false}
                                allowDragging={false}
                                allowUpdating={false}

                            />

                        </Scheduler>
                    </Card.Body>
                </Card>
                <ToplantiEkleModal
                    show={ekleModalShow}
                    onHide={() => setEkleModalShow(false)}
                    ekle={toplantiEkle}
                    rooms={meetingRooms}
                    startDate={startDate}
                    endDate={endDate}
                />

                <ToplantiGuncelleModal
                    show={guncelleModalShow}
                    guncelle={toplatiGuncelle}
                    ekle={toplantiDüzenle}
                    rooms={meetingRooms}
                    meet={guncelmeeting}
                    onHide={() => setGuncelleModalShow(false)}
                    sil={toplantiSil}
                />

            </Col>
        </Row>
    );
}
