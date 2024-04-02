<template>
    <ErrorPopup v-if="error != ''" :msg="error"></ErrorPopup>
    <SuccessPopup v-if="msg != ''" :msg="msg"></SuccessPopup>

    <CrearEntity>
        <template #entity>
            <h2>{{ mode === 'edit' ? 'Editar' : 'Crear' }} Reto</h2>
        </template>

        <template #form>
            <tr>
                <th>
                    <label for="nombreChallenge">Nombre</label>
                </th>
                <td>
                    <input id="nombreChallenge" v-model="challenge.name" placeholder="Nombre del Reto" required />
                </td>
            </tr>
            <tr>
                <th>
                    <label for="descripcionChallenge" class="descripcion-label">Descripcion</label>
                </th>
                <td>
                    <textarea id="descripcionChallenge" v-model="challenge.description" placeholder="Descripción" required></textarea>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="costoChallenge">Costo</label>
                </th>
                <td>
                    <input type="number" id="costoChallenge" v-model="challenge.cost" placeholder="0.0" required />
                </td>
            </tr>
            <tr>
                <th>
                    <label for="numberOfAdmissibleDefeatsChallenge">N&uacute;mero de muertes permitidas</label>
                </th>
                <td>
                    <input type="number" id="numberOfAdmissibleDefeatsChallenge" v-model="challenge.numberOfAdmissibleDefeats" placeholder="0.0" required />
                </td>
            </tr>
            <tr>
                <th>
                    <label for="durationChallenge">Duraci&oacute;n</label>
                </th>
                <td>
                    <input type="number" id="durationChallenge" v-model="challenge.duration" placeholder="0.0" required />
                </td>
            </tr>
            <tr>
                <th>
                    <label for="maximumLevelChallenge">Nivel M&acute;ximo</label>
                </th>
                <td>
                    <input type="number" id="maximumLevelChallenge" v-model="challenge.maximumLevel" placeholder="0.0" required />
                </td>
            </tr>
            <tr>
                <th>
                    <label for="dateChallenge">Fecha</label>
                </th>
                <td>
                    <input type="date" id="dateChallenge" v-model="challenge.date" required />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <button class="btn" @click="ejecuteAction()">{{ mode === 'edit' ? 'Editar' : 'Crear' }} Reto</button>
                </td>
                <td>
                    <div class="btn btn-cancel" @click="cancel()">Cancelar</div>
                </td>
                <td></td>
            </tr>
        </template>
    </CrearEntity>
</template>

<script>
import CrearEntity from '@/components/CrearEntity.vue';
import ErrorPopup from '@/components/ErrorPopup.vue';
import SuccessPopup from '@/components/SuccessPopup.vue';
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    props: ['mode', 'challengeData', 'challengeId'],
    data() {
        return {
            challenge: this.challengeData || {},
            error: '',
            msg: ''
        };
    },
    components: {
        CrearEntity,
        ErrorPopup,
        SuccessPopup,
    },
    methods: {
        async cancel() {
            await this.$router.push('/challenge');
            location.reload()
        },

        ejecuteAction() {
            if (this.mode === "edit") {
                this.updateChallenge();
            } else {
                this.createChallenge();
            }
        },

        createChallenge() {
            axios.post(`${API_URL}/admin/createchallenge`, this.challenge)
                .then(res => {
                    this.error = '';
                    this.msg = `Se ha agregado el reto "${res.data.name}".`;

                    this.challenge = {
                        "name": "",
                        "description": "",
                        "cost": 0,
                        "numberOfPrizes": 0,
                        "numberOfAdmissibleDefeats": 0,
                        "duration": 0,
                        "maximumLevel": 0,
                        "date": ""
                    };
                })
                .catch(error => {
                    this.error = error.response.data;
                });
        },

        updateChallenge() {
            axios.post(`${API_URL}/admin/update-challenge/${this.challengeId}`, this.challenge)
                .then(res => {
                    this.error = '';
                    this.msg = `Se ha actualizado el reto "${res.data.name}".`;

                    this.challenge = {
                        "name": "",
                        "description": "",
                        "cost": 0,
                        "numberOfPrizes": 0,
                        "numberOfAdmissibleDefeats": 0,
                        "duration": 0,
                        "maximumLevel": 0,
                        "date": ""
                    };
                })
                .catch(error => {
                    this.error = error.response.data;
                });
        },
    },
};
</script>

<style scoped>
form button {
    margin-top: 20px;
}

.btn-cancel {
    background-color: #6c8ae4;
    /* Azul Clash Royale */
    color: white;
}
</style>