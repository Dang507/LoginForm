import { Console } from "console";
import React from "react";
import { getCurrentUser } from "../services/auth.service";

const Profile = () => {
  const currentUser = getCurrentUser();
  
  return (
    
    <div className="container">
    
      <header className="jumbotron">
        <h3>
          <strong>{currentUser.username}</strong> Profile
        </h3>
      </header>
      <p>
        <strong>Token:</strong> {currentUser.token.substring(0, 20)} ...{" "}
        {currentUser.accessToken.substr(currentUser.token.length - 20)}
      </p>
      <p>
        <strong>Id:</strong> {currentUser.id}
      </p>
      <p>
        <strong>Roles:</strong> {currentUser.roles}
      </p>
         
    </div>
  );
};

export default Profile;
