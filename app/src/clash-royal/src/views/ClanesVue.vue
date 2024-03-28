<script>
import EntityDefaultViews from '../components/EntityDefaultViews.vue';
import TableInfoClan from '@/components/TableInfoClan.vue'
import ErrorPopup from '@/components/ErrorPopup.vue';
import SuccessPopup from '@/components/SuccessPopup.vue';
import Edit from '@/assets/svg/edit.svg';
import Delete from '@/assets/svg/delete.svg';
import Details from '@/assets/svg/details.svg';
import { isAuthenticated } from '@/auth/auth';
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
        TableInfoClan,
        ErrorPopup,
        SuccessPopup,
    },

    data() {
        return {
            clanes: [],
            error: '',
            msg: '',
            Edit,
            Delete,
            Details,
        }
    },

    mounted() {
        this.loadData();
    },

    computed: {
        isUserAuthenticated() {
            return isAuthenticated();
        }
    },

    methods: {
        seeInfo(id) {
            this.$emit('info', id)
        },

        loadData() {
            axios.get(`${API_URL}/clans`)
                .then(res => {
                    this.clanes = res.data.clans;
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

    <EntityDefaultViews url="/add-clan">
        <template #tabla>
            <TableInfoClan :clanes="clans" :minimalice="minimalice" @info="seeInfo" />
        </template>
    </EntityDefaultViews>
</template>