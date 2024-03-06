<script>
import SearchBox from '@/components/SearchBox.vue';
import WindowsInfoCarta from '@/components/WindowsInfoCarta.vue';
import WindowsInfoClan from '@/components/WindowsInfoClan.vue';
import WindowsInfoJugador from '@/components/WindowsInfoJugador.vue';
import TableInfoCarta from '@/components/TableInfoCarta.vue';
import TableInfoJugador from '@/components/TableInfoJugador.vue';
import PaginacionItem from '@/components/PaginacionItem.vue';
import BBDD from '@/router/BBDD';

export default {
    props: {
        item: {
            type: Object,
            default: null,
        },
    },

    components: {
        WindowsInfoJugador,
        WindowsInfoCarta,
        WindowsInfoClan,
        SearchBox,
        TableInfoCarta,
        TableInfoJugador,
        PaginacionItem,
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
    <div v-if="item.region" class="contener-info">
        <WindowsInfoClan :nombre=item.nombre :descripcion=item.descripcion :trofeos=item.trofeos :region=item.region
            :miembros=item.miembros :condicion=item.condicion :minimalice="true" />

        <div class="estetic-list-container">
            <div class="info-list-container">
                <SearchBox />
                <TableInfoJugador @info="seeInfo" :jugadores="seeMembers()" :minimalice="true" />
                <PaginacionItem />
            </div>

            <div class="info-list-container">
                <SearchBox />
                <TableInfoCarta @info="seeInfo" :carts="seeCarts()" :minimalice="true" />
                <PaginacionItem />
            </div>
        </div>
    </div>
    <div v-else-if="item.costo" class="contener-info">
        <WindowsInfoCarta :nombre=item.nombre :descripcion=item.descripcion :costo=item.costo :calidad=item.calidad
            :minimalice="true" />
    </div>
    <div v-else-if="item.apodo" class="contener-info">
        <WindowsInfoJugador :apodo=item.apodo :nivel=item.nivel :victorias=item.victorias :cartas=item.cartas
            :trofeos=item.trofeos :racha=item.racha />

        <div class="info-list-container">
            <SearchBox />
            <TableInfoCarta @info="seeInfo" :carts="seeCarts()" :minimalice="true" />
            <PaginacionItem />
        </div>
    </div>
</template>

<style>
.info-list-container {
    background-color: rgba(0, 0, 0, 0.75);
    padding: 20px;
    border-radius: 15px;
    margin: 30px auto;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.5);
    max-width: 80%;
}

.estetic-list-container {
    display: flex;
    flex-basis: calc(50%);
}
</style>