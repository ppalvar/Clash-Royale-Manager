<template>
    <TableInfo>
        <template #thead>
            <th>Nombre</th>
            <th v-if="!minimalice">Descripcion</th>
            <th v-if="!minimalice">Trofeos de guerra</th>
            <th>Region</th>
            <th>Miembros</th>
            <th v-if="!minimalice">Trofeos para entrar</th>
            <!-- <th v-if="isUserAuthenticated">Acciones</th> -->
        </template>
        <template #tbody>
            <tr v-for="clan in clanes" :key="clan.id" @click="$emit('info', clan.id, type)">
                <td> {{ clan.name }} </td>
                <td v-if="!minimalice"> {{ clan.description }} </td>
                <td v-if="!minimalice"> {{ clan.numberOfTrophiesObtainedInWars }} </td>
                <td> {{ clan.region }} </td>
                <td> {{ clan.numberOfMembers }} </td>
                <td v-if="!minimalice"> {{ clan.condicion }} </td>
                <!-- <td v-if="isUserAuthenticated">aqui van botones</td> -->
            </tr>
        </template>
    </TableInfo>
</template>

<script>
import TableInfo from '@/components/TableInfo.vue';
import { isAuthenticated } from '@/auth/auth';

export default {
    props: {
        clanes: [],
        minimalice: {
            type: Boolean,
            default: false,
        },
    },

    components: {
        TableInfo,
    },

    computed: {
        isUserAuthenticated() {
            return isAuthenticated();
        }
    },

}
</script>