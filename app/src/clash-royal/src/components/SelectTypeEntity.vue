<template>
    <select class="search-entity" v-model="value" :onchange="$emit('search-entity', value)">
        <option :value="player">Jugadores</option>
        <option :value="cart">Cartas</option>
        <option :value="clan">Clanes</option>
    </select>
</template>

<script>
import consts from '../router/auth'

export default {
    data() {
        return {
            player: consts.typeEntity.player,
            cart: consts.typeEntity.cart,
            clan: consts.typeEntity.clan,
            value: '',
        }
    },

    mounted(){
        this.value = this.player
    },
}
</script>

<style>
.search-entity {
    display: flex;
    padding: 8px;
    widows: 15%;
    border-radius: 8px;
    position: absolute;
    right: 10px;
    top: 0px;
}
</style>