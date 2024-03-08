<script>
import EntityDefaultViews from '../components/EntityDefaultViews.vue'
import BBDD from '../router/BBDD'
import consts from '../router/auth'
import TableInfoClan from '@/components/TableInfoClan.vue'

export default {
    props: {
        minimalice: {
            type: Boolean,
            default: false,
        },
    },

    components: {
        EntityDefaultViews,
        TableInfoClan,
    },

    data() {
        return {
            auth: consts.auth,
        }
    },

    methods: {
        seeInfo(id) {
            this.$emit('info', id, consts.typeEntity.clan)
        },

        seeEntity() {
            return BBDD.getAllClanes()
        },
    },
}
</script>

<template>
    <EntityDefaultViews>
        <template #botonCrear>
            <h2 v-if="auth && !minimalice">CrearClan</h2>
        </template>

        <template #tabla>
            <TableInfoClan :clanes="seeEntity()" :minimalice="minimalice" @info="seeInfo" />
        </template>
    </EntityDefaultViews>
</template>