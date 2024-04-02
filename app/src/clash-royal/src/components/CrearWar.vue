<template>
    <ErrorPopup v-if="error != ''" :msg="error"></ErrorPopup>
    <SuccessPopup v-if="msg != ''" :msg="msg"></SuccessPopup>

    <CrearEntity>
        <template #entity>
            <h2>Crear Guerra</h2>
        </template>

        <template #form>
            <tr>
                <th>
                    <label for="dateWar">Fecha</label>
                </th>
                <td>
                    <input type="date" required id="dateWar" v-model="date" /><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="jugadores">Clanes Participantes</label>
                </th>
                <td>
                    <button @click="show = true">AgregarClanes</button>
                </td>
            </tr>
        </template>
    </CrearEntity>

    <Teleport to="body">
        <AddClanesToWar :show="show" @close="setClanes" />
    </Teleport>
</template>

<script>
import CrearEntity from '@/components/CrearEntity.vue';
import SuccessPopup from '@/components/SuccessPopup.vue';
import ErrorPopup from '@/components/ErrorPopup.vue';
import { API_URL } from '@/config';
import AddClanesToWar from './AddClanesToWar.vue';
import axios from 'axios';

export default {
    components: {
        AddClanesToWar,
        CrearEntity,
        SuccessPopup,
        ErrorPopup,
    },

    data() {
        return {
            date: new Date(),
            clanes: [],
            msg: '',
            error: '',
            show: false,
        }
    },

    methods: {
        methods: {
            setClanes(clanes) {
                this.clanes = clanes;
                this.show = false;
            },
        },

        createCard() {
            axios.post(`${API_URL}/admin/createcard`, {
                name: this.nameCard,
                description: this.descriptionCard,
                elixirCost: this.costoElixir,
                quality: this.qualityCard,
            })
                .then(res => {

                    res;
                    this.error = '';
                    this.msg = `Se ha agregado la carta "${this.nameCard}".`;

                    this.nameCard = '';
                    this.descriptionCard = '';
                    this.costoElixir = '';
                    this.qualityCard = '';
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
