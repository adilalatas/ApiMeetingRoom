import axiosInstance from './axiosInstance.js';

export default class MeetingRoomService {
  async getMeetingRooms() {
    try {
      const response = await axiosInstance.get('/Room/all');
      return response;
    } catch (error) {
      console.error('Error fetching meeting rooms:', error);
      return false;
    }
  }
}