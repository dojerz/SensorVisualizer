import axios from 'axios';

const dbService = axios.create({
    baseURL: "/api"
});

export const getSensorData = async () => {
    return dbService.get('/SensorData')
}