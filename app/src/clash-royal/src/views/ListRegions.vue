<template>    
    <div class="content">
        <region-list :best_cards="best_cards" />
    </div>
</template>

<script>
import RegionList from '@/components/RegionList.vue';
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    components: {
        RegionList,
    },

    data() {
        return {
            regions_names: [
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
            ],
            best_cards: [],
        }
    },

    mounted() {
        this.loadData();
    },

    methods: {
        loadData() {
            this.regions_names.forEach((region, index) => {
                axios.get(`${API_URL}/cards/most-donated/${index}`)
                    .then(res => {
                        this.best_cards.push({
                            'id': index,
                            'region': region,
                            'card': res.name
                        });
                    })
                    .catch(error => {
                        error;
                        this.best_cards.push({
                            'id': index,
                            'region': region,
                            'card': '---'
                        });
                    });
            });
        },
    }
};
</script>

<style>
h1 {
    color: #e9c46a;
    text-align: center;
    margin-top: 20px;
}

.content {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}
</style>