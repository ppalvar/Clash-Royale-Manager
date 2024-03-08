<template>
    <TableInfo>
        <template #thead>
            <th>Nombre</th>
            <th v-if="!minimalice">Descripcion</th>
            <th>Costo de elixir</th>
            <th>Calidad</th>
            <th v-if="auth && !minimalice">Acciones</th>
        </template>

        <template #tbody>
            <tr v-for="cart in carts" :key="cart.id" @click="$emit('info', cart.id, type)">
                <td> {{ cart.nombre }} </td>
                <td v-if="!minimalice"> {{ cart.descripcion }} </td>
                <td> {{ cart.costo }} </td>
                <td> {{ cart.calidad }} </td>
                <td v-if="auth && !minimalice">aqui van botones</td>
            </tr>
        </template>
    </TableInfo>
</template>

<script>
import TableInfo from '@/components/TableInfo.vue'
import consts from '../router/auth'

export default {
    props: {
        carts: [],
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
            type: consts.typeEntity.cart,
            auth: consts.auth,
        }
    },
}
</script>