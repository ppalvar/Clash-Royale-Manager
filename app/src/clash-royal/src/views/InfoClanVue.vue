<script>
import WindowsInfoClan from '@/components/WindowsInfoClan.vue';
import CartasVue from '@/views/CartasVue.vue';
import JugadoresVue from '@/views/JugadoresVue.vue';
import BBDD from '@/router/BBDD';

export default {
    props: {
        item: {
            type: Object,
            default: null,
        },
    },

    components: {
        JugadoresVue,
        WindowsInfoClan,
        CartasVue,
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

    <div class="estetic-list-container">
        <JugadoresVue :minimalice="true" :jugadores="seeMembers()" @info="seeInfo" />

        <CartasVue @info="seeInfo" :carts="seeCarts()" :minimalice="true" />
    </div>
</template>

<style>
.estetic-list-container {
    display: flex;
    flex-basis: calc(50%);
}
</style>