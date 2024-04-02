<template>
    <ErrorPopup v-if="error != ''" :msg="error"></ErrorPopup>
    <SuccessPopup v-if="msg != ''" :msg="msg"></SuccessPopup>

    <challenge-form mode="edit" :challengeData="challenge" :challengeId="id" />
</template>

<script>

import ChallengeForm from '@/components/ChallengeForm.vue';
import ErrorPopup from '@/components/ErrorPopup.vue';
import SuccessPopup from '@/components/SuccessPopup.vue';
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    props: ['id'],

    components: {
        ChallengeForm,
        ErrorPopup,
        SuccessPopup,
    },

    data() {
        return {
            challenge: null,
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
                    console.log(this.challenge);
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