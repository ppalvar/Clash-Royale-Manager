<template>
    <TableInfo>
        <template #thead>
            <th>Nombre</th>
            <th v-if="!minimalice">Descripcion</th>
            <th v-if="!minimalice">Trofeos de guerra</th>
            <th>Region</th>
            <th>Miembros</th>
            <th v-if="!minimalice">Trofeos para entrar</th>
            <th v-if="auth && !minimalice">Acciones</th>
        </template>
        <template #tbody>
            <tr v-for="clan in clanes" :key="clan.id" @click="$emit('info', clan.id, type)">
                <td> {{ clan.nombre }} </td>
                <td v-if="!minimalice"> {{ clan.descripcion }} </td>
                <td v-if="!minimalice"> {{ clan.trofeos }} </td>
                <td> {{ clan.region }} </td>
                <td> {{ clan.miembros }} </td>
                <td v-if="!minimalice"> {{ clan.condicion }} </td>
                <td v-if="auth && !minimalice">aqui van botones</td>
            </tr>
        </template>
    </TableInfo>
</template>

<script>
import TableInfo from '@/components/TableInfo.vue';
import consts from '../router/auth'

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

    data() {
        return {
            type: consts.typeEntity.clan,
            auth: consts.auth,
        }
    },
}
</script>