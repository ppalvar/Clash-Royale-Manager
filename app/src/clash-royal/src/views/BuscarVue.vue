<script>
import SearchItem from '@/components/SearchItem.vue';
import TableInfoCarta from '@/components/TableInfoCarta.vue';
import TableInfoClan from '@/components/TableInfoClan.vue'
import TableInfoJugador from '@/components/TableInfoJugador.vue';
import PaginacionItem from '@/components/PaginacionItem.vue';
import BBDD from '../router/BBDD'
import consts from '../router/auth'

export default {
  components: {
    SearchItem,
    TableInfoCarta,
    TableInfoClan,
    TableInfoJugador,
    PaginacionItem,
  },

  data() {
    return {
      type: '',
      player: consts.typeEntity.player,
      cart: consts.typeEntity.cart,
      clan: consts.typeEntity.clan,
    }
  },

  methods: {
    seeType(type) {
      this.type = type
    },

    seeInfo(id, type) {
      this.$emit('info', id, type)
    },

    seeEntity() {
      if (this.type == this.cart) {
        return BBDD.getAllCarts()
      }
      else if (this.type == this.player) {
        return BBDD.getAllJugadores()
      }
      else {
        this.seeCarts = this.seePlayer = false
        return BBDD.getAllClanes()
      }
    },
  },
}
</script>

<template>
  <div class="players-list-container">
    <SearchItem @search-entity="seeType" />
    <TableInfoCarta v-if="type == cart" @info="seeInfo" :carts="seeEntity()" :minimalice="false" />
    <TableInfoJugador v-else-if="type == player" @info="seeInfo" :jugadores="seeEntity()" :minimalice="false" />
    <TableInfoClan v-else @info="seeInfo" :clanes="seeEntity()" :minimalice="false" />
    <PaginacionItem />
  </div>
</template>

<style>
.players-list-container {
  background-color: rgba(0, 0, 0, 0.75);
  padding: 20px;
  border-radius: 15px;
  margin: 30px auto;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.5);
  max-width: 90%;
}
</style>
