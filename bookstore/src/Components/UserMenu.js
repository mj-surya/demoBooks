import './Menu.css';
import { Link, useNavigate} from "react-router-dom";


function UserMenu(){
    const navigate = useNavigate();
    const logout=()=>{
        localStorage.clear();
        navigate('/Home');
        window.location.reload();

    }
    
    return(
        <nav class="navbar fixed-top navbar-expand-sm navbar-light line pad ">
            <Link class="navbar-brand pad" to="/Home">Book Store</Link>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbar-collapse">☰</button> 
            <div class="collapse navbar-collapse" id="navbar-collapse">
                <ul class="nav navbar-nav ml-auto">
                    <li class="nav-item active"> <Link class="nav-link" to="/Home"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-house-door-fill" viewBox="0 0 16 16">
  <path d="M6.5 14.5v-3.505c0-.245.25-.495.5-.495h2c.25 0 .5.25.5.5v3.5a.5.5 0 0 0 .5.5h4a.5.5 0 0 0 .5-.5v-7a.5.5 0 0 0-.146-.354L13 5.793V2.5a.5.5 0 0 0-.5-.5h-1a.5.5 0 0 0-.5.5v1.293L8.354 1.146a.5.5 0 0 0-.708 0l-6 6A.5.5 0 0 0 1.5 7.5v7a.5.5 0 0 0 .5.5h4a.5.5 0 0 0 .5-.5"/>
</svg> Home</Link>
                    </li>
                    <li class="nav-item dropdown"> 
                        <a class="nav-link dropdown-toggle" data-bs-toggle="dropdown" href='#' role="button" aria-haspopup="true" aria-expanded="false"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-buildings" viewBox="0 0 16 16">
  <path d="M14.763.075A.5.5 0 0 1 15 .5v15a.5.5 0 0 1-.5.5h-3a.5.5 0 0 1-.5-.5V14h-1v1.5a.5.5 0 0 1-.5.5h-9a.5.5 0 0 1-.5-.5V10a.5.5 0 0 1 .342-.474L6 7.64V4.5a.5.5 0 0 1 .276-.447l8-4a.5.5 0 0 1 .487.022ZM6 8.694 1 10.36V15h5zM7 15h2v-1.5a.5.5 0 0 1 .5-.5h2a.5.5 0 0 1 .5.5V15h2V1.309l-7 3.5z"/>
  <path d="M2 11h1v1H2zm2 0h1v1H4zm-2 2h1v1H2zm2 0h1v1H4zm4-4h1v1H8zm2 0h1v1h-1zm-2 2h1v1H8zm2 0h1v1h-1zm2-2h1v1h-1zm0 2h1v1h-1zM8 7h1v1H8zm2 0h1v1h-1zm2 0h1v1h-1zM8 5h1v1H8zm2 0h1v1h-1zm2 0h1v1h-1zm0-2h1v1h-1z"/>
</svg> {localStorage.getItem("name")? localStorage.getItem("name") : "Login/Register" }</a>
                        <div class="dropdown-menu dropdown-menu-right">
                            {localStorage.getItem("token")?
                            <div>
                                <Link class="dropdown-item" onClick={logout}>logout</Link>

                            </div> 
                            :
                            <div><Link class="dropdown-item" to="/Login">Login</Link>
                            <Link class="dropdown-item" to="/Register">Register</Link></div>
                            }
                            
                            
                            
                        </div>
                    </li>
                </ul>
            </div>
        </nav>
    )
}

export default UserMenu;