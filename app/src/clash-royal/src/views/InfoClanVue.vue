<script>
import WindowsInfoClan from '@/components/WindowsInfoClan.vue';
import EntityDefaultViews from '@/components/EntityDefaultViews.vue';
import TableInfoJugador from '@/components/TableInfoJugador.vue';
import TableInfoCarta from '@/components/TableInfoCarta.vue';
import { isAuthenticated } from '@/auth/auth';
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    props: {
        clanId: {
            type: String,
            default: "",
        },
    },

    components: {
        EntityDefaultViews,
        TableInfoJugador,
        WindowsInfoClan,
        TableInfoCarta,
    },

    data() {
        return {
            isAuthenticated,
            item: {
                "idType": "",
                "name": "",
                "description": "",
                "type": "",
                "numberOfTrophiesObtainedInWars": 0,
                "region": 0,
                "numberOfMembers": 0,
                "trophiesNeededToEnter": 0
            },
        }
    },

    mounted() {
        this.loadData();
    },

    methods: {
        loadData() {
            axios.get(`${API_URL}/clans/${this.clanId}`)
                .then(res => {
                    this.item = res.data;
                })
                .catch(error => {
                    this.error = error.response.data;
                });
        },

        seeCarts() {
            //TODO - CartsOfclan
        },

        seeMembers() {
            //TODO - members of clans
        },

        getRegion(id) {
            const regions = [
                "Training_Camp",
                "Goblin_Stadium",
                "Bone_Pit",
                "Barbarian_Bowl",
                "PEKKAs_Playhouse",
                "Spell_Valley",
                "Builder_Workshop",
                "Royal_Arena",
                "Frozen_Peak",
                "Jungle_Arena",
                "Hog_Mountain",
                "Electro_Valley",
                "Spooky_Town",
                "Legendary_Aren"
            ]

            return regions[id];
        }
    },
}
</script>

<template>
    <WindowsInfoClan 
        :nombre="item.name" 
        :descripcion="item.description" 
        :trofeos="item.numberOfTrophiesObtainedInWars" 
        :region="getRegion(item.region)"
        :miembros="item.numberOfMembers" 
        :condicion="item.trophiesNeededToEnter" 
        :minimalice="true" 
    />

    <EntityDefaultViews>
        <template #heard>
            <h2>Miembros</h2>
        </template>

        <template #botonCrear>
            <label v-if="isAuthenticated()">NewMember</label>
        </template>

        <template #tabla>
            <TableInfoJugador :jugadores="seeMembers()" @info="seeInfo" />
        </template>
    </EntityDefaultViews>

    <EntityDefaultViews>
        <template #heard>
            <h2>Cartas Donadas</h2>
        </template>

        <template #botonCrear>
            <label v-if="isAuthenticated()">NewCart</label>
        </template>

        <template #tabla>
            <TableInfoCarta :carts="seeCarts()" @info="seeInfo" />
        </template>
    </EntityDefaultViews>
</template>

<style>
.estetic-list-container {
    display: flex;
    flex-basis: calc(50%);
}
</style>