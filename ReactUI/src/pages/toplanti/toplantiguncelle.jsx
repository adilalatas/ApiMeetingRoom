import React, { useEffect, useState } from 'react';
import { Button, Col, Form, Modal, Row } from 'react-bootstrap';
import MeetingService from "../../services/MeetingService.js"
import Swal from 'sweetalert2';


export default function ToplantiGuncelleModal(props) {
    const meetingService = new MeetingService();

    const [upmeeting, setUpMeeting] = useState({
        title: '',
        content: '',
        startDate: '',
        endDate: '',
        roomId: 0,
    });

    useEffect(() => {
        if (props.meet) {
            setUpMeeting(props.meet);
        }
    }, [props])

    const handleChange = (e) => {
        const { name, value } = e.target;
        setUpMeeting((prevMeeting) => ({
            ...prevMeeting,
            [name]: value,
        }));
    };

    async function inputControl() {
        let cont = false;
        const { title, content, startDate, endDate, roomId, id } = upmeeting;
        if (title && content && startDate && endDate && roomId !== "0") {
            let roommeetings = await meetingService.getMeetingRoomId(roomId);
            roommeetings.data.map(meet => {
                if (!cont) {
                    if (meet.startDate < endDate && meet.endDate > startDate && meet.id !== id) {
                        cont = true;
                    }
                }
            });
            if (cont) {
                Swal.fire({
                    icon: 'error',
                    title: "Girilen saatte başka bit toplantı bulunmaktadır",
                    showConfirmButton: false,
                    timer: 1000
                });
            }
            else {
                props.guncelle(upmeeting);

            }
        }
        else {
            Swal.fire({
                icon: 'error',
                title: "Lütfen tüm bilgileri doldurunuz",
                showConfirmButton: false,
                timer: 1000
            });
        }
    }

    return (
        <Modal
            {...props}
            size="xl"
            aria-labelledby="contained-modal-title-vcenter"
            centered
        >
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">
                    Toplantı Güncelle
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Row>
                    <Form.Group className="mb-3" controlId="formGrouptitle">
                        <Form.Label>Başlık</Form.Label>
                        <Form.Control type="text" name="title" value={upmeeting.title} onChange={handleChange} />
                    </Form.Group>
                    <Form.Group className="mb-3" controlId="formGroupendDate">
                        <Form.Label>Salon</Form.Label>
                        <Form.Select aria-label="Default select example" name="roomId" value={upmeeting.roomId} onChange={handleChange}>
                            <option value="0">Lütfen Salon Seçiniz</option>
                            {props.rooms.map((room) => (
                                <option key={room.id} value={room.id}>{room.name}</option>
                            ))}
                        </Form.Select>
                    </Form.Group>

                    <Col md={6}>
                        <Form.Group className="mb-3" controlId="formGroupstartDate">
                            <Form.Label>Başlangıç</Form.Label>
                            <Form.Control type="datetime-local" name="startDate" value={upmeeting.startDate} onChange={handleChange} />
                        </Form.Group>
                    </Col>
                    <Col md={6}>
                        <Form.Group className="mb-3" controlId="formGroupendDate">
                            <Form.Label>Bitiş</Form.Label>
                            <Form.Control type="datetime-local" name="endDate" value={upmeeting.endDate} onChange={handleChange} />
                        </Form.Group>
                    </Col>
                    <Form.Group className="mb-3" controlId="formGroupcontent">
                        <Form.Label>Açıklama</Form.Label>
                        <Form.Control type="text" as="textarea" name="content" value={upmeeting.content} onChange={handleChange} />
                    </Form.Group>
                </Row>

            </Modal.Body>
            <Modal.Footer>
                <Button onClick={() => inputControl()} >Güncelle</Button>
                {props.sil !== undefined ? (
                    <Button onClick={() => props.sil(props.meet.id)}>Sil</Button>

                ) : (

                    <Button onClick={props.onHide}>Kapat</Button>
                )}

            </Modal.Footer>
        </Modal>
    );
}
