<template>
    <CrearCarta v-if="false"/>
    <CrearJugador />
    <CrearClan v-if="false"/>
</template>

<script>
import CrearJugador from '@/components/CrearJugador.vue'
import CrearCarta from '../components/CrearCarta.vue'
import CrearClan from '../components/CrearClan.vue'

export default {
    components: {
        CrearCarta,
        CrearJugador,
        CrearClan,
    },
}
</script>