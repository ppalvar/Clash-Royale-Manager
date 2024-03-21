<template>
    <ErrorPopup v-if="error != ''" :msg="error"></ErrorPopup>
    <SuccessPopup v-if="msg != ''" :msg="msg"></SuccessPopup>

    <CrearEntity>
        <template #entity>
            <h2>Crear Batalla</h2>
        </template>

        <template #form>
            <tr>
                <th>
                    <label for="nombreBattle">Jugador 1</label>
                </th>
                <td>
                    <PlayerInputSugerence @input="Player1Id = $event" />
                </td>
            </tr>
            <tr>
                <th>
                    <label for="nombreBattle">Jugador 2</label>
                </th>
                <td>
                    <PlayerInputSugerence @input="Player2Id = $event" />
                </td>
            </tr>
            <tr>
                <th>
                    <label for="costo">Cantidad de Trofeos</label>
                </th>
                <td>
                    <input type="number" id="costo" placeholder="0.0" v-model="NumberOfTrophies"><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="winner">Ganador</label>
                </th>
                <td>
                    Player 1<input type="checkbox" id="winner" v-model="winner1">
                    Player 2<input type="checkbox" id="winner" v-model="winner2">
                </td>
            </tr>
            <tr>
                <th>
                    <label for="fecha">Fecha</label>
                </th>
                <td>
                    <input type="datetime-local" id="fecha" placeholder="0.0" v-model="date"><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="duration">Duraci&oacute;n</label>
                </th>
                <td>
                    <input type="datetime-local" id="duration" placeholder="0.0" v-model="time"><br>
                </td>
            </tr>
            <tr>
                <td></td>
                <div class="actions">
                    <div class="btn edit-profile-btn" @click="createBattle()">Crear</div>
                    <div class="btn change-password-btn" @click="cancel()">Cancelar</div>
                </div>
            </tr>
        </template>
    </CrearEntity>
</template>

<script>
import CrearEntity from '@/components/CrearEntity.vue';
import PlayerInputSugerence from '@/components/PlayerInputSugerence.vue';
import SuccessPopup from '@/components/SuccessPopup.vue';
import ErrorPopup from '@/components/ErrorPopup.vue';
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    components: {
        CrearEntity,
        SuccessPopup,
        ErrorPopup,
        PlayerInputSugerence
    },
    data() {
        return {
            Player1Id: '',
            Player2Id: '',
            NumberOfTrophies: 0,
            winner1: false,
            winner2: false,
            date: null,
            time: null,
            msg: '',
            error: ''
        }
    },

    methods: {
        createBattle() {
            axios.post(`${API_URL}/admin/createbattle`, {
                player1Id: this.Player2Id.toString(),
                player2Id: this.Player1Id.toString(),
                winner: this.winner2,
                numberOfTrophies: this.NumberOfTrophies,
                date: this.date,
                duration: this.duration,
            })
                .then(res => {
                    
                    res;
                    this.error='';
                    this.msg = `Se ha agregado la batalla correctamente.`;

                    this.Player1Id = '';
                    this.Player2Id = '';
                    this.NumberOfTrophies = 0;
                    this.winner1 = false;
                    this.winner2 = false;
                    this.date = null;
                    this.time = null;
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

<style>
#nombreBattle {
    width: 15rem;
}

#descripcionBattle {
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
