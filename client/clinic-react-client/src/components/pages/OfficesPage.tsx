import { AxiosRequestConfig } from "axios";
import axiosInstance from "../../services/AxiosInstance";
import OfficeTable from "../offices/OfficeTable";
import { useAuth0 } from "@auth0/auth0-react";

const OfficesPage = () => {
    const { getAccessTokenSilently } = useAuth0();

    axiosInstance.interceptors.request.use(
        async (config: AxiosRequestConfig): Promise<any> => {
            const token = await getAccessTokenSilently();
            if (token) {
                config.headers!.Authorization = `Bearer ${token}`;
            }
            return config;
        }
    );

    return (
        <div>
            <OfficeTable />
        </div>
    );
}

export default OfficesPage;