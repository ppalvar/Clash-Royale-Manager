<script>
import EntityDefaultViews from '../components/EntityDefaultViews.vue'
import BBDD from '../router/BBDD'
import consts from '../router/auth'
import TableInfoJugador from '@/components/TableInfoJugador.vue'

export default {
    props: {
        minimalice: {
            type: Boolean,
            default: false,
        },

        jugadores: {
            default: BBDD.getAllJugadores(),
        }
    },

    components: {
        EntityDefaultViews,
        TableInfoJugador,
    },

    data() {
        return {
            auth: consts.auth,
        }
    },

    methods: {
        seeInfo(id) {
            this.$emit('info', id, consts.typeEntity.player)
        },
    },
}
</script>

<template>
    <EntityDefaultViews>
        <template #botonCrear>
            <h2 v-if="auth && !minimalice">CrearPlayer</h2>
        </template>

        <template #tabla>
            <TableInfoJugador :jugadores="jugadores" :minimalice="minimalice" @info="seeInfo" />
        </template>
    </EntityDefaultViews>
</template>