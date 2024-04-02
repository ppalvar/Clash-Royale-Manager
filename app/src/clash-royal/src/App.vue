<script>
import NavBar from './components/NavBarItem.vue'
import RouterView from 'vue-router'
import BBDD from '@/router/BBDD'
import consts from './router/auth'

export default {
  components: {
    NavBar,
    RouterView,
  },

  data() {
    return {
      item: null,
    }
  },

  methods: {
    seeInfoItem(id, type) {
      if (type == consts.typeEntity.player) {
        this.item = BBDD.getJugador(id)
      }
      else if (type == consts.typeEntity.cart) {
        this.item = BBDD.getCart(id)
      }
      else {
        this.item = BBDD.getClan(id)
      }
      
      this.$router.push('/info')
    },
  },
}
</script>

<template>
  <NavBar />
  <RouterView @info="seeInfoItem" :item=item />
</template>

<style>
/* Estilos generales */
body {
  background-image: url('./assets/wallpaper_site.jpg');
  background-size: cover;
  background-attachment: fixed;
  font-family: 'Baloo Tamma 2', cursive;
  /* background-color: #0e1012; */
  /* font-family: 'Lato', sans-serif; */
  color: #d1d2d3;
  margin: 0;
  padding: 0;
}

button {
  background-color: #e76f51;
  color: white;
  border: none;
  padding: 10px 15px;
  margin: 5px;
  border-radius: 5px;
  cursor: pointer;
  font-weight: bold;
}

button:hover {
  background-color: #f4a261;
}

input, textarea {
  width: calc(100% - 22px);
  padding: 10px;
  margin: 5px 0;
  border-radius: 5px;
  border: 1px solid #e76f51;
  background-color: #264653;
  color: white;
}

form {
  display: flex;
  flex-direction: column;
  max-width: 400px;
  margin: auto;
}
</style>
