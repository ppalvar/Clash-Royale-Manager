<script>
import EntityDefaultViews from '@/components/EntityDefaultViews.vue';
import ErrorPopup from '@/components/ErrorPopup.vue';
import SuccessPopup from '@/components/SuccessPopup.vue';
import TableInfoBattle from '@/components/TableInfoBattle.vue';
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
        TableInfoBattle,
        ErrorPopup,
        SuccessPopup,
    },

    data() {
        return {
            battles: [],
            error: '',
            msg: ''
        }
    },

    mounted() {
        this.loadData();
    },

    methods: {
        loadData() {
            axios.get(`${API_URL}/battles`)
                .then(res => {
                    console.log(res.data);
                    this.battles = res.data.battles;
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

    <EntityDefaultViews url="/add-battle">
        <template #tabla>
            <TableInfoBattle :battles="battles" :minimalice="minimalice" />
        </template>
    </EntityDefaultViews>
</template>