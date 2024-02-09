import Register from './Components/Register';
import Login from './Components/Login';
import {toast, ToastContainer} from 'react-toastify';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';

function App() {
  return (
    <div className="App">
      <ToastContainer/>
      <Register/>
      <BrowserRouter>
       <Routes>
       <Route path="Login" element={<Login />} />
       <Route path="Register" element={<Register/>} />
       </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
