<script>
import EntityDefaultViews from '../components/EntityDefaultViews.vue'
import consts from '../router/auth'
import RouterLink from 'vue-router'
import TableInfoMazo from '@/components/TableInfoMazo.vue'

export default {
    props: {
        minimalice: {
            type: Boolean,
            default: false,
        },
    },

    components: {
        EntityDefaultViews,
        TableInfoMazo,
        RouterLink,
    },

    data() {
        return {
            auth: consts.auth,
        }
    },

    methods: {
        seeInfo(id) {
            this.$emit('info', id, consts.typeEntity.cart)
        },
    },
}
</script>

<template>
    <EntityDefaultViews>
        <template #miniNavbar>
            <RouterLink to="/carta">Cartas</RouterLink> | 
            <RouterLink to="/mazo">Mazos</RouterLink>
        </template>

        <template #botonCrear>
            <h2 v-if="auth && !minimalice">CrearMazo</h2>
        </template>

        <template #tabla>
            <TableInfoMazo  @info="seeInfo" />
        </template>
    </EntityDefaultViews>
</template>

<style scoped>
.navbar a {
  display: inline-block;
  color: #f2f2f2;
  text-align: center;
  padding: 5px 7px;
  text-decoration: none;
  font-weight: bold;
  transition: all 0.3s;
}
</style>