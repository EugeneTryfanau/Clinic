import { Link } from "react-router-dom";

const Navbar = () => {
    return (
        <div className="navbar">
            <div className="navbar__links__block">
                <Link className="navbar__link" to="/">Home Page</Link>
                <Link className="navbar__link" to="/offices">Offices</Link>
            </div>
        </div>
    );
};

export default Navbar;