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
                id: '',
                name: '',
                numberOfPrizes: 0,
            },
        }
    },

    methods: {
        addMember() {
            this.clanes.push(this.clan)
        },

        deleteClan(index) {
            this.clanes.splice(index, 1)
        },

        readInput(name, id) {
            this.clan.name = name;
            this.clan.id = id;
        }
    },
}
</script>

<template>
    <Transition name="modal">
        <div v-if="show" class="modal-mask">
            <div class="modal-container">
                <div class="modal-header">
                    <ClanInputSugerence @input="readInput" />
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

<style>
.modal-mask {
    position: fixed;
    z-index: 9998;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.5);
    display: flex;
    transition: opacity 0.3s ease;
}

.modal-container {
    width: 36rem;
    margin: auto;
    padding: 20px 30px;
    background-color: rgba(0, 0, 0);
    border-radius: 2px;
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.33);
    transition: all 0.3s ease;
}

.modal-header h3 {
    margin-top: 0;
    color: #42b983;
}

.modal-body {
    margin: 20px 0;
    height: 20rem;
    overflow-y: scroll;
}

.modal-default-button {
    margin-left: 17rem;
}

.modal-enter-from {
    opacity: 0;
}

.modal-leave-to {
    opacity: 0;
}

.add-member {
    padding: 6px;
    margin-left: 3%;
}

.modal-enter-from .modal-container,
.modal-leave-to .modal-container {
    -webkit-transform: scale(1.1);
    transform: scale(1.1);
}
</style>

<style scoped>
.players-table td {
    cursor: auto;
}
</style>