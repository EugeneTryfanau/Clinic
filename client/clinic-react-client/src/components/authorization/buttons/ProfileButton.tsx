import { useAuth0 } from '@auth0/auth0-react';
import { NavBarTab } from '../../navbar/NavBarTab';
import { Button, MenuItem, Typography } from '@mui/material';

export const ProfileButton = () => {

    const { isAuthenticated } = useAuth0();

    return (
        <div>
            {isAuthenticated && (
                <MenuItem>
                    <Typography textAlign="center">
                        <Button>
                            <NavBarTab path="/profile" label="Profile" />
                        </Button>
                        
                    </Typography>
                </MenuItem>
            )}
        </div>

    );
};