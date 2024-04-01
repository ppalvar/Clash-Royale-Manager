<script>
import EntityDefaultViews from '../components/EntityDefaultViews.vue';
import TableInfoClan from '@/components/TableInfoClan.vue'
import ErrorPopup from '@/components/ErrorPopup.vue';
import SuccessPopup from '@/components/SuccessPopup.vue';
import Edit from '@/assets/svg/edit.svg';
import Delete from '@/assets/svg/delete.svg';
import Details from '@/assets/svg/details.svg';
import { isAuthenticated } from '@/auth/auth';
import { API_URL, PAGE_SIZE } from '@/config';
import axios from 'axios';

export default {
    components: {
        EntityDefaultViews,
        TableInfoClan,
        ErrorPopup,
        SuccessPopup,
    },

    data() {
        return {
            clanes: [],
            page: 1,
            totalPage: 1,
            error: '',
            msg: '',
            Edit,
            Delete,
            Details,
        }
    },

    mounted() {
        this.loadData(1);
    },

    computed: {
        isUserAuthenticated() {
            return isAuthenticated();
        }
    },

    methods: {
        seeInfo(id) {
            let url = `/info-clan/${id}`;
            this.$router.push(url);
        },

        editClan(id) {
            let url = `/edit-clan/${id}`;
            this.$router.push(url);
        },

        deleteClan(id) {
            if (confirm('Está seguro que desea eliminar el clan seleccionado?')) {
                axios.delete(`${API_URL}/admin/delete-clan/${id}`)
                    .then(async res => {
                            res;
                            await this.loadData();
                            this.msg = 'Clan eliminado con éxito.';
                        })
                        .catch(error => {
                                this.error = error.response.data;
                            });
            }
        },

        loadData(page) {
            axios.get(`${API_URL}/clans?page=${page}&size=${PAGE_SIZE}`)
                .then(res => {
                    this.clanes = res.data.clans;
                    this.page = res.data.page;
                    this.totalPage = res.data.totalPages;
                })
                .catch(error => {
                    this.error = error.response.data;
                });
        },
    },
}
</script>

<template>
    <ErrorPopup v-if="error != ''" :msg="error"></ErrorPopup>
    <SuccessPopup v-if="msg != ''" :msg="msg"></SuccessPopup>

    <EntityDefaultViews url="/add-clan" @goto="loadData"
        :page="page" :totalPage="totalPage">
        <template #tabla>
            <TableInfoClan :clanes="clanes" @info="seeInfo" 
                @edit="editClan" @delete="deleteClan"/>
        </template>
    </EntityDefaultViews>
</template>