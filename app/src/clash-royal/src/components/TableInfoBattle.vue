<template>
    <TableInfo>
        <template #thead>
            <th>Jugador 1</th>
            <th>Resultados</th>
            <th>Jugador 2</th>
            <th>Cantidad de Trofeos</th>
            <th v-if="edit">Acciones</th>
        </template>

        <template #tbody>
            <tr v-for="(battle, index) in battles" :key="index">
                <td> {{ battle.player1 }} </td>
                <td v-if="battle.battle.winner"> 0 - 1 </td>
                <td v-else> 1 - 0 </td>
                <td> {{ battle.player2 }} </td>
                <td> {{ battle.battle.numberOfTrophies }} </td>
                <td class="actions" v-if="edit">
                    <img height="20px" :src="Details" @click="$emit('info', battle.battle.player1Id, battle.battle.date)"/>
                    <img v-if="isUserAuthenticated" height="20px" :src="Edit" @click="$emit('edit', battle.battle.player1Id, battle.battle.date)"/>
                    <img v-if="isUserAuthenticated" height="20px" :src="Delete" @click="$emit('delete', battle.battle.player1Id, battle.battle.date)"/>
                </td>
            </tr>
        </template>
    </TableInfo>
</template>

<script>
import TableInfo from '@/components/TableInfo.vue';
import Edit from '@/assets/svg/edit.svg';
import Delete from '@/assets/svg/delete.svg';
import Details from '@/assets/svg/details.svg';
import { isAuthenticated } from '@/auth/auth';

export default {
    props: {
        battles: [],
        edit: {
            type: Boolean,
            default: true,
        },
    },

    components: {
        TableInfo,
    },

    data() {
        return {
            Edit,
            Delete,
            Details,
        }
    },

    computed: {
        isUserAuthenticated() {
            return isAuthenticated();
        }
    },
}
</script>

<style scoped>
.actions {
    display: flex;
    justify-content: space-around;
    width: 100%;
}

</style>