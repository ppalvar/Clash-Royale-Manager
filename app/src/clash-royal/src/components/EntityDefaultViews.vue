<script>
import SearchBox from '../components/SearchBox.vue'
import TableInfo from '../components/TableInfo.vue'
import PaginacionItem from '@/components/PaginacionItem.vue'

export default {
  components: {
    SearchBox,
    TableInfo,
    PaginacionItem,
  },
}
</script>

<template>
  <div class="players-list-container">
    <SearchBox />

    <div class="seccionCrear">
      <slot name="botonCrear"></slot>
    </div>

    <slot name="tabla">
      <TableInfo />
    </slot>

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

.seccionCrear {
  width: 15%;
  display: inline-block;
  padding: 10px;
}
</style>