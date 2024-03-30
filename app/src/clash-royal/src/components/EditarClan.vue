<template>
    <ErrorPopup v-if="error != ''" :msg="error"></ErrorPopup>
    <SuccessPopup v-if="msg != ''" :msg="msg"></SuccessPopup>

    <CrearEntity>
        <template #entity>
            <h2>Editar Clan</h2>
        </template>

        <template #form>
            <tr>
                <th>
                    <label for="nombreClan">Nombre</label>
                </th>
                <td>
                    <input type="text" placeholder="Nombre" required id="nombreClan" v-model="name" /><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="descripcion" class="descripcion-label">Descripcion</label>
                </th>
                <td>
                    <textarea type="text" placeholder="Descripcion" v-model="description" required
                        id="descripcionCarta"></textarea><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="lider">Lider</label>
                </th>
                <td>
                    <PlayerInputSugerence @input="liderId = $event" id="lider" />
                </td>
            </tr>
            <tr>
                <th>
                    <label for="trofeos">Trofeos</label>
                </th>
                <td>
                    <input type="number" id="trofeos" v-model="numberOfTrophies" required placeholder="0.0"><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="region">Region</label>
                </th>
                <td>
                    <select id="region" v-model="region">
                        <option value="buena" selected>Eurasia</option>
                        <option value="media">America</option>
                        <option value="baja">Otro</option>
                    </select>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="condicion">Cant. de trofeos para entrar</label>
                </th>
                <td>
                    <input type="number" v-model="condition" id="condicion" required placeholder="0.0"><br>
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
        clanId: {
            type: String,
        }
    },

    components: {
        CrearEntity,
        SuccessPopup,
        ErrorPopup,
    },

    data() {
        return {
            name: '',
            description: '',
            liderId: '',
            numberOfTrophies: 0,
            region: '',
            condition: 0,
            msg: '',
            error: ''
        }
    },

    mounted() {
        this.loadData();
    },

    methods: {
        loadData() {
            axios.get(`${API_URL}/clans/${this.clanId}`)
                .then(res => {
                    this.name = res.data.name;
                    this.description = res.data.description;
                    this.numberOfTrophies = res.data.numberOfTrophies;
                    this.liderId = res.data.liderId;
                    this.condition = res.data.numberOfTrophiesToEnter;
                    this.region = res.data.region;
                })
                .catch(error => {
                    this.error = error.response.data;
                });
        },

        updateClan() {
            axios.post(`${API_URL}/admin/update-clan/${this.clanIdId}`, {
                name: this.name,
                description: this.description,
                numberOfTrophies: this.numberOfTrophies,
                liderId: this.liderId,
                numberOfTrophiesToEnter: this.condition,
                region: this.region,
            })
                .then(res => {

                    res;
                    this.error = '';
                    this.msg = `Se ha actualizado el clan "${this.name}" correctamente.`;

                    this.name = '';
                    this.description = '';
                    this.numberOfTrophies = 0;
                    this.liderId = '';
                    this.condition = 0;
                    this.region = '';
                })
                .catch(error => {
                    this.error = error.response.data;
                });
        },

        async cancel() {
            await this.$router.push('/clan');
            location.reload()
        }
    },
}
</script>