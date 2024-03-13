import axios from "axios";
import { axiosConfig } from "../configs/axiosConfig";

const axiosInstance = axios.create({
    baseURL: axiosConfig.baseURL,
});

axiosInstance.interceptors.request.use(
    async (config) => {
        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

export default axiosInstance;