import { createRouter, createWebHistory } from "vue-router"
import { isAuthenticated, logout } from "@/auth/auth";
import Home from "@/views/HomeVue.vue"
import Login from "@/views/LoginVue.vue"
import InfoCarta from "@/views/InfoCartaVue.vue"
import InfoClan from "@/views/InfoClanVue.vue"
import InfoJugador from "@/views/InfoJugadorVue.vue"
import Crear from "@/views/CrearVue.vue"
import Cartas from "@/views/CartasVue.vue"
import Jugadores from "@/views/JugadoresVue.vue"
import Clanes from "@/views/ClanesVue.vue"

const routes = [
    {
        path: '/',
        name: 'Home',
        component: Home,
    },
    {
      path: "/logout",
      name: "Logout",
      beforeEnter: (to, from, next) => {
        logout();
        next('/login');
      },
      meta: { requiresAuth: true }
    },
    {
        path: '/login',
        name: 'Login',
        component: Login,
    },
    {
        path: '/crear',
        name: 'Crear',
        component: Crear,
    },
    {
        path: '/carta',
        name: 'Carta',
        component: Cartas,
    },
    {
        path: '/jugador',
        name: 'Jugador',
        component: Jugadores,
    },
    {
        path: '/clan',
        name: 'Clan',
        component: Clanes,
    },
    {
        path: '/info-carta',
        name: 'InfoCarta',
        component: InfoCarta,
    },
    {
        path: '/info-clan',
        name: 'InfoClan',
        component: InfoClan,
    },
    {
        path: '/info-jugador',
        name: 'InfoJugador',
        component: InfoJugador,
    },
]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes
})

router.beforeEach((to, from, next) => {
    if (to.matched.some(record => record.meta.requiresAuth)) {
      // esta ruta requiere autenticación, comprobar si el usuario está autenticado
      // si no, redirigir a la página de inicio de sesión.
      if (!isAuthenticated()) {
        next({
          path: '/login',
          query: { redirect: to.fullPath }
        })
      } else {
        next()
      }
    } else if (to.matched.some(record => record.meta.guest)) {
      // esta ruta solo está disponible para usuarios no autenticados
      // si el usuario está autenticado, redirigir a la página de inicio
      if (isAuthenticated()) {
        next({
          path: '/',
          query: { redirect: to.fullPath }
        })
      } else {
        next()
      }
    } else {
      next()
    }
  })

export default router
