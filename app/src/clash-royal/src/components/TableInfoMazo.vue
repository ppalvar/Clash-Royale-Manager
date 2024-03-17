<template>
    <TableInfo>
        <template #thead>
            <th>1ra</th>
            <th>2da</th>
            <th>3ra</th>
            <th>4ta</th>
            <th>5ta</th>
            <th>6ta</th>
            <th>7ma</th>
            <th>8va</th>
            <th>popularidad</th>
        </template>

        <template #tbody>
            <tr v-for="(mazo,index) in seeImagen()" :key="index">
                <td v-for="carta in mazo" :key="carta.id" @click="$emit('info', carta.id, type)">
                    <ImagenCarta />
                </td>
                <div class="popu">
                    65%
                </div>
            </tr>
        </template>
    </TableInfo>
</template>

<script>
import TableInfo from '../components/TableInfo.vue'
import ImagenCarta from './ImagenCarta.vue';
import consts from '../router/auth'
import BBDD from '@/router/BBDD';

export default {
    components: {
        TableInfo,
        ImagenCarta,
    },

    data() {
        return {
            auth: consts.auth,
            type: consts.typeEntity.cart,
        }
    },

    methods: {
        seeImagen() {
            let imagenes = []

            BBDD.getMazos().forEach(mazo => {
                imagenes.push([
                    { imagen: mazo.cart1.imagen, id: mazo.cart0.id },
                    { imagen: mazo.cart0.imagen, id: mazo.cart0.id },
                    { imagen: mazo.cart2.imagen, id: mazo.cart0.id },
                    { imagen: mazo.cart3.imagen, id: mazo.cart0.id },
                    { imagen: mazo.cart4.imagen, id: mazo.cart0.id },
                    { imagen: mazo.cart5.imagen, id: mazo.cart0.id },
                    { imagen: mazo.cart6.imagen, id: mazo.cart0.id },
                    { imagen: mazo.cart7.imagen, id: mazo.cart0.id },
                ])
            });

            return imagenes
        },
    },
}
</script>

<style scoped>
.popu {
    text-align: center;
    padding: 15px;
}

.players-table tr:hover {
    background-color: transparent;
}

.players-table td:hover {
    background-color: #f1c40844;
}

.players-table td {
    text-align: center;
    padding: 5px;
    cursor: pointer;
}

.players-table th {
    text-align: center;
    padding: 15px;
    border-bottom: 1px solid #ddd;
    background-color: #ffde00;
    color: #121212;
}
</style>