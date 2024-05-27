import Cookies from 'js-cookie';

export function getToken() {
    const loginUser = Cookies.get('loginuser');
    return loginUser ? JSON.parse(loginUser) : null;
}