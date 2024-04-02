<script>
import { RouterLink } from 'vue-router';
import { isAuthenticated } from '@/auth/auth';

export default {
  components: {
    RouterLink,
  },
  data() {
    return {
      Perfil: require("@/assets/svg/user.svg"),
      Logout: require("@/assets/svg/logout.svg"),
      Login: require("@/assets/svg/login.svg"),
      Register: require("@/assets/svg/register.svg"),
    }
  },
  computed: {
    isUserAuthenticated() {
      return isAuthenticated();
    }
  },
}
</script>

<template>
  <div class="navbar">
    <div>
      <img class="logo" src="../assets/clash-royale-icon.png" alt="Clash Royale Icon">
    </div>
    <div class="navbar-items-left">
      <RouterLink to="/">Inicio</RouterLink>
      <RouterLink to="/carta">Cartas</RouterLink>
      <RouterLink to="/jugador">Jugadores</RouterLink>
      <RouterLink to="/battle">Batallas</RouterLink>
      <RouterLink to="/clan">Clan</RouterLink>
      <RouterLink to="/challenge">Retos</RouterLink>
      
      <RouterLink to="/users" 
        class="items-admin"
        v-show="isUserAuthenticated"
      >Usuarios</RouterLink>
    </div>
    
    <div class="navbar-items-right">
      <div v-if="isUserAuthenticated">
        <RouterLink to="/perfil">
          <img :src="Perfil" class="navbar-icon" alt="Perfil"/>
        </RouterLink>
        <RouterLink to="/logout">
          <img :src="Logout" class="navbar-icon" alt="Salir"/>
        </RouterLink>
      </div>
      <div v-else>
        <RouterLink to="/login">
          <img :src="Login" class="navbar-icon" alt="Logear"/>
        </RouterLink>
        <RouterLink to="/register">
          <img :src="Register" class="navbar-icon" alt="Registrar"/>
        </RouterLink>
      </div>
    </div>
  </div>
</template>

<style>
.navbar {
  top: 0;
  width: 100%;
  background-color: rgba(28, 28, 28, 0.8);
  overflow: hidden;
  border-radius: 5px;
  padding: 5px 0;
  text-align: center;
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.navbar a {
  display: inline-block;
  color: #f2f2f2;
  text-align: center;
  padding: 15px 20px;
  text-decoration: none;
  font-weight: bold;
  transition: all 0.3s;
}

.navbar .logo {
  height: 50px;
  width: 150px;
  margin-right: 20px;
}

.navbar a:hover {
  border-radius: 5%;
  background-color: #8e44ad;
  color: white;
}

.navbar .items-admin {
  /* border: solid; */
  /* background-color: #444ead; */
  /* font-style: unset; */
}

.navbar-icon {
  max-height: 25px;
  max-width: 25px;
  margin: auto;
}
</style>