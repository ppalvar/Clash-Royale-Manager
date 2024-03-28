<template>
    <WindowsInfo :oneColumn=false>
        <template #entity>
            <h2>Batalla</h2>
        </template>
        <template #column1>
            <div class="detail">
                <h3>Jugador1</h3>
                <p class="clan-name"> {{ jugador1 }} </p>
            </div>
            <div class="detail">
                <h3>Ganador</h3>
                <p class="clan-trophies-in-wars"> {{ seeGanador() }} </p>
            </div>
            <div class="detail">
                <h3>Fecha</h3>
                <p class="clan-trophies-in-wars"> {{ date }} </p>
            </div>
        </template>
        <template #column2>
            <div class="detail">
                <h3>Jugador2</h3>
                <p class="clan-description"> {{ jugador2 }} </p>
            </div>
            <div class="detail">
                <h3>Trofeos</h3>
                <p class="clan-trophies-to-enter"> {{ trofeos }} </p>
            </div>
            <div class="detail">
                <h3>Duracion</h3>
                <p class="clan-region"> {{ duracion }} </p>
            </div>
        </template>
    </WindowsInfo>
</template>

<script>
import WindowsInfo from "@/components/WindowsInfo.vue"

export default {
    props:{
        jugador1: {
            type: Object,
            default: null,
        },
        jugador2: {
            type: Object,
            default: null,
        },
        winner: {
            type: Boolean,
            default: false,
        },
        trofeos: {
            type: Number,
            default: 0,
        },
        date: {
            type: Date,
            default: new Date(),
        },
        duracion: {
            type: Number,
            default: 0,
        },
    },

    components: {
        WindowsInfo,
    },

    methods: {
        seeGanador() {
            return this.winner ? this.jugador2 : this.jugador1;
        },
    },
}
</script>