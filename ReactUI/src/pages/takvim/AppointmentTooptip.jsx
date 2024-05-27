import React from 'react';

const AppointmentTooltip = (props) => {

    function formatCurrentTime(date) {
        const timePart = date.slice(date.indexOf("T") + 1);

        return timePart;
    }
  return (
    <div className="row">
        <h6>{props.data.appointmentData.text}</h6>
        <label>{formatCurrentTime(props.data.appointmentData.startDate)} - {formatCurrentTime(props.data.appointmentData.endDate)}</label>
        <label>Toplantı Salonu: {props.data.appointmentData.roomName} </label>
    </div>
  );
};
export default AppointmentTooltip;