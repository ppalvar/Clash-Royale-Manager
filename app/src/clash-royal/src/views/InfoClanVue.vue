<script>
import WindowsInfoClan from '@/components/WindowsInfoClan.vue';
import BBDD from '@/router/BBDD';
import { isAuthenticated } from '@/auth/auth';
import EntityDefaultViews from '@/components/EntityDefaultViews.vue';
import TableInfoJugador from '@/components/TableInfoJugador.vue';
import TableInfoCarta from '@/components/TableInfoCarta.vue';

export default {
    props: {
        item: {
            type: Object,
            default: null,
        },
    },

    components: {
        EntityDefaultViews,
        TableInfoJugador,
        WindowsInfoClan,
        TableInfoCarta,
    },

    data() {
        return {
            isAuthenticated
        }
    },

    methods: {
        seeCarts() {
            return BBDD.getAllCarts()
        },

        seeMembers() {
            return BBDD.getMembersOfClan(this.item.id)
        },

        seeInfo(id, type) {
            this.$emit('info', id, type)
        },
    },
}
</script>

<template>
    <WindowsInfoClan :nombre=item.nombre :descripcion=item.descripcion :trofeos=item.trofeos :region=item.region
        :miembros=item.miembros :condicion=item.condicion :minimalice="true" />

    <EntityDefaultViews>
        <template #heard>
            <h2>Miembros</h2>
        </template>

        <template #botonCrear>
            <label v-if="isAuthenticated()">NewMember</label>
        </template>

        <template #tabla>
            <TableInfoJugador :jugadores="seeMembers()" @info="seeInfo" />
        </template>
    </EntityDefaultViews>

    <EntityDefaultViews>
        <template #heard>
            <h2>Cartas Donadas</h2>
        </template>

        <template #botonCrear>
            <label v-if="isAuthenticated()">NewCart</label>
        </template>

        <template #tabla>
            <TableInfoCarta :carts="seeCarts()" @info="seeInfo" />
        </template>
    </EntityDefaultViews>
</template>

<style>
.estetic-list-container {
    display: flex;
    flex-basis: calc(50%);
}
</style>