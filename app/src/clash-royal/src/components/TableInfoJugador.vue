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
            <th>Acciones</th>
        </template>

        <template #tbody>
            <tr v-for="jugador in jugadores" :key="jugador.id" >
                <ImagenConenter />
                <td> {{ jugador.nickname }} </td>
                <td> {{ jugador.level }} </td>
                <td v-if="!minimalice"> {{ jugador.numberOfTrophies }} </td>
                <td> {{ jugador.numberOfWins }} </td>
                <td v-if="!minimalice"> {{ jugador.numberOfCardsFound }} </td>
                <td v-if="!minimalice"> {{ jugador.maximunTrophiesAchieved }} </td>
                <td class="actions">
                    <img height="20px" :src="Details" @click="$emit('info', jugador.id)"/>
                    <img v-if="isUserAuthenticated" height="20px" :src="Edit" @click="$emit('edit', jugador.id)"/>
                    <img v-if="isUserAuthenticated" height="20px" :src="Delete" @click="$emit('delete', jugador.id)"/>
                </td>
            </tr>
        </template>
    </TableInfo>
</template>

<script>
import TableInfo from '@/components/TableInfo.vue';
import ImagenConenter from '@/components/ImagenConenter.vue';
import Edit from '@/assets/svg/edit.svg';
import Delete from '@/assets/svg/delete.svg';
import Details from '@/assets/svg/details.svg';
import { isAuthenticated } from '@/auth/auth';

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
            Edit,
            Delete,
            Details
        }
    },

    computed: {
        isUserAuthenticated() {
            return isAuthenticated();
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