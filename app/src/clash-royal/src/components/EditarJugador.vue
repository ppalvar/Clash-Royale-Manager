<template>
    <ErrorPopup v-if="error != ''" :msg="error"></ErrorPopup>
    <SuccessPopup v-if="msg != ''" :msg="msg"></SuccessPopup>

    <CrearEntity>
        <template #entity>
            <h2>Editar Jugador</h2>
        </template>

        <template #form>
            <tr>
                <th>
                    <label for="code">C&oacute;digo</label>
                </th>
                <td>
                    <input type="text" placeholder="C&oacute;digo" required id="code" v-model="code" /><br>
                </td>
                <th>
                    <label for="apodo">Apodo</label>
                </th>
                <td>
                    <input type="text" placeholder="Apodo" required id="apodo" v-model="nickname" /><br>
                </td>
                <th class="rigth">
                    <label for="nivel">Nivel</label>
                </th>
                <td class="rigth">
                    <input type="number" id="nivel" required placeholder="0.0" v-model="level"/><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="victorias">Victorias</label>
                </th>
                <td>
                    <input type="number" id="victorias" required placeholder="0.0" v-model="numberOfWins"/><br>
                </td>
                <th class="rigth">
                    <label for="trofeos">Trofeos</label>
                </th>
                <td class="rigth">
                    <input type="number" id="trofeos" required placeholder="0.0" v-model="numberOfTrophies"/><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="cartas">Cartas encontradas</label>
                </th>
                <td>
                    <input type="number" id="cartas" required placeholder="0.0" v-model="numberOfCardsFound"/><br>
                </td>
                <th class="rigth">
                    <label for="racha">Mayor racha</label>
                </th>
                <td class="rigth">
                    <input type="number" id="racha" required placeholder="0.0" v-model="maximunTrophiesAchieved"/><br>
                </td>
            </tr>
            <tr></tr>
            <tr>
                <td></td>
                <td>
                    <div class="btn edit-profile-btn" @click="updatePlayer()">Editar</div>
                </td>
                <td>
                    <div class="btn change-password-btn" @click="cancel()">Cancelar</div>
                </td>
                <td></td>
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
            code: '',
            nickname: '',
            level: '',
            numberOfTrophies: '',
            numberOfWins: '',
            maximunTrophiesAchieved: '',
            numberOfCardsFound: '',

            msg: '',
            error: ''
        }
    },

    mounted() {
        this.loadData();
    },

    methods: {
        loadData() {
            axios.get(`${API_URL}/players/${this.playerId}`)
                .then(res => {
                    this.code = res.data.code;
                    this.nickname = res.data.nickname;
                    this.level = res.data.level;
                    this.numberOfTrophies = res.data.numberOfTrophies;
                    this.numberOfWins = res.data.numberOfWins;
                    this.maximunTrophiesAchieved = res.data.maximunTrophiesAchieved;
                    this.numberOfCardsFound = res.data.numberOfCardsFound;
                })
                .catch(error => {
                    this.error = error.response.data;
                });
        },
        
        updatePlayer() {
            axios.post(`${API_URL}/admin/update-player/${this.playerId}`, {
                code: this.code,
                nickname: this.nickname,
                level: this.level,
                numberOfTrophies: this.numberOfTrophies,
                numberOfWins: this.numberOfWins,
                maximunTrophiesAchieved: this.maximunTrophiesAchieved,
                numberOfCardsFound: this.numberOfCardsFound,
            })
                .then(res => {
                    
                    res;
                    this.error='';
                    this.msg = `Se ha actualizado el jugador "${this.nickname}" correctamente.`;

                    this.code = '';
                    this.nickname = '';
                    this.level = '';
                    this.numberOfTrophies = '';
                    this.numberOfWins = '';
                    this.maximunTrophiesAchieved = '';
                    this.numberOfCardsFound = '';
                })
                .catch(error => {
                    this.error = error.response.data;
                });
        },

        async cancel() {
            await this.$router.push('/jugador');
            location.reload()
        }
    },
}
</script>

<style>
/* tr .rigth {
    position: relative;
    left: 5rem;
} */

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