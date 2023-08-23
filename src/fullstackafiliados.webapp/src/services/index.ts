import axios from "axios";

export const apiFullstackAfiliados = axios.create({
    baseURL: "https://localhost:7097/api/"
});