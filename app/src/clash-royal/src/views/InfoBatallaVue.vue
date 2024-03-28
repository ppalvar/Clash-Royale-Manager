<script>
import ErrorPopup from '@/components/ErrorPopup.vue';
import WindowsInfoBatalla from '@/components/WindowsInfoBatalla.vue';
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    props: {
        playerId: {
            type: String
        },
        date: {
            type: Date
        },
    },

    components: {
        WindowsInfoBatalla,
        ErrorPopup,
    },

    data() {
        return {
            battle: {
                player1id: '',
                player2id: '',
                winner: false,
                numberOfTrophies: 0,
                date: new Date(),
                duration: new Date(),
            },
            player1nickname: '',
            player2nickname: '',
            error: ''
        }
    },

    mounted() {
        this.loadData();
    },

    methods: {
        seeInfoJugador(id) {
            let url = `/info-player/${id}`;
            this.$router.push(url);
        },

        loadData() {
            axios.get(`${API_URL}/battles/${this.playerId}/${this.date}`)
                .then(res => {
                    this.battle = res.data.battle;
                    this.player1nickname = res.data.player1Name;
                    this.player2nickname = res.data.player2Name;
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

    <WindowsInfoBatalla :jugador1=item.jugador1 :jugador2=item.jugador2 :winner=item.winner :trofeos=item.trofeos
        :date=item.date :duracion=item.duracion />

    <div class="estetic-list-contener">
        <div class="jugadores-contener" @click="$emit('info', battle.player1Id)">
            <h2>{{player1nickname}}</h2>
        </div>

        <div class="jugadores-contener" @click="$emit('info', battle.player2Id)">
            <h2>{{ player2nickname }}</h2>
        </div>
    </div>
</template>

<style>
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
</style>