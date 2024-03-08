<template>
    <TableInfo>
        <template #thead>
            <th>Imagen</th>
            <th>Apodo</th>
            <th>Nivel</th>
            <th v-if="!minimalice">Trofeos</th>
            <th>Victorias</th>
            <th v-if="!minimalice">Cartas encontradas</th>
            <th v-if="!minimalice">Racha</th>
            <th v-if="auth && !minimalice">Acciones</th>
        </template>

        <template #tbody>
            <tr v-for="jugador in jugadores" :key="jugador.id" @click="$emit('info', jugador.id, type)">
                <ImagenConenter />
                <td> {{ jugador.apodo }} </td>
                <td> {{ jugador.nivel }} </td>
                <td v-if="!minimalice"> {{ jugador.trofeos }} </td>
                <td> {{ jugador.victorias }} </td>
                <td v-if="!minimalice"> {{ jugador.cartas }} </td>
                <td v-if="!minimalice"> {{ jugador.racha }} </td>
                <td v-if="auth && !minimalice">aqui van botones</td>
            </tr>
        </template>
    </TableInfo>
</template>

<script>
import TableInfo from '@/components/TableInfo.vue';
import ImagenConenter from './ImagenConenter.vue';
import consts from '../router/auth'

export default {
    props: {
        jugadores: [],
        minimalice: {
            type: Boolean,
            default: false,
        },
    },

    components: {
        TableInfo,
        ImagenConenter,
    },

    data() {
        return {
            type: consts.typeEntity.player,
            auth: consts.auth,
        }
    },
}
</script>

<style>
.img {
    width: 45px;
    height: 45px;
    border-radius: 50%;
    overflow-anchor: none;
}
</style>