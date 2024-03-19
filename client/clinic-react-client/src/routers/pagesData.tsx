import OfficeDetails from "../components/offices/ActionPages/OfficeDetails";
import HomePage from "../components/pages/HomePage";
import OfficesPage from "../components/pages/OfficesPage";


export interface routerType {
    title: string;
    path: string;
    element: JSX.Element;
}

export const privateRoutes: routerType[] = [
    { title: "Offices", path: '/offices', element: <OfficesPage /> },
    { title: "Office", path: '/offices/:id', element: <OfficeDetails /> },
    { title: "Home", path: '/', element: <HomePage /> },
]