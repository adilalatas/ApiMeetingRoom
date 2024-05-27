import React, { useEffect, useState } from 'react'
import '../../assest/css/Clock.css';
import moment from 'moment';

export default function Clock() {
    const [currentTime, setCurrentTime] = useState(moment().format('D MMMM YYYY H:mm:ss'));

    useEffect(() => {
        const intervalId = setInterval(() => {
            setCurrentTime(moment().format('D MMMM YYYY H:mm:ss'));
        }, 1000);

        return () => clearInterval(intervalId);
    }, []);
    return (

        <div id="clock" className="clock">{currentTime}</div>
    )
}
