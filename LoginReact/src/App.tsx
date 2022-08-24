import { Switch, Route, Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";
import Login from "./components/Login";
import Register from "./components/Register";

const App =() => {

  return (
    <div>
      <nav className="navbar navbar-expand navbar-dark bg-dark">
         
          <div className="navbar-nav ml-auto">  
          <li className="nav-item" >
              <Link to={"/login"} className="nav-link">
                Sign In
              </Link>
            </li>         
            <li className="nav-item" >
              <Link to={"/register"} className="nav-link">
                Sign Up
              </Link>
            </li>
          </div>       
      </nav>
      <div className="container mt-3">
        <Switch>
          
          <Route exact path={["/", "/login"]} component={Login} />
          <Route exact path="/register" component={Register} />
                  
        </Switch>
      </div>
    </div>
  );
};

export default App;
