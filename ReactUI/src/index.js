import React from 'react';
import ReactDOM from 'react-dom/client';
import 'bootstrap/dist/css/bootstrap.min.css';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Login from './pages/Login';
import PageRouter from './routers/pageRouter';
import 'sweetalert2/dist/sweetalert2.all.min.js';
import 'devextreme/dist/css/dx.light.css'; 

import axios from 'axios';
import { constantUrls } from './constant/constantUrls';


const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <BrowserRouter>
        <Routes>
            <Route index element={<Login />} />
            <Route path={constantUrls.login} element={<Login />} />
            <Route path={constantUrls.otherurl} element={<PageRouter />} />
        </Routes>
    </BrowserRouter>
);


