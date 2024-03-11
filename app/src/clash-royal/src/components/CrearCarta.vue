<template>
    <ErrorPopup v-if="error != ''" :msg="error"></ErrorPopup>
    <SuccessPopup v-if="msg != ''" :msg="msg"></SuccessPopup>

    <CrearEntity>
        <template #entity>
            <h2>Crear Carta</h2>
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
                <td></td>
                <div class="actions">
                    <div class="btn edit-profile-btn" @click="createCard()">Crear</div>
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
            msg: '',
            error: ''
        }
    },

    methods: {
        createCard() {
            axios.post(`${API_URL}/admin/createcard`, {
                name: this.nameCard,
                description: this.descriptionCard,
                elixirCost: this.costoElixir,
                quality: this.qualityCard,
            })
                .then(res => {
                    
                    res;
                    this.nameCard = '';
                    this.descriptionCard = '';
                    this.costoElixir = '';
                    this.qualityCard = '';

                    this.error='';
                    this.msg = `Se ha agregado la carta ${this.nameCard}.`;

                    this.cancel();
                })
                .catch(error => {
                    this.error = error.response.data;
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
