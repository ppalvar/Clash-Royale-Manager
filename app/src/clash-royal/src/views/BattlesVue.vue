<script>
import EntityDefaultViews from '@/components/EntityDefaultViews.vue';
import WindowsInfoBatalla from '@/components/WindowsInfoBatalla.vue';
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
        WindowsInfoBatalla,
        TableInfoBattle,
        ErrorPopup,
        SuccessPopup,
    },

    data() {
        return {
            battles: [],
            error: '',
            msg: '',
            show_table: true,
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
                    console.log(res.data);
                    this.battles = res.data.battles;
                })
                .catch(error => {
                    this.error = error.response.data;
                });
        },

        seeInfo(index) {
            console.log(index);
            console.log(this.battles[index]);
            this.item = this.battles[index];
            this.show_table = false;
        },
    },
}
</script>

<template>
    <ErrorPopup v-if="error != ''" :msg="error"></ErrorPopup>
    <SuccessPopup v-if="msg != ''" :msg="msg"></SuccessPopup>

    <EntityDefaultViews url="/add-battle" v-if="show_table">
        <template #tabla>
            <TableInfoBattle :battles="battles" :minimalice="minimalice" @seeInfo="seeInfo"/>
        </template>
    </EntityDefaultViews>

    <div class="info-battle" v-else>

        <div class="btn" @click="show_table=true;">Atrás</div>

        <WindowsInfoBatalla :jugador1=item.player1 :jugador2=item.player2 :winner=item.battle.winner :trofeos=item.battle.numberOfTrophies
            :date=item.battle.date :duracion=item.battle.duration :minimalice="true" />

        <div class="estetic-list-contener">
            <div class="jugadores-contener">
                <h2>{{ item.player1 }}</h2>
            </div>

            <div class="jugadores-contener">
                <h2>{{ item.player2 }}</h2>
            </div>
        </div>
    </div>
</template>

<style scoped>

.estetic-list-contener {
    display: flex;
    flex-basis: calc(50%);
}

.jugadores-contener {
    background-color: rgba(0, 0, 0, 0.75);
    padding: 0px 6px;
    border-radius: 10px;
    margin: 30px auto;
    cursor: pointer;
    text-align: center;
    color: #ffde00;
}

.jugadores-contener:hover {
    background-color: #f1c20875;
    color: #000;
}

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