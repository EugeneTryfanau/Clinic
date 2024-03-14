import { IOffice } from "../models/IOffice";
import { requestHandler } from "./requestHandler";
import axiosInstance from "./AxiosInstance";

export const getOffices = requestHandler<StandartParams, IOffice[]>((params => 
    axiosInstance.get(`/Offices`, { params })
));