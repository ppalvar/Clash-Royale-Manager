<script>
import WindowsInfoJugador from '@/components/WindowsInfoJugador.vue';
import EntityDefaultViews from '@/components/EntityDefaultViews.vue';
import TableInfoBattle from '@/components/TableInfoBattle.vue';
import TableInfoCarta from '@/components/TableInfoCarta.vue';
import TableInfoClan from '@/components/TableInfoClan.vue';
import ErrorPopup from '@/components/ErrorPopup.vue';
import { isAuthenticated } from '@/auth/auth';
import { API_URL, PAGE_SIZE } from '@/config';
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
        TableInfoClan,
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
            pageCard: 1,
            totalPageCard: 0,
            battles: [],
            pageBattle: 1,
            totalPageBattle: 0,
            clans: [],
            pageClan: 1,
            totalPageClan: 0,
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
            
            this.getCards(1);
            this.getBattles(1);
            this.getClans(1);
        },

        getCards(page) {
            axios.get(`${API_URL}/cards-by-player/${this.playerId}?page=${page}&size=${PAGE_SIZE}`)
                .then(res => {
                    this.cards = res.data.cards;
                    this.pageCard = res.data.page;
                    this.totalPageCard = res.data.totalPages;
                })
                .catch(error => {
                    this.error = error.response.data;
                });
        },

        getBattles(page) {
            axios.get(`${API_URL}/battles-by-player/${this.playerId}?page=${page}&size=${PAGE_SIZE}`,{id:this.playerId})
                .then(res => {
                    this.battles = res.data.battles;
                    this.pageBattle = res.data.page;
                    this.totalPageBattle = res.data.totalPages;
                })
                .catch(error => {
                    this.error = error.response.data;
                });
        },
        
        getClans(page) {
            axios.get(`${API_URL}/players/clans-can-join/${this.playerId}?page=${page}&size=${PAGE_SIZE}`,{id:this.playerId})
                .then(res => {
                    this.clans = res.data.clans;
                    this.pageClan = res.data.page;
                    this.totalPageClan = res.data.totalPages;
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



    <div class="grid-container">
        <EntityDefaultViews @goto="getCards">
            <template #head>
                <h2>Cartas del Jugador</h2>
            </template>
            
            <template #tabla>
                <TableInfoCarta :cards="cards" @info="seeInfoCard" :edit="false" />
            </template>
        </EntityDefaultViews>
        
        <EntityDefaultViews @goto="getBattles">
            <template #head>
                <h2>Batallas del Jugador</h2>
            </template>
            
            <template #tabla>
                <TableInfoBattle :batallas="battles" @infobatalla="seeInfoBatalla" :edit="false" />
            </template>
        </EntityDefaultViews>
    </div>

    <EntityDefaultViews @goto="getClans"
        :page="page" :totalPage="totalPage">
        <template #head>
            <h2>Clanes a los que puede unirse</h2>
        </template>

        <template #tabla>
            <TableInfoClan :clanes="clanes" @info="seeInfo" 
                @edit="editClan" @delete="deleteClan"/>
        </template>
    </EntityDefaultViews>
</template>

<style>
.grid-container {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 10px;
}
</style>