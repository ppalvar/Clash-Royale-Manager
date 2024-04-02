<script>
import EntityDefaultViews from '@/components/EntityDefaultViews.vue';
import ErrorPopup from '@/components/ErrorPopup.vue';
import SuccessPopup from '@/components/SuccessPopup.vue';
import TableInfoJugador from '@/components/TableInfoJugador.vue';
import { API_URL, PAGE_SIZE } from '@/config';
import axios from 'axios';

export default {
    components: {
        EntityDefaultViews,
        TableInfoJugador,
        ErrorPopup,
        SuccessPopup,
    },

    data() {
        return {
            players: [],
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
            let url = `/info-jugador/${id}`;
            this.$router.push(url);
        },
        
        editPlayer(id) {
            let url = `/edit-player/${id}`;
            this.$router.push(url);
        },

        deletePlayer(id) {
            if (confirm('Éstá seguro que desea eliminar el jugador seleccionado?')) {
                axios.delete(`${API_URL}/admin/delete-player/${id}`)
                    .then(async res => {
                            res;
                            await this.loadData();
                            this.msg = 'Jugador eliminado con éxito.';
                        })
                        .catch(error => {
                                this.error = error.response.data;
                            });
            }
        },

        loadData(page) {
            axios.get(`${API_URL}/players?page=${page}&size=${PAGE_SIZE}`)
                .then(res => {
                    this.players = res.data.players;
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

    <EntityDefaultViews url="/add-player" @goto="loadData"
        :page="page" :totalPage="totalPage">
        <template #tabla>
            <TableInfoJugador 
                :jugadores="players" @info="seeInfo"
                @edit="editPlayer" @delete="deletePlayer"
            />
        </template>
    </EntityDefaultViews>
</template>