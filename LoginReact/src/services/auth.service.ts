import axios from "axios";

const API_URL = "http://localhost:4000/authenticate/";

export const register = (username: string, roles: string, password: string) => {
  return axios.post(API_URL + "register", {
    username,
    roles,
    password,
  });
};

export const login = (username: string, password: string) => {
  return axios
    .post(API_URL + "login", {
      username,
      password,
    })
    .then((response) => {
      if (response.data.token) {
        localStorage.setItem("token", JSON.stringify(response.data));
      }

      return response.data;
    });
};

export const getCurrentUser = () => {
  const userStr = localStorage.getItem("username");
  if (userStr) return JSON.parse(userStr);

  return null;
};
