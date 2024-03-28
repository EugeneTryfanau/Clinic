import { useAuth0 } from '@auth0/auth0-react'
import { LoginButton } from './buttons/LoginButton'
import { LogoutButton } from './buttons/LogoutButton'
import { SignupButton } from './buttons/SignupButton';
import { MenuItem, Typography } from '@mui/material';

export const AuthButton = () => {
  const { isAuthenticated } = useAuth0();

  return (
    <div className="nav-bar__buttons">
      {!isAuthenticated && (
        <>
          <MenuItem>
            <Typography textAlign="center">
              <SignupButton />
            </Typography>
          </MenuItem>
          <MenuItem>
            <Typography textAlign="center">
              <LoginButton />
            </Typography>
          </MenuItem>
        </>
      )}
      {isAuthenticated && (
        <MenuItem>
          <Typography textAlign="center">
            <LogoutButton />
          </Typography>
        </MenuItem>
      )}
    </div>
  );
};