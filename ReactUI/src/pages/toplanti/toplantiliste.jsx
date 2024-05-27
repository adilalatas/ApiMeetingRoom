import React, { useEffect, useState } from 'react'
import { Button, Card, Col, Container, Form, Modal, Row, Table } from 'react-bootstrap'
import MeetingService from "../../services/MeetingService.js"
import MeetingRoomService from "../../services/MeetingRoomService.js"
import Swal from 'sweetalert2';
import ToplantiEkleModal from './toplantiekle.jsx';
import ToplantiGuncelleModal from './toplantiguncelle.jsx';
import LoginService from "../../services/LoginService.js"
import { Await } from 'react-router-dom';

export default function ToplatiListe() {

    const meetingRoomService = new MeetingRoomService();
    const meetingService = new MeetingService();
    const loginService = new LoginService();

    const [isDeleted, setIsDeleted] = useState(0);
    const [usermeetings, setUsermeetings] = useState([]);
    const [meetingrooms, setMeetingrooms] = useState([]);
    const [ekleModalShow, setEkleModalShow] = useState(false);
    const [guncelleModalShow, setGuncelleModalShow] = useState(false);
    const [guncelmeeting, setGuncelMeeting] = useState();
    const userLogin = LoginService.getLoginUser();

    useEffect(() => {
        const fetchData = async () => {

            let meetingdata=await meetingService.getMeetingUserId();
            let meetinroomgdata=await meetingRoomService.getMeetingRooms();

            setUsermeetings(meetingdata.data);
            setMeetingrooms(meetinroomgdata.data);
         };
        fetchData();
    }, [isDeleted])


    function formatDate(date) {
        const formattedDate = new Date(date);
        const day = formattedDate.getDate().toString().padStart(2, '0');
        const month = (formattedDate.getMonth() + 1).toString().padStart(2, '0');
        const year = formattedDate.getFullYear();
        const hours = formattedDate.getHours().toString().padStart(2, '0');
        const minutes = formattedDate.getMinutes().toString().padStart(2, '0');
        return `${day}.${month}.${year} ${hours}:${minutes}`;
    }

    async function toplantiSil(id) {
        const result = await Swal.fire({
            text: "Toplantı Silinecektir. Onaylıyor musun?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Sil",
            cancelButtonText: "İptal"
        });
    
        if (result.isConfirmed) {
            try {
                let isdeleted = await meetingService.deleteMeeting(id);
                if (isdeleted) {
                    setIsDeleted(prevValue => prevValue + 1);
                    Swal.fire({
                        title: "Silindi!",
                        text: "Toplantınız başarı ile silinmiştir.",
                        icon: "success",
                        confirmButtonText: "Tamam"
                    });
                }
            } catch (error) {
                console.error("Failed to delete meeting:", error);
                Swal.fire({
                    title: "Hata!",
                    text: "Toplantı silinirken bir hata oluştu.",
                    icon: "error",
                    confirmButtonText: "Tamam"
                });
            }
        }
    }
    

    function toplantiDüzenle(meet) {
        setGuncelleModalShow(true);
        setGuncelMeeting(meet);
    }

    async function toplatiGuncelle(meet) {
        let cont = await meetingService.updateMeeting(meet);
        if (cont) {
            setGuncelleModalShow(false);
            setIsDeleted(prevValue => prevValue + 1);
        }
    }
    async function toplantiEkle(newmeeting) {
        let cont = await meetingService.addMeeting(newmeeting);
        if (cont) {
            setEkleModalShow(false);
            setIsDeleted(prevValue => prevValue + 1);
        }
    }

    return (
        <Container fluid className='toplanti'>
            <Row>
                <Col>
                    <Card className='mb-2'>
                        <Card.Body className='p-5 text-center'>
                        <h1>Toplantılarım</h1>

                            <Row>
                                <Col md={12}>
                                    <Table striped bordered hover>
                                        <thead>
                                            <tr>
                                                <th>Başlık</th>
                                                <th>Açıklama</th>
                                                <th>Başlangıç</th>
                                                <th>Bitiş</th>
                                                <th>Toplantı Odası</th>
                                                {userLogin.role === 'Admin' && <th>Toplantı Sahibi</th>}
                                                <th>Düzenle</th>
                                                <th>Sil</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            {usermeetings.length > 0 && usermeetings.map((usermeeting) => (
                                                <tr key={usermeeting.id}>
                                                    <td>{usermeeting.title}</td>
                                                    <td>{usermeeting.content}</td>
                                                    <td>{formatDate(usermeeting.startDate)}</td>
                                                    <td>{formatDate(usermeeting.endDate)}</td>
                                                    <td>{usermeeting.roomName}</td>
                                                    {userLogin.role === 'Admin' && <td>{usermeeting.userFirstName} {usermeeting.userLastName}</td>}
                                                    <td className='text-success' onClick={() => toplantiDüzenle(usermeeting)}>Düzenle</td>
                                                    <td className='text-danger' onClick={() => toplantiSil(usermeeting.id)}>Sil</td>
                                                </tr>
                                            ))}
                                        </tbody>
                                    </Table>
                                </Col>
                                <Col className='d-flex justify-content-end'>
                                    <Button variant="outline-primary" onClick={() => setEkleModalShow(true)}>Toplantı Ekle</Button>
                                </Col>
                            </Row>
                        </Card.Body>
                    </Card>
                </Col>
            </Row>
            <ToplantiEkleModal
                show={ekleModalShow}
                onHide={() => setEkleModalShow(false)}
                ekle={toplantiEkle}
                rooms={meetingrooms}
            />
            <ToplantiGuncelleModal
                show={guncelleModalShow}
                guncelle={toplatiGuncelle}
                ekle={toplantiDüzenle}
                rooms={meetingrooms}
                meet={guncelmeeting}
                onHide={() => setGuncelleModalShow(false)}
            />
        </Container>
    )
}
