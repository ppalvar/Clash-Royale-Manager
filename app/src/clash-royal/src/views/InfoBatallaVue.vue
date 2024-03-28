<script>
import WindowsInfoBatalla from '@/components/WindowsInfoBatalla.vue';

export default {
    props: {
        item: {
            type: Object,
            default: null,
        },
    },

    components: {
        WindowsInfoBatalla,
    },
}
</script>

<template>
    <WindowsInfoBatalla :jugador1=item.jugador1 :jugador2=item.jugador2 :winner=item.winner :trofeos=item.trofeos
        :date=item.date :duracion=item.duracion :minimalice="true" />

    <div class="estetic-list-contener">
        <div class="jugadores-contener" @click="$emit('info', id1, type)">
            <h2>Jugador1</h2>
        </div>

        <div class="jugadores-contener" @click="$emit('info', id2, type)">
            <h2>Jugador2</h2>
        </div>
    </div>
</template>

<style>
.estetic-list-contener {
    display: flex;
    flex-basis: calc(50%);
}

.jugadores-contener {
    background-color: rgba(0, 0, 0, 0.75);
    padding: 0px 6px;
    border-radius: 10px;
    margin: 30px auto;
    cursor: pointer;
    text-align: center;
    color: #ffde00;
}

.jugadores-contener:hover {
    background-color: #f1c20875;
}
</style>