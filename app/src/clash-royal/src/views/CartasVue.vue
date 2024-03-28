<script>
import EntityDefaultViews from '@/components/EntityDefaultViews.vue';
import ErrorPopup from '@/components/ErrorPopup.vue';
import SuccessPopup from '@/components/SuccessPopup.vue';
import TableInfoCarta from '@/components/TableInfoCarta.vue';
import { API_URL } from '@/config';
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
            error: '',
            msg: ''
        }
    },

    mounted() {
        this.loadData();
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
            if (confirm('Éstá seguro que desea eliminar la carta seleccionada?')) {
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

        loadData() {
            axios.get(`${API_URL}/cards`)
                .then(res => {
                    this.cards = res.data.cards;
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

    <EntityDefaultViews url="/add-card">
        <template #tabla>
            <TableInfoCarta :cards="cards" @info="seeInfo" 
                @edit="editCard" @delete="deleteCard"/>
        </template>
    </EntityDefaultViews>
</template>