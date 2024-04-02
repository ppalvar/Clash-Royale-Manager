<template>
    <ErrorPopup v-if="error != ''" :msg="error"></ErrorPopup>
    <SuccessPopup v-if="msg != ''" :msg="msg"></SuccessPopup>

    <div>
        <challenge-detail :challenge="challenge" :playerChallenges="players" />
    </div>
</template>

<script>
import ChallengeDetail from '@/components/ChallengeDetail';
import ErrorPopup from '@/components/ErrorPopup.vue';
import SuccessPopup from '@/components/SuccessPopup.vue';
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    props: ['id'],

    components: {
        ChallengeDetail,
        ErrorPopup,
        SuccessPopup,
    },

    data() {
        return {
            challenge: Object,
            players: [],
            error: '',
            msg: ''
        }
    },

    mounted() {
        this.loadData();
    },

    methods: {
        loadData() {
            axios.get(`${API_URL}/challenges/${this.id}`)
                .then(res => {
                    this.challenge = res.data;
                })
                .catch(error => {
                    this.error = error.response.data;
                });
            
            axios.get(`${API_URL}/players-by-challenge/${this.id}`)
                .then(res => {
                    this.players = res.data.players;
                    console.log(this.players);
                })
                .catch(error => {
                    this.error = error.response.data;
                });
        },
    }
};
</script>

<style>
h1 {
    color: #e9c46a;
    text-align: center;
    margin-top: 20px;
}
</style>