import React, { useEffect, useState } from 'react';
import { Accordion, Card, Col, Row, Modal, Container } from 'react-bootstrap';
import ToplantiEkleModal from '../toplanti/toplantiekle.jsx';
import MeetingService from "../../services/MeetingService.js"
import Clock from './Clock.jsx';

export default function RoomPopup(props) {

    const meetingService = new MeetingService();
    const [ekleModalShow, setEkleModalShow] = useState(false);
    const [room, setRoom] = useState();

    useEffect(() => {
        let selectroom = props.rooms.filter(room => room.id === props.selectroom.room.id);
        setRoom(selectroom);

    }, [props.time])

    function toplantiEkle(newmeeting) {
        let cont = meetingService.addMeeting(newmeeting);
        if (cont) {
            setEkleModalShow(false);
            props.control();
        }
    }
    function formatDate(date) {
        let datetime = new Date(date);

        let hours = datetime.getHours();
        let minutes = datetime.getMinutes();
        let timePart = `${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}`;
        return timePart;

    }


return (
    <div>
        <Modal
            {...props}
            size="xl"
            aria-labelledby="contained-modal-title-vcenter"
            centered
        >
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">
                    {props.selectroom.room.name}
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Row>
                    <Col>
                        {/* <Card className='meeting mb-2'> */}
                        <Card.Body>
                            <Container>
                                <Row>
                                    <Col md={12} lg={5} className='mb-3' >
                                        <Card className={`text-center ${props.selectroom.room.active ? 'aktifroom' : 'beklemederoom'}`}
                                            style={{ border: 'initial' }}>
                                            <Card.Body>
                                                <Row>
                                                    <Clock />
                                                </Row>
                                                <Row className='p-3 clock'>
                                                    <h3>{props.selectroom.room.active ? 'Meşgul' : 'Beklemede'}</h3>
                                                </Row>
                                                {props.selectroom.room.active ? (
                                                    <>
                                                        <Row className='p-3'>
                                                            <div className='bitissaat'>{props.selectroom.room.activemeeting.endDate.slice(props.selectroom.room.activemeeting.endDate.indexOf("T") + 1)}</div>
                                                        </Row>
                                                        <Row className='p-3 clock'>
                                                            <h3>Toplantı Bitiş Saati</h3>
                                                        </Row>
                                                    </>
                                                ) : (
                                                    <>
                                                        <Row className='p-3'>
                                                            {/* <BsFillPlusCircleFill className='addicon' size={100} /> */}
                                                            <svg stroke="currentColor" fill="currentColor" strokeWidth="0" viewBox="0 0 16 16" height="100px" width="100px" xmlns="http://www.w3.org/2000/svg"><path onClick={() => setEkleModalShow(true)} className='addicon' d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0M8.5 4.5a.5.5 0 0 0-1 0v3h-3a.5.5 0 0 0 0 1h3v3a.5.5 0 0 0 1 0v-3h3a.5.5 0 0 0 0-1h-3z"></path></svg>
                                                        </Row>
                                                        <Row className='p-3 clock'>
                                                            <h3>Toplantı Ekle</h3>
                                                        </Row>
                                                    </>

                                                )}
                                            </Card.Body>
                                        </Card>
                                    </Col>
                                    <Col md={12} lg={7}>
                                        <h5>Günlük Toplantılar</h5>
                                        <Accordion>
                                            {props.selectroom.selectmeeting !== undefined && props.selectroom.selectmeeting.map((roommeeting) => (
                                                <Accordion.Item eventKey={roommeeting.id}>
                                                    <Accordion.Header><strong>{roommeeting.title}</strong></Accordion.Header>
                                                    <Accordion.Body>
                                                        <Row>
                                                            <Col md={4}><strong>Başlangıç Saati: </strong>{formatDate(roommeeting.startDate)}</Col>
                                                            <Col md={4}><strong>Bitiş Saati: </strong>{formatDate(roommeeting.endDate)}</Col>
                                                            <Col md={4}><strong>Oluşturan:</strong> {roommeeting.userFirstName} {roommeeting.userLastName}</Col>
                                                            <Col md={12} className='mt-3'>{roommeeting.aciklama}</Col>
                                                        </Row>

                                                    </Accordion.Body>
                                                </Accordion.Item>
                                            ))}

                                        </Accordion>
                                    </Col>
                                </Row>
                            </Container>
                        </Card.Body>
                        {/* </Card> */}
                    </Col>

                </Row>
            </Modal.Body>

        </Modal>
        <ToplantiEkleModal
            show={ekleModalShow}
            onHide={() => setEkleModalShow(false)}
            ekle={toplantiEkle}
            rooms={props.rooms}
            aktifroom={props.selectroom.room.id}
        />
    </div>
)
}
