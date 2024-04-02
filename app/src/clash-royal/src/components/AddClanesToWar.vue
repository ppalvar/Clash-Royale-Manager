<script>
import TableInfo from './TableInfo.vue';
import ClanInputSugerence from './ClanInputSugerence.vue';
import Delete from '@/assets/svg/delete.svg';

export default {
    props: {
        show: {
            type: Boolean,
            default: false,
        },
    },

    components: {
        TableInfo,
        ClanInputSugerence,
    },

    data() {
        return {
            Delete,
            clanes: [],
            clan: {
                id: '2',
                name: 'Juan',
                numberOfPrizes: 0,
            },
        }
    },

    methods: {
        addMember() {
            this.clanes.push(this.clan)
        },

        deleteClan(index) {
            this.clanes.slice(index, 1)
        },
    },
}
</script>

<template>
    <Transition name="modal">
        <div v-if="show" class="modal-mask">
            <div class="modal-container">
                <div class="modal-header">
                    <ClanInputSugerence @input="member = $event" />
                    <input type="number" v-model="clan.numberOfPrizes" >
                    <button class="add-member" @click="addMember">Agregar</button>
                </div>

                <div class="modal-body">
                    <TableInfo>
                        <template #thead>
                            <th>Clan</th>
                            <th>Trofeos</th>
                            <th>Acciones</th>
                        </template>

                        <template #tbody>
                            <tr v-for="(clan, index) in clanes" :key="clan.id" class="body">
                                <td> {{ clan.name }} </td>
                                <td> {{ clan.numberOfPrizes }} </td>
                                <td>
                                    <img height="20px" :src="Delete" @click="deleteClan(index)"/>
                                </td>
                            </tr>
                        </template>
                    </TableInfo>
                </div>

                <div class="modal-footer">
                    <button class="modal-default-button" @click="$emit('close',clanes)">OK</button>
                </div>
            </div>
        </div>
    </Transition>
</template>

<style scoped>
.players-table td {
    cursor: auto;
}
</style>