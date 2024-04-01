<template>
    <ErrorPopup v-if="error != ''" :msg="error"></ErrorPopup>
    <SuccessPopup v-if="msg != ''" :msg="msg"></SuccessPopup>

    <CrearEntity>
        <template #entity>
            <h2>Editar Carta</h2>
        </template>

        <template #form>
            <tr>
                <th>
                    <label for="nombreCarta">Nombre de Carta</label>
                </th>
                <td>
                    <input type="text" placeholder="Nombre" required id="nombreCarta"
                        v-model="nameCard" /><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="descripcionCarta" class="descripcion-label" >Descripcion de Carta</label>
                </th>
                <td>
                    <textarea type="text" placeholder="Descripcion" required id="descripcionCarta"
                        v-model="descriptionCard"></textarea><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="costo">Costo de elixir</label>
                </th>
                <td>
                    <input type="number" id="costo" required placeholder="0.0"
                        v-model="costoElixir"><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="calidad">Calidad</label>
                </th>
                <td>
                    <select id="calidad" v-model="qualityCard">
                        <option value="buena" selected>Buena</option>
                        <option value="media">Media</option>
                        <option value="baja">Baja</option>
                    </select>
                </td>
            </tr>
            <tr>
                <th colspan="2">
                    <h2>Cualidades del Tipo</h2>
                </th>
            </tr>
            <tr>
                <th>
                    <label for="type">Tipo</label>
                </th>
                <td>
                    <select id="type" v-model="type">
                        <option value="tropa" selected>tropas</option>
                        <option value="hechizo">hechizo</option>
                        <option value="estructura">estructura</option>
                    </select>
                </td>
            </tr>
            <tr v-if="type != 'hechizo'">
                <th>
                    <label for="HP">Puntos de vida</label>
                </th>
                <td>
                    <input type="number" placeholder="0.0" required id="HP" v-model="troop_card.lifePoints" /><br>
                </td>
            </tr>
            <tr v-if="type != 'estructura'">
                <th>
                    <label for="area">Daño en Área</label>
                </th>
                <td>
                    <input type="number" placeholder="0.0" required id="area" v-model="troop_card.damageInArea"><br>
                </td>
            </tr>
            <tr v-if="type == 'tropa'">
                <th>
                    <label for="units">Número de unidades</label>
                </th>
                <td>
                    <input type="number" placeholder="0.0" required id="units" v-model="troop_card.numberOfUnits"><br>
                </td>
            </tr>
            <tr v-if="type == 'hechizo'">
                <th>
                    <label for="ratio">Radio</label>
                </th>
                <td>
                    <input type="number" placeholder="0.0" required id="ratio" v-model="spell_card.radio"><br>
                </td>
            </tr>
            <tr v-if="type == 'hechizo'">
                <th>
                    <label for="duration">Duración</label>
                </th>
                <td>
                    <input type="number" placeholder="0.0" required id="duration" v-model="spell_card.duration"><br>
                </td>
            </tr>
            <tr v-if="type == 'hechizo'">
                <th>
                    <label for="damageToTowers">Daño a torres</label>
                </th>
                <td>
                    <input type="number" placeholder="0.0" required id="damageToTowers" v-model="spell_card.damageToTowers"><br>
                </td>
            </tr>
            <tr>
                <td></td>
                <div class="actions">
                    <div class="btn edit-profile-btn" @click="updateCard()">Actualizar</div>
                    <div class="btn change-password-btn" @click="cancel()">Cancelar</div>
                </div>
            </tr>
        </template>
    </CrearEntity>
</template>

