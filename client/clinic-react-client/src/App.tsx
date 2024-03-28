import { BrowserRouter } from 'react-router-dom';
import './App.css';
import Navbar from './components/navbar/Navbar';
import AppRouter from './routers/AppRouter';
import { Auth0ProviderWithNavigate } from './auth0ProviderWithNavigate';

function App() {

    return (
        <div className="App">
            <BrowserRouter>
                <Auth0ProviderWithNavigate>
                    <Navbar />
                    <AppRouter />
                </Auth0ProviderWithNavigate>
            </BrowserRouter>
        </div>
    );
}

export default App;