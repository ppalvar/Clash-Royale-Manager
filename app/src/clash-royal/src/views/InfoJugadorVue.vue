<script>
import WindowsInfoJugador from '@/components/WindowsInfoJugador.vue';
import EntityDefaultViews from '@/components/EntityDefaultViews.vue';
import TableInfoBattle from '@/components/TableInfoBattle.vue';
import TableInfoCarta from '@/components/TableInfoCarta.vue';
import ErrorPopup from '@/components/ErrorPopup.vue';
import { isAuthenticated } from '@/auth/auth';
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    props: {
        playerId: {
            type: String
        },
    },

    components: {
        WindowsInfoJugador,
        EntityDefaultViews,
        TableInfoBattle,
        TableInfoCarta,
        ErrorPopup,
    },

    data() {
        return {
            isAuthenticated,
            player: {
                nickname: '',
                level: '',
                numberOfTrophies: '',
                numberOfWins: '',
                maximunTrophiesAchieved: '',
                numberOfCardsFound: '',
            },
            cards: [],
            battles: [],
            error: ''
        }
    },

    mounted() {
        this.loadData();
    },

    methods: {
        seeInfoCard(id) {
            let url = `/info-carta/${id}`;
            this.$router.push(url);
        },

        loadData() {
            axios.get(`${API_URL}/players/${this.playerId}`,{id:this.playerId})
                .then(res => {
                    this.player = res.data;
                })
                .catch(error => {
                    this.error = error.response.data;
                });
                
            axios.get(`${API_URL}/cards-by-player/${this.playerId}`,{id:this.playerId})
                .then(res => {
                    this.cards = res.data.cards;
                })
                .catch(error => {
                    this.error = error.response.data;
                });
            
            axios.get(`${API_URL}/battles-by-player/${this.playerId}`,{id:this.playerId})
                .then(res => {
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

    <WindowsInfoJugador 
        :code="player.code" 
        :apodo="player.nickname" 
        :nivel="player.level" 
        :victorias="player.numberOfWins" 
        :cartas="player.numberOfCardsFound"
        :trofeos="player.numberOfTrophies" 
        :racha="player.maximunTrophiesAchieved" 
    />

    <EntityDefaultViews url="/add-card">
        <template #head>
            <h2>Cartas del Jugador</h2>
        </template>
        
        <template #botonCrear>
            <label v-if="isAuthenticated()">NewCart</label>
        </template>

        <template #tabla>
            <TableInfoCarta :cards="cards" @info="seeInfoCard" :edit="false" />
        </template>
    </EntityDefaultViews>

    <EntityDefaultViews>
        <template #head>
            <h2>Batallas del Jugador</h2>
        </template>

        <template #tabla>
            <TableInfoBattle :batallas="battles" @infobatalla="seeInfoBatalla" :edit="false" />
        </template>
    </EntityDefaultViews>
</template>