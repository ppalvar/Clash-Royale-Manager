<script>
import WindowsInfoCarta from '@/components/WindowsInfoCarta.vue';
import ErrorPopup from '@/components/ErrorPopup.vue';
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    props: {
        cardId: {
            type: String,
            default: null,
        },
    },

    components: {
        WindowsInfoCarta,
        ErrorPopup
    },

    data() {
        return {
            card: {
                name: '',
                description: '',
                elixirCost: '',
                quality: ''
            },
            error: ''
        }
    },

    mounted() {
        this.loadData();
    },

    methods: {
        loadData() {
            axios.get(`${API_URL}/cards/${this.cardId}`)
                .then(res => {
                    this.card = res.data;
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

    <WindowsInfoCarta :nombre=card.name :descripcion=card.description :costo=card.elixirCost :calidad=card.quality
            :minimalice="true" />
</template>