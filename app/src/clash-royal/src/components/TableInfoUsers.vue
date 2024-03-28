<template>
    <ErrorPopup v-if="error != ''" :msg="error"></ErrorPopup>
    <SuccessPopup v-if="msg != ''" :msg="msg"></SuccessPopup>
    
    <EntityDefaultViews>
        <template #heard>
            <h2>Users</h2>
        </template>

        <template #tabla>
            <TableInfo>
                <template #thead>
                    <th>Nombre</th>
                    <th>Correo</th>
                    <th>Activar</th>
                    <!-- <th>Acciones</th> -->
                </template>

                <template #tbody>
                    <tr v-for="user in users" :key="user.email">
                        <td> {{ user.username }} </td>
                        <td> {{ user.email }} </td>
                        <td>
                            <input type="checkbox" v-model="user.isActive" @click="updateUser(user.id)">
                        </td>
                        <!-- <td class="actions">
                            //TODO - Create actions users
                            <img height="20px" :src="Details" @click="$emit('info', card.id)"/>
                            <img v-if="isUserAuthenticated" height="20px" :src="Edit" @click="$emit('edit', card.id)"/>
                            <img v-if="isUserAuthenticated" height="20px" :src="Delete" @click="$emit('delete', card.id)"/>
                        </td> -->
                    </tr>
                </template>
            </TableInfo>
        </template>
    </EntityDefaultViews>
</template>

<script>
import EntityDefaultViews from './EntityDefaultViews.vue';
import ErrorPopup from '@/components/ErrorPopup.vue';
import SuccessPopup from '@/components/SuccessPopup.vue';
import Edit from '@/assets/svg/edit.svg';
import Delete from '@/assets/svg/delete.svg';
import Details from '@/assets/svg/details.svg';
import TableInfo from '@/components/TableInfo.vue';
import { isAuthenticated } from '@/auth/auth';
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    components: {
        EntityDefaultViews,
        TableInfo,
        ErrorPopup,
        SuccessPopup,
    },

    data() {
        return {
            users: [],
            error: '',
            msg: '',
            Edit,
            Delete,
            Details,
        }
    },

    mounted() {
        this.loadData();
    },

    computed: {
        isUserAuthenticated() {
            return isAuthenticated();
        }
    },

    methods: {
        loadData() {
            axios.get(`${API_URL}/admin/users`)
                .then(res => {
                    this.users = res.data.users;
                })
                .catch(error => {
                    this.error = error.response.data;
                });
        },
        
        updateUser(userId) {
            userId;
            // axios.put(`${API_URL}/auth/update-account/${userId}`)
            //     .then(res => {
            //         res;
            //         this.msg("Usuario activado con éxito.");
            //         location.reload();
            //     })
            //     .catch(error => {
            //         this.error = error.response.data;
            //     });
        },
    }
}
</script>