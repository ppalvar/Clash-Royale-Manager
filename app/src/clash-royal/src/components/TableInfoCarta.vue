<template>
    <TableInfo>
        <template #thead>
            <th>Nombre</th>
            <th v-if="!minimalice">Descripcion</th>
            <th>Costo de elixir</th>
            <th>Calidad</th>
            <th v-if="isUserAuthenticated">Acciones</th>
        </template>

        <template #tbody>
            <tr v-for="card in cards" :key="card.id" @click="$emit('info', card.id)">
                <td> {{ card.name }} </td>
                <td v-if="!minimalice"> {{ card.description }} </td>
                <td> {{ card.elixirCost }} </td>
                <td> {{ card.quality }} </td>
                <td v-if="isUserAuthenticated">Acciones</td>
            </tr>
        </template>
    </TableInfo>
</template>

<script>
import TableInfo from '@/components/TableInfo.vue';
import { isAuthenticated } from '@/auth/auth';

export default {
    props: {
        cards: [],
        minimalice: {
            type: Boolean,
            default: false,
        },
    },

    components: {
        TableInfo
    },

    computed: {
        isUserAuthenticated() {
            return isAuthenticated();
        }
    },
}
</script>