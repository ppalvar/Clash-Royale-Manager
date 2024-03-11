<script>
import EntityDefaultViews from '@/components/EntityDefaultViews.vue';
import ErrorPopup from '@/components/ErrorPopup.vue';
import TableInfoCarta from '@/components/TableInfoCarta.vue';
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
        TableInfoCarta,
        ErrorPopup,
    },

    data() {
        return {
            cards: [],
            error: ''
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

    <EntityDefaultViews>
        <template #botonCrear>
            <h2 v-if="auth && !minimalice">CrearCart</h2>
        </template>

        <template #tabla>
            <TableInfoCarta :cards="cards" :minimalice="minimalice" @info="seeInfo" />
        </template>
    </EntityDefaultViews>
</template>