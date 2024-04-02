<template>
    <div class="content">
        <region-list :regions="regions" />
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
            regions: [
                {
                    "name": "Training_Camp",
                    "card": "---",
                    "clan": {
                        "name": "---",
                        "tropheos": 0
                    }
                },
                {
                    "name": "Goblin_Stadium",
                    "card": "---",
                    "clan": {
                        "name": "---",
                        "tropheos": 0
                    }
                },
                {
                    "name": "Bone_Pit",
                    "card": "---",
                    "clan": {
                        "name": "---",
                        "tropheos": 0
                    }
                },
                {
                    "name": "Barbarian_Bowl",
                    "card": "---",
                    "clan": {
                        "name": "---",
                        "tropheos": 0
                    }
                },
                {
                    "name": "PEKKAs_Playhouse",
                    "card": "---",
                    "clan": {
                        "name": "---",
                        "tropheos": 0
                    }
                },
                {
                    "name": "Spell_Valley",
                    "card": "---",
                    "clan": {
                        "name": "---",
                        "tropheos": 0
                    }
                },
                {
                    "name": "Builder_Workshop",
                    "card": "---",
                    "clan": {
                        "name": "---",
                        "tropheos": 0
                    }
                },
                {
                    "name": "Royal_Arena",
                    "card": "---",
                    "clan": {
                        "name": "---",
                        "tropheos": 0
                    }
                },
                {
                    "name": "Frozen_Peak",
                    "card": "---",
                    "clan": {
                        "name": "---",
                        "tropheos": 0
                    }
                },
                {
                    "name": "Jungle_Arena",
                    "card": "---",
                    "clan": {
                        "name": "---",
                        "tropheos": 0
                    }
                },
                {
                    "name": "Hog_Mountain",
                    "card": "---",
                    "clan": {
                        "name": "---",
                        "tropheos": 0
                    }
                },
                {
                    "name": "Electro_Valley",
                    "card": "---",
                    "clan": {
                        "name": "---",
                        "tropheos": 0
                    }
                },
                {
                    "name": "Spooky_Town",
                    "card": "---",
                    "clan": {
                        "name": "---",
                        "tropheos": 0
                    }
                },
                {
                    "name": "Legendary_Aren",
                    "card": "---",
                    "clan": {
                        "name": "---",
                        "tropheos": 0
                    }
                }
            ],
        }
    },

    mounted() {
        this.loadData();
    },

    methods: {
        async loadData() {
            for (let index = 0; index < this.regions.length; index++) {
                await this.getCard(index);
                await this.getClan(index);
            }
        },

        async getCard(index) {
            await axios.get(`${API_URL}/cards/most-donated/${index}`)
                .then(res => {
                    this.regions[index].card = res.data.name;
                })
                .catch(error => {
                    error;
                });
        },

        async getClan(index) {
            await axios.get(`${API_URL}/clanregion/${index}`)
                .then(res => {
                    this.regions[index].clan = {
                        'name': res.data.name,
                        'tropheos': res.data.numberOfTrophiesObtainedInWars
                    };
                })
                .catch(error => {
                    error;
                });
        }
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