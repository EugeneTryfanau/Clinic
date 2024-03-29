import { useAuth0, withAuthenticationRequired } from '@auth0/auth0-react'
import { CircularProgress } from '@mui/material'

export const ProfilePage = withAuthenticationRequired(
    () => {
        const { user, getIdTokenClaims } = useAuth0();
        const tokenClaims = getIdTokenClaims();
        console.log(user, tokenClaims)

        return (
            <>
                <h1>Profile Page</h1>
                <div className='profile'>
                    <img src={user?.picture} alt={user?.name} />
                    <div>
                        <h2>{user?.name}</h2>
                        <p>{user?.email}</p>
                    </div>
                </div>
            </>
        )
    },
    {
        returnTo: '/profile',
        onRedirecting: () => <CircularProgress />
    }
)