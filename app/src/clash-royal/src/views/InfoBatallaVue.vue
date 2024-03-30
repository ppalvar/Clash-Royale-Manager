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
            player1Id: '',
            player2Id: '',
            winner: false,
            numberOfTrophies: 0,
            duration: new Date(),
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
                    this.player1Id = res.data.player1Id;
                    this.player2Id = res.data.player2Id;
                    this.winner = res.data.winner;
                    this.numberOfTrophies = res.data.numberOfTrophies;
                    this.duration = res.data.duration;
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

    <WindowsInfoBatalla 
        :jugador1=player1nickname 
        :jugador2=player2nickname 
        :winner=winner 
        :trofeos=numberOfTrophies
        :date=date 
        :duracion=duration 
    />

    <div class="estetic-list-contener">
        <div class="jugadores-contener" @click="$emit('info', player1Id)">
            <h2>{{ player1nickname }}</h2>
        </div>

        <div class="jugadores-contener" @click="$emit('info', player2Id)">
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