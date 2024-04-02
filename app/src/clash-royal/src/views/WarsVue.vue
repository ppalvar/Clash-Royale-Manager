<script>
import EntityDefaultViews from '../components/EntityDefaultViews.vue';
import WindowsInfoWar from '@/components/WindowsInfoWar.vue';
import ErrorPopup from '@/components/ErrorPopup.vue';
import SuccessPopup from '@/components/SuccessPopup.vue';
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    components: {
        EntityDefaultViews,
        WindowsInfoWar,
        ErrorPopup,
        SuccessPopup,
    },

    data() {
        return {
            wars: [],
            error: '',
            msg: '',
        }
    },

    mounted() {
        this.loadData();
    },

    methods: {
        info(id) {
            let url = `/info-clan/${id}`;
            this.$router.push(url);
        },

        editWar(id) {
            let url = `/edit-war/${id}`;
            this.$router.push(url);
        },

        deleteWar(id) {
            if (confirm('Está seguro que desea eliminar la guerra seleccionada?')) {
                axios.delete(`${API_URL}/admin/delete-war/${id}`)
                    .then(async res => {
                            res;
                            await this.loadData();
                            this.msg = 'Guerra eliminada con éxito.';
                        })
                        .catch(error => {
                                this.error = error.response.data;
                            });
            }
        },

        loadData() {
            axios.get(`${API_URL}/wars`)
                .then(res => {
                    this.wars = res.data.wars;
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

    <EntityDefaultViews url="/add-war">
        <template #heard>
            <h2>Guerras</h2>
        </template>

        <template #botonCrear>
            NewWar
        </template>

        <template #tabla>
            <WindowsInfoWar :wars="wars" @info="info" 
                @edit="editWar" @delete="deleteWar"/>
        </template>
    </EntityDefaultViews>
</template>