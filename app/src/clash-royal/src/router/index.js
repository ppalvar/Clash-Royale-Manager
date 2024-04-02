import { createRouter, createWebHistory } from "vue-router";
import { isAuthenticated, logout } from "@/auth/auth";
import Home from "@/views/HomeVue.vue";
import Login from "@/views/LoginVue.vue";
import Register from "@/views/RegisterVue.vue";
import InfoCarta from "@/views/InfoCartaVue.vue";
import InfoClan from "@/views/InfoClanVue.vue";
import InfoJugador from "@/views/InfoJugadorVue.vue";
import Cartas from "@/views/CartasVue.vue";
import Jugadores from "@/views/JugadoresVue.vue";
import Clanes from "@/views/ClanesVue.vue";
import PerfilVue from "@/views/PerfilVue.vue";
import CrearJugador from "@/components/CrearJugador.vue";
import CrearCarta from "@/components/CrearCarta.vue";
import CrearBattle from "@/components/CrearBattle.vue";
import EditarCarta from "@/components/EditarCarta.vue";
import EditarJugador from "@/components/EditarJugador.vue";
import BattlesVue from "@/views/BattlesVue.vue";
import TableInfoUsers from "@/components/TableInfoUsers.vue";
import CrearClan from "@/components/CrearClan.vue";
import InfoBatalla from "@/views/InfoBatallaVue.vue";
import EditarClan from "@/components/EditarClan.vue";
import EditarBatalla from "@/components/EditarBatalla.vue";
import ListChallenges from "@/views/ListChallenges.vue";
import CreateChallenge from "@/views/CreateChallenge.vue";
import EditChallenge from "@/views/EditChallenge.vue";
import InfoChallenge from "@/views/InfoChallenge.vue";
import Wars from "@/views/WarsVue.vue";
import CrearWar from "@/components/CrearWar.vue";
import ListRegions from "@/views/ListRegions.vue";

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
      location.reload();
    },
    meta: { requiresAuth: true }
  },
  {
    path: '/login',
    name: 'Login',
    component: Login,
  },
  {
    path: '/register',
    name: 'Register',
    component: Register,
  },
  {
    path: '/users',
    name: 'Users',
    component: TableInfoUsers,
    meta: { requiresAuth: true }
  },
  {
    path: '/perfil',
    name: 'Perfil',
    component: PerfilVue,
    meta: { requiresAuth: true }
  },
  {
    path: '/carta',
    name: 'Carta',
    component: Cartas,
  },
  {
    path: '/battle',
    name: 'Battles',
    component: BattlesVue,
  },
  {
    path: '/add-battle',
    name: 'AddBattle',
    component: CrearBattle,
    meta: { requiresAuth: true }
  },
  {
    path: '/add-player',
    name: 'AddJugador',
    component: CrearJugador,
    meta: { requiresAuth: true }
  },
  {
    path: '/jugador',
    name: 'Jugador',
    component: Jugadores,
  },
  {
    path: '/edit-player/:playerId',
    name: 'EdiPlayer',
    component: EditarJugador,
    props: true,
    meta: { requiresAuth: true }
  },
  {
    path: '/add-clan',
    name: 'AddClan',
    component: CrearClan,
    meta: { requiresAuth: true }
  },
  {
    path: '/clan',
    name: 'Clan',
    component: Clanes,
  },
  {
    path: '/challenge',
    name: 'Challenge',
    component: ListChallenges,
  },
  {
    path: '/region',
    name: 'Regions',
    component: ListRegions,
  },
  {
    path: '/add-challenge',
    name: 'CrearChallenge',
    component: CreateChallenge,
  },
  {
    path: '/edit-challenge/:id',
    name: 'EditChallenge',
    component: EditChallenge,
    props: true,
  },
  {
    path: '/info-challenge/:id',
    name: 'InfoChallenge',
    component: InfoChallenge,
    props: true,
  },
  {
    path: '/info-carta/:cardId',
    name: 'InfoCarta',
    component: InfoCarta,
    props: true,
  },
  {
    path: '/info-clan/:clanId',
    name: 'InfoClan',
    component: InfoClan,
    props: true,
  },
  {
    path: '/info-jugador/:playerId',
    name: 'InfoJugador',
    component: InfoJugador,
    props: true,
  },
  {
    path: '/info-battle/:playerId/:date',
    name: 'InfoBattle',
    component: InfoBatalla,
    props: true,
  },
  {
    path: '/edit-battle/:playerId/:date',
    name: 'EditBattle',
    component: EditarBatalla,
    props: true,
  },
  {
    path: '/add-card',
    name: 'AddCard',
    component: CrearCarta,
    meta: { requiresAuth: true }
  },
  {
    path: '/edit-card/:cardId',
    name: 'EditCard',
    component: EditarCarta,
    props: true,
    meta: { requiresAuth: true }
  },
  {
    path: '/edit-clan/:clanId',
    name: 'EditClan',
    component: EditarClan,
    props: true,
    meta: { requiresAuth: true }
  },
  {
    path: '/war',
    name: 'War',
    component: Wars,
  },
  {
    path: '/add-war',
    name: 'AddWar',
    component: CrearWar,
    meta: { requiresAuth: true }
  },
  {
    path: '/edit-war/:warId',
    name: 'EditWar',
    component: EditarCarta,
    props: true,
    meta: { requiresAuth: true }
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
