import { BrowserRouter } from 'react-router-dom';
import './App.css';
import Navbar from './components/navbar/Navbar';
import AppRouter from './routers/AppRouter';

function App() {

    return (
        <div className="App">
            <BrowserRouter>
                <Navbar />
                <AppRouter />
            </BrowserRouter>
        </div>
    );
}

export default App;