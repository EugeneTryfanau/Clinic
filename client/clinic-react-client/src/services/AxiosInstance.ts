import axios from "axios";
import { axiosConfig } from "../configs/axiosConfig";

const axiosInstance = axios.create({
    baseURL: axiosConfig.baseURL,
});

export default axiosInstance;