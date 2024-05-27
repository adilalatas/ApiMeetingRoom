import React, { useEffect, useState } from 'react';
import { Button, Card, Col, Container, Form, Row } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
import LoginService from "../services/LoginService.js"

import "../assest/css/Login.css";
import { constantUrls } from '../constant/constantUrls.js';
import Swal from 'sweetalert2';

function Login() {
  const [user, setUser] = useState({ username: '', password: '' });
  const navigate=useNavigate();
  const loginService= new LoginService();
  
  useEffect(() => {
    LoginService.Logout();
  }, [])
  

  const handleLogin = async () => {
    const usercont=await loginService.postLogin(user);
    if (usercont) {
      navigate(constantUrls.anasayfa);
    } else {
      Swal.fire({
        icon:'error',
        title: "Girilen Şifre veya Kullanıcı Adi yanlıştır",
        showConfirmButton: false,
        timer: 1000
      }); 
    }
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setUser((prevUser) => ({
      ...prevUser,
      [name]: value,
    }));
  };
    return (
      <Container fluid  className='login'>
        <Card className='col-md-6 text-center'> 
          <Row>
            <Col>
              <Card.Body className='p-5'>
                <Form.Group className="mb-3" controlId="formGroupEmail">
                  <Form.Label>Kullanıcı Adı</Form.Label>
                  <Form.Control type="text" name="username" placeholder="Kullanıcı Adı" value={user.username} onChange={handleChange}/>
                </Form.Group>
                <Form.Group className="mb-3" controlId="formGroupPassword">
                  <Form.Label>Şifre</Form.Label>
                  <Form.Control type="password" name="password" placeholder="Şifre" value={user.password} onChange={handleChange} />
                </Form.Group>
                  <Button onClick={handleLogin} className="mb-3" variant="outline-warning">Giriş Yap</Button>
              </Card.Body>
            </Col>
          </Row>
        </Card>
    </Container>
    );
}

export default Login;
