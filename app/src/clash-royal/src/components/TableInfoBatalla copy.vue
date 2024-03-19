<template>
    <TableInfo>
        <template #thead>
            <th>Jugador1</th>
            <th>Jugador2</th>
            <th>Ganador</th>
            <!-- <th v-if="!minimalice">Trofeos</th>
            <th v-if="!minimalice">Fecha</th>
            <th v-if="!minimalice">Duracion</th> -->
            <th v-if="auth && !minimalice">Acciones</th>
        </template>

        <template #tbody>
            <tr v-for="(battle,index) in seeBatallas()" :key="index" @click="seeInfo(index)">
                <td> {{ battle.player1 }} </td>
                <td> {{ battle.player2 }} </td>
                <td> {{ battle.winner }} </td>
                <!-- <td v-if="!minimalice"> {{ battle.trofeos }} </td>
                <td v-if="!minimalice"> {{ battle.fecha }} </td>
                <td v-if="!minimalice"> {{ battle.duracion }} </td> -->
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
        batallas: [],
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
            auth: consts.auth,
        }
    },

    methods: {
        seeBatallas() {
            let batallasVue = []

            this.batallas.forEach(battle => {
                batallasVue.push({
                    player1: battle.jugador1.apodo,
                    player2: battle.jugador2.apodo,
                    winner: battle.winner ? battle.jugador2.apodo : battle.jugador1.apodo,
                    trofeos: battle.trofeos,
                    date: battle.date,
                    duracion: battle.duracion,
                })
            });

            return batallasVue
        },

        seeInfo(index) {
            const player1 = this.batallas[index].id
            const date = this.batallas[index].date
            this.$emit('infobatalla', player1, date)
        },
    },
}
</script>