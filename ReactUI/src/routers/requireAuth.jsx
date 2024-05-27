import React from 'react'
import { Navigate } from 'react-router-dom';
import { constantUrls } from '../constant/constantUrls';
import { getToken } from '../services/tokenService';

const RequireAuth=({children})=> {
    const loginuser = getToken();

    if(!loginuser){
        return <Navigate to={constantUrls.login} />
    }
    else{
        return children;
    }
}

export default RequireAuth