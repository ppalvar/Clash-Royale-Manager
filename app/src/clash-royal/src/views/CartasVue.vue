<script>
import EntityDefaultViews from '@/components/EntityDefaultViews.vue';
import ErrorPopup from '@/components/ErrorPopup.vue';
import SuccessPopup from '@/components/SuccessPopup.vue';
import TableInfoCarta from '@/components/TableInfoCarta.vue';
import { API_URL, PAGE_SIZE } from '@/config';
import axios from 'axios';

export default {
    components: {
        EntityDefaultViews,
        TableInfoCarta,
        ErrorPopup,
        SuccessPopup,
    },

    data() {
        return {
            cards: [],
            page: 1,
            totalPage: 1,
            error: '',
            msg: ''
        }
    },

    mounted() {
        this.loadData(1);
    },

    methods: {
        seeInfo(id) {
            let url = `/info-carta/${id}`;
            this.$router.push(url);
        },
        
        editCard(id) {
            let url = `/edit-card/${id}`;
            this.$router.push(url);
        },

        deleteCard(id) {
            if (confirm('Está seguro que desea eliminar la carta seleccionada?')) {
                axios.delete(`${API_URL}/admin/delete-card/${id}`)
                    .then(async res => {
                            res;
                            await this.loadData();
                            this.msg = 'Carta eliminada con éxito.';
                        })
                        .catch(error => {
                                this.error = error.response.data;
                            });
            }
        },

        loadData(page) {
            axios.get(`${API_URL}/cards?page=${page}&size=${PAGE_SIZE}`)
                .then(res => {
                    this.cards = res.data.cards;
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

    <EntityDefaultViews 
        url="/add-card" @goto="loadData"
        :page="page" :totalPage="totalPage">
        <template #tabla>
            <TableInfoCarta :cards="cards" @info="seeInfo" 
                @edit="editCard" @delete="deleteCard"/>
        </template>
    </EntityDefaultViews>
</template>