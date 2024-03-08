<script>
import WindowsInfoCarta from '@/components/WindowsInfoCarta.vue';

export default {
    props: {
        item: {
            type: Object,
            default: null,
        },
    },

    components: {
        WindowsInfoCarta,
    },
}
</script>

<template>
    <WindowsInfoCarta :nombre=item.nombre :descripcion=item.descripcion :costo=item.costo :calidad=item.calidad
            :minimalice="true" />
</template>