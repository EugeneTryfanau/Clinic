import { useAuth0 } from '@auth0/auth0-react';
import { NavBarTab } from '../../navbar/NavBarTab';

export const ProfileButton: React.FC = () => {

    const { isAuthenticated } = useAuth0();

    return (
        <div>
            {isAuthenticated && (
                <NavBarTab path="/profile" label="Profile" />
            )}
        </div>

    );
};