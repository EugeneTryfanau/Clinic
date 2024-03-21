import { Link } from "react-router-dom";

interface NavBarTabProps {
    path: string;
    label: string;
  }
  
  export const NavBarTab: React.FC<NavBarTabProps> = ({ path, label }) => {
    return (
      <Link to={path}>
        {label}
      </Link>
    );
  };
  