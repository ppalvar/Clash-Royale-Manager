<script>
import TableInfo from './TableInfo.vue';
import SearchBox from './SearchBox.vue';

export default {
    props: {
        show: {
            type: Boolean,
            default: false,
        },
    },

    components: {
        TableInfo,
        SearchBox,
    },

    data() {
        return {
            members: [
                { id: '1', apodo: 'Paco', },
                { id: '1', apodo: 'Paco', },
                { id: '1', apodo: 'Paco', },
                { id: '1', apodo: 'Paco', },
            ],
            member: {
                id: '2',
                apodo: 'Juan',
            },
        }
    },

    methods: {
        addMember() {
            this.members.push(this.member)
        }
    },
}
</script>

<template>
    <Transition name="modal">
        <div v-if="show" class="modal-mask">
            <div class="modal-container">
                <div class="modal-header">
                    <SearchBox @search="searchOptions" />
                    <button class="add-member" @click="addMember">Agregar</button>
                </div>

                <div class="modal-body">
                    <TableInfo>
                        <template #thead>
                            <th>Jugador</th>
                            <th>acciones</th>
                        </template>

                        <template #tbody>
                            <tr v-for="member in members" :key="member.id" class="body">
                                <td> {{ member.apodo }} </td>
                                <td> aqui van botones </td>
                            </tr>
                        </template>
                    </TableInfo>
                </div>

                <div class="modal-footer">
                    <button class="modal-default-button" @click="$emit('close',members)">OK</button>
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