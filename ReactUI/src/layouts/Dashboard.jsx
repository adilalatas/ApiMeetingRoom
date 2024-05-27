import React from 'react';
import { Col, Container, Nav, Navbar } from 'react-bootstrap';
import { NavLink } from 'react-router-dom';
import { constantUrls } from '../constant/constantUrls';
import Popup from './UserPopup.jsx';
import "../assest/css/navbar.css";
import { FaHome, FaChalkboardTeacher } from 'react-icons/fa';
import { BsCalendar2Date } from 'react-icons/bs';

function Dashboard() {

  return (
    <Col className='p-2'>
      <Navbar expand="lg" className="bg-body-tertiary">
        <Container>
          <Navbar.Brand href="#">MEEROO</Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="me-auto">
              <Nav.Link as={NavLink} to={constantUrls.anasayfa}><FaHome size={20} /> Anasayfa</Nav.Link>
              <Nav.Link as={NavLink} to={constantUrls.toplanti}><FaChalkboardTeacher size={20} /> Toplantılarım</Nav.Link>
              <Nav.Link as={NavLink} to={constantUrls.meeting}><BsCalendar2Date  size={20} /> Takvim</Nav.Link>
            </Nav>
          </Navbar.Collapse>
          <Navbar.Collapse className="justify-content-end">
            <Navbar.Text>
              <Popup/>    
            </Navbar.Text>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </Col>

  );
}

export default Dashboard;