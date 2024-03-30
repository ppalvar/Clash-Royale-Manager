<template>
    <ErrorPopup v-if="error != ''" :msg="error"></ErrorPopup>
    <SuccessPopup v-if="msg != ''" :msg="msg"></SuccessPopup>

    <CrearEntity>
        <template #entity>
            <h2>Editar Batalla</h2>
        </template>

        <template #form>
            <tr>
                <th>
                    <label for="nombreBattle" readonly>Jugador 1</label>
                </th>
                <td>
                    <input v-model="player1" readonly/>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="nombreBattle">Jugador 2</label>
                </th>
                <td>
                    <input v-model="player2" readonly/>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="costo">Cantidad de Trofeos</label>
                </th>
                <td>
                    <input type="number" id="costo" placeholder="0.0" v-model="numberOfTrophies"><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label>Ganador</label>
                </th>
                <td>
                    Player 1<input type="checkbox" v-model="winner1">
                    Player 2<input type="checkbox" v-model="winner">
                </td>
            </tr>
            <tr>
                <th>
                    <label for="fecha">Fecha</label>
                </th>
                <td>
                    <input type="input" id="fecha" :value="date" readonly="true"><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="duration">Duraci&oacute;n</label>
                </th>
                <td>
                    <input type="datetime-local" id="duration" placeholder="0.0" v-model="duration"><br>
                </td>
            </tr>
            <tr>
                <td></td>
                <div class="actions">
                    <div class="btn edit-profile-btn" @click="updateBatalla()">Actualizar</div>
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
        playerId: {
            type: String,
        },
        date: {
            type: Date,
        }
    },

    components: {
        CrearEntity,
        SuccessPopup,
        ErrorPopup,
    },

    data() {
        return {            
            Player2Id: '',
            winner: false,
            numberOfTrophies: 0,
            duration: new Date(),
            
            winner1: !this.winner,
            player1: '',
            player2: '',
            msg: '',
            error: ''
        }
    },

    mounted() {
        this.loadData();
    },

    methods: {
        loadData() {
            axios.get(`${API_URL}/battles/${this.playerId}/${this.date}`)
                .then(res => {

                    this.Player2Id = res.data.player2Id;
                    this.winner = res.data.winner;
                    this.numberOfTrophies = res.data.numberOfTrophies;
                    this.duration = res.data.duration;

                    this.player1 = res.data.player1Name;
                    this.player2 = res.data.player2Name;
                })
                .catch(error => {
                    this.error = error.response.data;
                });
        },

        updateBatalla() {
            axios.post(`${API_URL}/admin/update-battle/${this.playerId}/${this.date}`, {
                player2Id: this.Player2Id,
                winner: this.winner,
                numberOfTrophies: this.numberOfTrophies,
                duration: this.duration
            })
                .then(res => {

                    res;
                    this.error = '';
                    this.msg = `Se ha actualizado la batalla correctamente.`;
                })
                .catch(error => {
                    this.error = error.response.data;
                });
        },

        async cancel() {
            await this.$router.push('/battle');
            location.reload()
        }
    },
}
</script>