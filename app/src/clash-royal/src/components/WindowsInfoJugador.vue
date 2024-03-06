<template>
    <WindowsInfo :oneColumn="false">
        <template #entity>
            <h2>Jugador</h2>
        </template>
        <template #column1>
            <div class="detail">
                <h3>Apodo</h3>
                <p class="clan-name"> {{ apodo }} </p>
            </div>
            <div class="detail">
                <h3>Cant. de cartas encontradas</h3>
                <p class="clan-description"> {{ cartas }} </p>
            </div>
            <div class="detail">
                <h3>Cant. de trofeos</h3>
                <p class="clan-trophies-in-wars"> {{ trofeos }} </p>
            </div>
        </template>
        <template #column2>
            <div class="detail">
                <h3>Nivel</h3>
                <p class="clan-members"> {{ nivel }} </p>
            </div>
            <div class="detail">
                <h3>Cant. de victorias</h3>
                <p class="clan-trophies-to-enter"> {{ victorias }} </p>
            </div>
            <div class="detail">
                <h3>Max. racha de trofeos</h3>
                <p class="clan-region"> {{ racha }} </p>
            </div>
        </template>
    </WindowsInfo>
</template>

<script>
import WindowsInfo from "../components/WindowsInfo.vue"

export default {
    props:{
        apodo: {
            type: String,
            default: 'Pepe',
        },
        nivel: {
            type: Number,
            default: 0,
        },
        cartas: {
            type: Number,
            default: 5,
        },
        victorias: {
            type: Number,
            default: 0,
        },
        trofeos: {
            type: Number,
            default: 0,
        },
        racha: {
            type: Number,
            default: 0,
        },
    },

    components: {
        WindowsInfo,
    },
}
</script>