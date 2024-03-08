import { createApp } from "vue";
import App from "./App.vue";
import axios from 'axios';
import auth from "./auth/auth";
import router from "./router/index";

const appInstance = createApp(App);
appInstance.use(auth);
appInstance.use(router);
appInstance.mount("#app");

axios.interceptors.request.use(
    config => {
        const token = localStorage.getItem('user-token');
        if (token) {
            config.headers.Authorization = 'Bearer ' + token;
        }
        return config;
    },
    error => {
        return Promise.reject(error);
    }
);