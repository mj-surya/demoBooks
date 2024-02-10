import Register from './Components/Register';
import {toast, ToastContainer} from 'react-toastify';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';
import Menu from './Components/Menu';
import AddBook from './Components/AddBook';
import UpdateBook from './Components/UpdateBook';
import Books from './Components/Books';
import AdminBooks from './Components/AdminBooks';
import Login from './Components/Login';
import UserMenu from './Components/UserMenu';

function App() {
  var usertype = localStorage.getItem('role');
  return (
    <div className="App">
      
      <ToastContainer/>
      <BrowserRouter>
      {usertype==="Admin"?<Menu/> : <UserMenu/> }
      <div class="margin">
      <Routes>
        <Route path="Register" element={<Register/>} />
        <Route path="AddBook" element={<AddBook/>} />
        <Route path="AdminBooks" element={<AdminBooks/>} />
        <Route path="Home" element={<Books/>} />
        <Route path="Login" element={<Login/>} />
       </Routes>
      </div>
       
      </BrowserRouter>
    </div>
  );
}

export default App;
