import { IOffice } from "../models/IOffice";
import axiosInstance from "./AxiosInstance";

export default class OfficesService {

    static async getAll() {
        const response = await axiosInstance.get<Array<IOffice>>(`/Offices`)
        return response.data;
    }
}
