<script>
import EntityDefaultViews from '@/components/EntityDefaultViews.vue';
import ErrorPopup from '@/components/ErrorPopup.vue';
import SuccessPopup from '@/components/SuccessPopup.vue';
import TableInfoJugador from '@/components/TableInfoJugador.vue';
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    props: {
        minimalice: {
            type: Boolean,
            default: false,
        },
    },

    components: {
        EntityDefaultViews,
        TableInfoJugador,
        ErrorPopup,
        SuccessPopup,
    },

    data() {
        return {
            players: [],
            error: '',
            msg: ''
        }
    },

    mounted() {
        this.loadData();
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

        loadData() {
            axios.get(`${API_URL}/players`)
                .then(res => {
                    this.players = res.data.players;
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

    <EntityDefaultViews url="/add-player">
        <template #tabla>
            <TableInfoJugador 
                :jugadores="players" :minimalice="minimalice" 
                @info="seeInfo" @edit="editPlayer" @delete="deletePlayer"
            />
        </template>
    </EntityDefaultViews>
</template>