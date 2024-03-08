<script>
import { RouterLink } from 'vue-router'
import consts from '../router/auth'

export default {
  components: {
    RouterLink,
  },

  methods: {
    authValue() {
      return consts.auth
    },
  },
}
</script>

<template>
  <div class="navbar">
    <div>
      <img src="../assets/clash-royale-icon.png" alt="Clash Royale Icon">
    </div>
    <RouterLink to="/">Inicio</RouterLink>
    <RouterLink to="/carta">Cartas</RouterLink>
    <RouterLink to="/jugador">Jugadores</RouterLink>
    <RouterLink to="/clan">Clan</RouterLink>
    <RouterLink to="/login" v-if="!authValue()">Entrar como administrador</RouterLink>
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

.navbar img {
  height: 50px;
  width: 150px;
  margin-right: 20px;
}

.navbar a:hover {
  border-radius: 5%;
  background-color: #8e44ad;
  color: white;
}
</style>
  