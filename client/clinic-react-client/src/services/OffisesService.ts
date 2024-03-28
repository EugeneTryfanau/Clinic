import { IOffice } from "../models/IOffice";
import axiosInstance from "./AxiosInstance";
import { requestHandler } from "./requestHandler";

export const getOffices = requestHandler<StandartParams, IOffice[]>(async params => 
    await axiosInstance.get(`/Offices`, { params })
);

export const getByIdOffice = requestHandler<StandartParamsWithId, IOffice>(async params => 
    await axiosInstance.get(`/Offices/${params?.id}`, { params })
);

export const createOffice = requestHandler<StandartParamsWithEntity<IOffice>, IOffice>(async params => 
    await axiosInstance.post(`/Offices`, params?.entity, { params })
);

export const updateOffice = requestHandler<StandartParamsWithIdAndEntity<IOffice>, IOffice>(async params => 
    await axiosInstance.put(`/Offices/${params?.id}`, params?.entity, { params })
);

export const deleteOffice = requestHandler<StandartParamsWithId, void>(async params => 
    await axiosInstance.delete(`/Offices/${params?.id}`, { params })
);