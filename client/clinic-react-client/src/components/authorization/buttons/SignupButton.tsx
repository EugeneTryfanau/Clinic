import { useAuth0 } from "@auth0/auth0-react";
import { Button } from "@mui/material";

export const SignupButton = () => {
    const { loginWithRedirect } = useAuth0();
  
    const handleSignUp = async () => {
      await loginWithRedirect({
        appState: {
          returnTo: "/profile",
        },
        authorizationParams: {
          prompt: "login",
          screen_hint: "signup",
        },
      });
    };
  
    return (
      <Button className="button__sign-up" onClick={handleSignUp}>
        Sign Up
      </Button>
    );
  };
  