import { createRouter, createWebHistory } from "vue-router";
import { isAuthenticated, logout } from "@/auth/auth";
import Home from "@/views/HomeVue.vue";
import Buscar from "@/views/BuscarVue.vue";
import Login from "@/views/LoginVue.vue";
import InfoVue from "@/views/InfoVue.vue";

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
