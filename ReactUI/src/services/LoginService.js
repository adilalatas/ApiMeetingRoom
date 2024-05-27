import axios from "axios";
import Cookies from 'js-cookie';
import axiosInstance from './axiosInstance.js';

export default class LoginService {
  async postLogin(kullanici) {

    try {
      const response = await axios.post('http://localhost:5110/api/authentication/login', {
        Email: kullanici.username,
        Password: kullanici.password
      });
      const loginUserData = {        
        firstName:response.data.loginUser.firstName,
        lastName:response.data.loginUser.lastName,
        email:response.data.loginUser.email,
        userName:response.data.loginUser.userName,
        role: response.data.loginUserRole,
        id: response.data.loginUser.id
    };
      Cookies.set('loginuser', JSON.stringify(loginUserData), { expires: 45/1440 });
      Cookies.set('token', response.data.accessToken, { expires:  45/1440 });


      return true;
    } catch (error) {
      return false;
    }
  }
  static getLoginUser() {
    const loginUser = Cookies.get('loginuser');
    return loginUser ? JSON.parse(loginUser) : null;
  }

  static Logout() {
    Cookies.remove('loginuser');
    Cookies.remove('token');

    return true;
  }

  getUserById(id) {
    return new Promise((resolve, reject) => {
      axiosInstance.get(`/User/${id}`)
        .then(response => {
          resolve(response.data);
        })
        .catch(error => {
          reject(new Error('Kullanıcı bilgileri alınamadı'));
        });
    });

  }
}

