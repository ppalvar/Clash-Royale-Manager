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
                quality: '',
                lifePoints: 0,
                damageToTowers: 0,
                damageInArea: 0,
                numberOfUnits: 0,
                radio: 0,
                duration: 0,
            },
            type: 'none',
            error: ''
        }
    },

    mounted() {
        this.loadData();
    },

    methods: {
        async loadData() {
            await this.infoSpellCard();
            await this.infoStructureCard();
            await this.infoTroopCard();

            if (this.type === "none")
            {
                this.error = 'Ha ocurrido un error a la hora de cargar la información de la carta.'
            }
        },

        async infoSpellCard() {
            await axios.get(`${API_URL}/spellcards/${this.cardId}`)
                .then(res => {
                    this.type = 'hechizo';
                    this.card = res.data;
                })
                .catch(error => {
                    error;
                });
        },

        async infoStructureCard() {
            await axios.get(`${API_URL}/structurecards/${this.cardId}`)
                .then(res => {
                    this.type = 'estructura';
                    this.card = res.data;
                })
                .catch(error => {
                    error;
                });
        },

        async infoTroopCard() {
            await axios.get(`${API_URL}/troopcards/${this.cardId}`)
                .then(res => {
                    this.type = 'tropa';
                    this.card = res.data;
                })
                .catch(error => {
                    error;
                });
        },
    },
}
</script>

<template>
    <ErrorPopup v-if="error != ''" :msg="error"></ErrorPopup>

    <WindowsInfoCarta v-if="type != 'none'"
        :nombre="card.name"
        :descripcion="card.description"
        :costo="card.elixirCost"
        :calidad="card.quality"
        :lifePoints="card.lifePoints"
        :damageToTowers="card.damageToTowers"
        :damageInArea="card.damageInArea"
        :numberOfUnits="card.numberOfUnits"
        :radio="card.radio"
        :duration="card.duration"
        :type="type"
        :minimalice="true" 
    />
</template>