<template>
    <TableInfo>
        <template #thead>
            <th>Nombre</th>
            <th>Descripcion</th>
            <th>Costo de elixir</th>
            <th>Calidad</th>
            <th v-if="edit">Acciones</th>
        </template>

        <template #tbody>
            <tr v-for="card in cards" :key="card.id">
                <td> {{ card.name }} </td>
                <td> {{ card.description }} </td>
                <td> {{ card.elixirCost }} </td>
                <td> {{ card.quality }} </td>
                <td class="actions" v-if="edit">
                    <img height="20px" :src="Details" @click="$emit('info', card.id)"/>
                    <img v-if="isUserAuthenticated" height="20px" :src="Edit" @click="$emit('edit', card.id)"/>
                    <img v-if="isUserAuthenticated" height="20px" :src="Delete" @click="$emit('delete', card.id)"/>
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
        cards: [],
        edit: {
            type: Boolean,
            default: true,
        },
    },

    components: {
        TableInfo
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

<style scoped>
.actions {
    display: flex;
    justify-content: space-around;
    width: 100%;
}
</style>