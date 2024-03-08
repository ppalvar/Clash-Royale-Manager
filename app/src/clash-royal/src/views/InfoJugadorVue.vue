<script>
import CartasVue from '@/views/CartasVue.vue';
import WindowsInfoJugador from '@/components/WindowsInfoJugador.vue';
import BBDD from '@/router/BBDD';

export default {
    props: {
        item: {
            type: Object,
            default: null,
        },
    },

    components: {
        CartasVue,
        WindowsInfoJugador,
    },

    methods: {
        seeCarts() {
            return BBDD.getAllCarts()
        },

        seeInfo(id, type) {
            this.$emit('info', id, type)
        },
    },
}
</script>

<template>
    <WindowsInfoJugador :apodo=item.apodo :nivel=item.nivel :victorias=item.victorias :cartas=item.cartas
        :trofeos=item.trofeos :racha=item.racha />

    <CartasVue @info="seeInfo" :carts="seeCarts()" :minimalice="true" />
</template>