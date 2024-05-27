import React from 'react';
import { Route, Routes } from 'react-router-dom';
import { constantUrls } from '../constant/constantUrls';
import { Container, Row } from 'react-bootstrap';
import Anasayfa from '../pages/anasayfa/Anasayfa';
import ToplatiListe from '../pages/toplanti/toplantiliste';
import Dashboard from '../layouts/Dashboard';
import Meeting from '../pages/takvim/meeting';
import RequireAuth from './requireAuth';


export default function PageRouter() {

  return (
    <Container fluid>
      <Row>
        <Dashboard />
        <Routes>
          <Route
            path={constantUrls.anasayfa}
            element={<RequireAuth><Anasayfa /></RequireAuth>}
          />
          <Route
            path={constantUrls.toplanti}
            element={<RequireAuth><ToplatiListe /></RequireAuth>}
          />
           <Route
            path={constantUrls.meeting}
            element={<RequireAuth><Meeting /></RequireAuth>}
          />
        </Routes>
      </Row>
    </Container>
  );
}
