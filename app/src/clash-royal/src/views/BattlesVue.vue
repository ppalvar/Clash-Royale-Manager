<script>
import EntityDefaultViews from '@/components/EntityDefaultViews.vue';
import ErrorPopup from '@/components/ErrorPopup.vue';
import SuccessPopup from '@/components/SuccessPopup.vue';
import TableInfoBattle from '@/components/TableInfoBattle.vue';
import { API_URL, PAGE_SIZE } from '@/config';
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
            page: 1,
            totalPage: 1,
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
        this.loadData(1);
    },

    methods: {
        loadData(page) {
            axios.get(`${API_URL}/battles?page=${page}&size=${PAGE_SIZE}`)
                .then(res => {
                    this.battles = res.data.battles;
                    this.page = res.data.page;
                    this.totalPage = res.data.totalPages;
                })
                .catch(error => {
                    this.error = error.response.data;
                });
        },

        seeInfo(p1, date) {
            let url = `/info-battle/${p1}/${date}`;
            this.$router.push(url);
        },

        editBattle(p1, date) {
            let url = `/edit-battle/${p1}/${date}`;
            this.$router.push(url);
        },

        deleteBattle(p1, date) {
            if (confirm('Está seguro que desea eliminar la batalla seleccionada?')) {
                axios.delete(`${API_URL}/admin/delete-battle/${p1}/${date}`)
                    .then(res => {
                        res;
                        this.loadData();
                        this.msg = 'Batalla eliminada con éxito.';
                    })
                    .catch(error => {
                        this.error = error.response.data;
                    });
            }
        },
    },
}
</script>

<template>
    <ErrorPopup v-if="error != ''" :msg="error"></ErrorPopup>
    <SuccessPopup v-if="msg != ''" :msg="msg"></SuccessPopup>

    <EntityDefaultViews url="/add-battle" @goto="loadData"
        :page="page" :totalPage="totalPage">
        <template #tabla>
            <TableInfoBattle :battles="battles" @info="seeInfo" @edit="editBattle" @delete="deleteBattle"/>
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