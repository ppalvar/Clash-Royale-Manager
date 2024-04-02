<template>
    <ErrorPopup v-if="error != ''" :msg="error"></ErrorPopup>
    <SuccessPopup v-if="msg != ''" :msg="msg"></SuccessPopup>

    
    <div class="content">
        <button v-if="filter" @click.prevent="filterAction()">Filtrar por retos completados</button>
        <button v-else @click.prevent="filterAction()">Eliminar filtro</button>

        <challenge-list :challenges="challenges" />

        <PaginacionItem :page="page" :totalPage="totalPage" @goto-page="goTo"/>
    </div>
</template>

<script>
import ChallengeList from '@/components/ChallengeList.vue';
import PaginacionItem from '@/components/PaginacionItem.vue';
import ErrorPopup from '@/components/ErrorPopup.vue';
import SuccessPopup from '@/components/SuccessPopup.vue';
import { API_URL, PAGE_SIZE } from '@/config';
import axios from 'axios';

export default {
    components: {
        ChallengeList,
        PaginacionItem,
        ErrorPopup,
        SuccessPopup,
    },

    data() {
        return {
            challenges: [],
            filter: true,
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
        loadData(page) {
            axios.get(`${API_URL}/challenges?page=${page}&size=${PAGE_SIZE}`)
                .then(res => {
                    this.challenges = res.data.challenges;
                    this.page = res.data.page;
                    this.totalPage = res.data.totalPage;
                })
                .catch(error => {
                    this.error = error.response.data;
                });
            },
            
            loadFilterData(page) {
                axios.get(`${API_URL}/challenges/completed-by-some-player?page=${page}&pageSize=${PAGE_SIZE}`)
                .then(res => {
                    this.challenges = res.data.challenges;
                    this.page = res.data.page;
                    this.totalPage = res.data.totalPage;
                })
                .catch(error => {
                    this.error = error.response.data;
                });
        },

        filterAction() {
            if (this.filter) {
                this.filter = false;
                this.loadData(1);
            } else {
                this.filter = true;
                this.loadFilterData(1);
            }
        },

        goTo(page) {
            if (this.filter) {
                this.loadFilterData();
            } else {
                this.loadData(page);
            }
        }
    }
};
</script>

<style>
h1 {
    color: #e9c46a;
    text-align: center;
    margin-top: 20px;
}

.content {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}
</style>