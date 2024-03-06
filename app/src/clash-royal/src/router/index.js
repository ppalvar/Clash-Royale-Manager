import { createRouter, createWebHistory } from "vue-router";
import Home from "@/views/HomeVue.vue"
import Buscar from "@/views/BuscarVue.vue"
import Login from "@/views/LoginVue.vue"
import InfoVue from "@/views/InfoVue.vue";

const routes = [
    {
        path: '/',
        name: 'Home',
        component: Home,
    },
    {
        path: '/buscar',
        name: 'Buscar',
        component: Buscar,
    },
    {
        path: '/login',
        name: 'Login',
        component: Login,
    },{
        path: '/info',
        name: 'Info',
        component: InfoVue,
    },
]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes
})

export default router
