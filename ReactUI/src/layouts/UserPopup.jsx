import React, { useEffect, useState } from 'react';
import { OverlayTrigger, Popover } from 'react-bootstrap';
import { Person } from 'react-bootstrap-icons';
import LoginService from "../services/LoginService.js"
import { useNavigate } from 'react-router-dom';
import { constantUrls } from '../constant/constantUrls.js';

export default function UserPopup() {
    const [loginuser, setLoginuser] = useState({ username: '', password: '', });
    const navigate = useNavigate();

    useEffect(() => {
        setLoginuser(LoginService.getLoginUser());
    }, [])

    function Logout() {
        const cont = LoginService.Logout();
        if (cont) {
            navigate(constantUrls.login);
        }
    }
    return (
        <OverlayTrigger
            trigger="click"
            key="bottom"
            placement="bottom"
            overlay={
                <Popover id={"popover-positioned-bottom"}>
                    <Popover.Header className='text-center' as="h3">{loginuser.email}</Popover.Header>
                    <Popover.Body className='text-center'>
                        <strong onClick={() => Logout()} style={{ cursor: 'pointer' }} className='text-danger'>Çıkış Yap</strong>
                    </Popover.Body>
                </Popover>
            }
        >
            <Person size={25} />
        </OverlayTrigger>
    )
}
