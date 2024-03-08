<script>
import EntityDefaultViews from '../components/EntityDefaultViews.vue'
import BBDD from '../router/BBDD'
import consts from '../router/auth'
import TableInfoCarta from '@/components/TableInfoCarta.vue'

export default {
    props: {
        minimalice: {
            type: Boolean,
            default: false,
        },
    },

    components: {
        EntityDefaultViews,
        TableInfoCarta,
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

        seeEntity() {
            return BBDD.getAllCarts()
        },
    },
}
</script>

<template>
    <EntityDefaultViews>
        <template #botonCrear>
            <h2 v-if="auth && !minimalice">CrearCart</h2>
        </template>

        <template #tabla>
            <TableInfoCarta :carts="seeEntity()" :minimalice="minimalice" @info="seeInfo" />
        </template>
    </EntityDefaultViews>
</template>