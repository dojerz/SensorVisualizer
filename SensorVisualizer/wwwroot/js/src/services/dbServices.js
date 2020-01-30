import axios from 'axios';

const dbService = axios.create({
    baseURL: "/api"
});

export const getSensorData = async (a,b,c) => {
    return dbService.get('/SensorData/'+a+'/'+b+'/'+c)
}