<script>
import CrearEntity from '@/components/CrearEntity.vue';
import SuccessPopup from '@/components/SuccessPopup.vue';
import ErrorPopup from '@/components/ErrorPopup.vue';
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    props: {
        cardId: {
            type: String
        }
    },

    components: {
        CrearEntity,
        SuccessPopup,
        ErrorPopup,
    },

    data() {
        return {
            nameCard: '',
            descriptionCard: '',
            costoElixir: '',
            qualityCard: '',
            spell_card: {
                radio: 0,
                duration: 0,
                damageToTowers: 0,
                damageInArea: 0
            },
            struct_card: {
                lifePoints: 0
            },
            troop_card: {
                lifePoints: 0,
                damageInArea: 0,
                numberOfUnits: 0
            },
            msg: '',
            error: ''
        }
    },

    mounted() {
        this.loadData();
    },

    methods: {
        async loadData() {
            axios.get(`${API_URL}/cards/${this.cardId}`)
                .then(res => {
                    this.nameCard = res.data.name;
                    this.descriptionCard = res.data.description;
                    this.costoElixir = res.data.elixirCost;
                    this.qualityCard = res.data.quality;
                })
                .catch(error => {
                    this.error = error.response.data;
                });
            
            await this.infoSpellCard();
            await this.infoStructureCard();
            await this.infoTroopCard();

            if (this.type === "none")
            {
                this.error = 'Ha ocurrido un error a la hora de cargar la información de la carta.'
            }
        },
        
        updateCard() {
            axios.post(`${API_URL}/admin/update-card/${this.cardId}`, {
                name: this.nameCard,
                description: this.descriptionCard,
                elixirCost: this.costoElixir,
                quality: this.qualityCard,
            })
                .then(res => {
                    
                    res;

                    this.updateTypeCard();

                    this.nameCard = '';
                    this.descriptionCard = '';
                    this.costoElixir = '';
                    this.qualityCard = '';
                })
                .catch(error => {
                    this.error = error.response.data;
                });
        },

        updateTypeCard() {
            this.struct_card.lifePoints = this.troop_card.lifePoints;
            this.spell_card.damageInArea = this.troop_card.damageInArea;

            let url =
                this.type === "tropa" ? `${API_URL}/admin/update-structurecard/${this.cardId}` :
                this.type === "hechizo" ? `${API_URL}/admin/update-structurecard/${this.cardId}` :
                this.type === "estructura" ? `${API_URL}/admin/update-structurecard/${this.cardId}` :
                null;

            let body =
                this.type === "tropa" ? this.troop_card :
                this.type === "hechizo" ? this.spell_card :
                this.type === "estructura" ? this.struct_card :
                {};

            axios.post(url, body)
                .then(res => {
                    res;
                    this.error='';
                    this.msg = `Se ha actualizado la carta "${this.nameCard}" correctamente.`;

                    this.spell_card = {
                        radio: 0,
                        duration: 0,
                        damageToTowers: 0,
                        damageInArea: 0
                    };
                    this.struct_card = {
                        lifePoints: 0
                    };
                    this.troop_card = {
                        lifePoints: 0,
                        damageInArea: 0,
                        numberOfUnits: 0
                    };
                })
                .catch(error => {
                    this.error = error.response.data;
                });
        },

        async infoSpellCard() {
            await axios.get(`${API_URL}/spellcards/${this.cardId}`)
                .then(res => {
                    this.type = 'hechizo';
                    this.spell_card = {
                        radio: res.data.radio,
                        duration: res.data.duration,
                        damageToTowers: res.data.damageToTowers,
                        damageInArea: res.data.damageInArea
                    }
                })
                .catch(error => {
                    error;
                });
        },

        async infoStructureCard() {
            await axios.get(`${API_URL}/structurecards/${this.cardId}`)
                .then(res => {
                    this.type = 'estructura';
                    this.struct_card = {
                        lifePoints: res.data.lifePoints
                    }
                })
                .catch(error => {
                    error;
                });
        },

        async infoTroopCard() {
            await axios.get(`${API_URL}/troopcards/${this.cardId}`)
                .then(res => {
                    this.type = 'tropa';
                    this.troop_card = {
                        lifePoints: res.data.lifePoints,
                        damageInArea: res.data.damageInArea,
                        numberOfUnits: res.data.numberOfUnits
                    }
                })
                .catch(error => {
                    error;
                });
        },

        async cancel() {
            await this.$router.push('/carta');
            location.reload()
        }
    },
}
</script>

<style>
#nombreCarta {
    width: 15rem;
}

#descripcionCarta {
    height: 50px;
    width: 25rem;
    resize: none;
}

.descripcion-label {
    position: relative;
    top: -25px;
}

#costo {
    width: 5rem;
}

td select {
    padding: 8px;
    widows: 15%;
    border-radius: 8px;
}

/* Buttons */

.actions {
    display: flex;
    justify-content: space-around;
    margin-top: 20px;
    width: 100%;
}

.btn {
    border: none;
    border-radius: 8px;
    padding: 10px 20px;
    cursor: pointer;
    font-size: 14px;
    transition: all 0.3s;
    width: 130px;
    /* Asegurar que ambos botones tengan el mismo tamaño */
}

.edit-profile-btn {
    background-color: #e57a44;
    /* Naranja Clash Royale */
    color: white;
}

.change-password-btn {
    background-color: #6c8ae4;
    /* Azul Clash Royale */
    color: white;
}

.btn:hover {
    transform: translateY(-2px);
    box-shadow: 0 5px 10px rgba(0, 0, 0, 0.2);
}
</style>
