<script>
import EntityDefaultViews from '@/components/EntityDefaultViews.vue';
import ErrorPopup from '@/components/ErrorPopup.vue';
import SuccessPopup from '@/components/SuccessPopup.vue';
import TableInfoBattle from '@/components/TableInfoBattle.vue';
import { API_URL } from '@/config';
import axios from 'axios';

export default {
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
            msg: '',
            item: {
                "battle": {
                    "player1Id": "string",
                    "player2Id": "string",
                    "winner": true,
                    "numberOfTrophies": 0,
                    "date": "2024-03-26T14:32:41.839Z",
                    "duration": "2024-03-26T14:32:41.839Z",
                    "player1": "string",
                    "player2": "string"
                },
                "player1": "string",
                "player2": "string"
            },
        }
    },

    mounted() {
        this.loadData();
    },

    methods: {
        loadData() {
            axios.get(`${API_URL}/battles`)
                .then(res => {
                    this.battles = res.data.battles;
                })
                .catch(error => {
                    this.error = error.response.data;
                });
        },

        seeInfo(p1, date) {
            let url = `/info-battle/${p1}/${date}`;
            this.$router.push(url);
        },
    },
}
</script>

<template>
    <ErrorPopup v-if="error != ''" :msg="error"></ErrorPopup>
    <SuccessPopup v-if="msg != ''" :msg="msg"></SuccessPopup>

    <EntityDefaultViews url="/add-battle">
        <template #tabla>
            <TableInfoBattle :battles="battles" @info="seeInfo"/>
        </template>
    </EntityDefaultViews>
</template>

<style scoped>

.btn {
  text-align: center;
  height: 1em;
  padding: 10px;
  border: solid 1px;
  background-color: #ffde00;
  border-radius: 0.5em;
  color: #121212;
  margin-left: 15px;
  margin-bottom: 15px;
  cursor: pointer;
  margin: 20px auto;
}

.btn:hover {
  background-color: #f1c208dd;
}
</style>