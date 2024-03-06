<template>
    <WindowsInfo :oneColumn=false>
        <template #entity>
            <h2>Clan</h2>
        </template>
        <template #column1>
            <div class="detail">
                <h3>Nombre del Clan</h3>
                <p class="clan-name"> {{ nombre }} </p>
            </div>
            <div class="detail">
                <h3>Descripción</h3>
                <p class="clan-description"> {{ descripcion }} </p>
            </div>
        </template>
        <template #column2>
            <div class="detail">
                <h3>Número de Trofeos en Guerras</h3>
                <p class="clan-trophies-in-wars"> {{ trofeos }} </p>
            </div>
            <div class="detail">
                <h3>Número de Miembros</h3>
                <p class="clan-members"> {{ miembros }} </p>
            </div>
            <div class="detail">
                <h3>Trofeos Necesarios para Entrar</h3>
                <p class="clan-trophies-to-enter"> {{ condicion }} </p>
            </div>
            <div class="detail">
                <h3>Región</h3>
                <p class="clan-region"> {{ region }} </p>
            </div>
        </template>
    </WindowsInfo>
</template>

<script>
import WindowsInfo from "../components/WindowsInfo.vue"

export default {
    props:{
        nombre: {
            type: String,
            default: '',
        },
        descripcion: {
            type: String,
            default: '',
        },
        trofeos: {
            type: Number,
            default: 0,
        },
        region: {
            type: String,
            default: '',
        },
        miembros: {
            type: Number,
            default: 0,
        },
        condicion: {
            type: Number,
            default: 0,
        },
    },

    components: {
        WindowsInfo,
    },
}
</script>