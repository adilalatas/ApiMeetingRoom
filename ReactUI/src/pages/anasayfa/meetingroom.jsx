import React from 'react'
import { Card, Col, Row } from 'react-bootstrap';
import '../../assest/css/Roomcard.css';

export default function MeetingRoom(props) {

    function formatDate(date) {
        let datetime = new Date(date);

        let hours = datetime.getHours();
        let minutes = datetime.getMinutes();
        let timePart = `${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}`;
        return timePart;
    }

    return (
        <Row className='roomcard mt-4'>
            {props.Meetingrooms.length > 0 && props.Meetingrooms.map((meetingRoom) => (
                <Col md={6} className='mb-3'>
                    <Card className={`h-100 ${meetingRoom.active ? 'aktif' : 'beklemede'}`} key={meetingRoom.id} onClick={() => props.selectroom(meetingRoom)}>
                        <Card.Body className='p-5'>
                            <Row >
                                <Col className="d-flex justify-content-start">
                                    <h2>{meetingRoom.name}</h2>
                                </Col>
                                <Col className="d-flex justify-content-end">
                                    <h2>{meetingRoom.active ? 'Meşgul' : 'Beklemede'}</h2>
                                </Col>
                                {meetingRoom.activemeeting !== undefined ? (
                                    <div>
                                        <p className='mt-3'><strong>Toplantı Adı: </strong>{meetingRoom.activemeeting.title}</p>
                                        <p><strong>Toplantı Saati: </strong>{formatDate(meetingRoom.activemeeting.startDate)} - {formatDate(meetingRoom.activemeeting.endDate)} </p>
                                    </div>
                                ) : (
                                    <div>
                                        <p className='mt-3'>Aktif toplantı bulunmamaktadır</p>
                                        <p className='mt-3'>Toplantı eklemek için tıklayınız</p>
                                    </div>

                                )}
                            </Row>
                        </Card.Body>

                    </Card>
                </Col>
            ))}
        </Row>

    )
}
