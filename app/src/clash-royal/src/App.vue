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
body {
  background-image: url('./assets/clash_royale.jpg');
  background-size: cover;
  background-attachment: fixed;
  font-family: 'Baloo Tamma 2', cursive;
  color: white;
  margin: 0;
  padding: 0;
}
</style>
