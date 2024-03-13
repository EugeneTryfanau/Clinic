import HomePage from "../components/pages/HomePage";
import OfficesPage from "../components/pages/OfficesPage";


export interface routerType {
    title: string;
    path: string;
    element: JSX.Element;
}

export const privateRoutes: routerType[] = [
    { title: "Offices", path: '/offices', element: <OfficesPage /> },
    { title: "Home", path: '/', element: <HomePage /> },
]