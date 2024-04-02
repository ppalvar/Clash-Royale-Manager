<script>
import PaginacionItem from '@/components/PaginacionItem.vue';
// import SearchBox from '../components/SearchBox.vue';
import TableInfo from '../components/TableInfo.vue';
import { isAuthenticated } from '@/auth/auth';

export default {
  props: {
    url: {
      type: String,
      default: ''
    },
    page: {
      type: Number,
      default: 1
    },
    totalPage: {
      type: Number,
      default: 1
    }
  },
  components: {
    // SearchBox,
    TableInfo,
    PaginacionItem,
  },

  computed: {
      isUserAuthenticated() {
          return isAuthenticated();
      }
  },

  data() {
    return {
      AddItem: require("@/assets/svg/add-square.svg"),
    }
  },

  methods: {
    async toRoute() {
      await this.$router.push(this.url);
      location.reload();
    },

    goTo(page) {
      this.$emit('goto', page);
    }
  }
}
</script>

<template>
  
  <div class="players-list-container">
    <slot name="head"></slot>
    
    <div class="table-header">
      <!-- <SearchBox /> -->
      
      <div 
        v-if="isUserAuthenticated" 
        class="btn-add"
        @click.prevent="toRoute()"
      >
        <b>Agregar</b>
      </div>
    </div>
    
    <slot name="tabla">
      <TableInfo />
    </slot>

    <PaginacionItem :page="page" :totalPage="totalPage" @goto-page="goTo"/>
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

.table-header {
  display: flex;
  justify-content: space-evenly; /* Distribuye los elementos horizontalmente */
  align-items: center; /* Alinea verticalmente los elementos */
  width: 100%; /* Ocupa el 90% del ancho disponible */
  margin: 0 auto; /* Centra horizontalmente */
}

.SearchBox, .btn-add {
  flex: 1; /* Ambos elementos ocupan el mismo espacio */
  text-align: center; /* Centra el contenido dentro de cada elemento */
}

.btn-add {
  text-align: center;
  height: 1em;
  padding: 10px;
  border: solid 1px;
  background-color: #ffde00;
  border-radius: 0.5em;
  color: #121212;
  margin-left: 15px;
  margin-bottom: 15px;
  cursor: pointer;
}

.btn-add:hover {
  background-color: #f1c208dd;
}
</style>