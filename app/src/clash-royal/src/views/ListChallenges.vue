<template>
    <ErrorPopup v-if="error != ''" :msg="error"></ErrorPopup>
    <SuccessPopup v-if="msg != ''" :msg="msg"></SuccessPopup>

    <div>
        <challenge-list :challenges="challenges" />
    </div>
</template>

<script>
import ChallengeList from '@/components/ChallengeList.vue';
import ErrorPopup from '@/components/ErrorPopup.vue';
import SuccessPopup from '@/components/SuccessPopup.vue';
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    components: {
        ChallengeList,
        ErrorPopup,
        SuccessPopup,
    },

    data() {
        return {
            challenges: [],
            error: '',
            msg: ''
        }
    },

    mounted() {
        this.loadData();
    },

    methods: {
        loadData() {
            axios.get(`${API_URL}/challenges`)
                .then(res => {
                    this.challenges = res.data.challenges;
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