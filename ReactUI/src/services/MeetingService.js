import Users from './LoginService';
import axiosInstance from './axiosInstance.js';

export default class MeetingService {

  async getMeeting() {
    return await axiosInstance.get("/Meeting/all");
    // return meetings;
  }
  async getMeetingUserId() {
    let loginuser = Users.getLoginUser();
    if (loginuser.role === "Admin") {
      return await axiosInstance.get("/Meeting/all");
    } else {
      return await axiosInstance.get("/Meeting/userId?id="+loginuser.id);
    }

  }
  async deleteMeeting(id) {
    try {
      const response = await axiosInstance.delete("/Meeting/"+id);
      return true; 
    } catch (error) {
      return false; 
    }
  }

  async addMeeting(meet) {
    debugger
    let loginuser = Users.getLoginUser();
    try {
      const response = await axiosInstance.post('/Meeting', {
        CreateUserId: loginuser.id,
        RoomId: meet.roomId,
        CreateDate: formatCurrentTime(new Date()),
        StartDate: meet.startDate,
        EndDate: meet.endDate,
        Title:meet.title,
        Content:meet.content
      });
      return true; 
    } catch (error) {
      return false; 
    }
  }
  async updateMeeting(newmeet) {
    try {
    const response = await axiosInstance.put('/Meeting/'+newmeet.id, {
      CreateUserId: newmeet.createUserId,
      RoomId: newmeet.roomId,
      StartDate: newmeet.startDate,
      EndDate: newmeet.endDate,
      Title:newmeet.title,
      Content:newmeet.content
    });
    return true; 
  } catch (error) {
    return false; 
  }

  }
  async getMeetingRoomId(id) {
    return await axiosInstance.get("/Meeting/roomId?id="+id);

  }

  getUserMeetingCont(usermeet){
    let loginuser = Users.getLoginUser();
    if(usermeet.createUserId===loginuser.id){
      return true;
    }
    else{
      return false;
    }

  }
}

function formatCurrentTime(date) {
  const year = date.getFullYear();
  const month = ("0" + (date.getMonth() + 1)).slice(-2);
  const day = ("0" + date.getDate()).slice(-2);
  const hours = ("0" + date.getHours()).slice(-2);
  const minutes = ("0" + date.getMinutes()).slice(-2);
  return `${year}-${month}-${day}T${hours}:${minutes}`;
}