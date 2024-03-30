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
                    <label for="typeClan">Tipo</label>
                </th>
                <td>
                    <select id="typeClan" v-model="typeClan">
                        <option value="1e2b59b1-3be6-40cf-a7de-660de6478331">Invitacion</option>
                        <option value="bd818cb4-26b0-402b-a6e8-ea8c63eb0416">Abierto</option>
                    </select>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="region">Region</label>
                </th>
                <td>
                    <select id="region" v-model="region">
                        <option value="0">Training_Camp</option>
                        <option value="1">Goblin_Stadium</option>
                        <option value="2">Bone_Pit</option>
                        <option value="3">Barbarian_Bowl</option>
                        <option value="4">PEKKAs_Playhouse</option>
                        <option value="5">Spell_Valley</option>
                        <option value="6">Builder_Workshop</option>
                        <option value="7">Royal_Arena</option>
                        <option value="8">Frozen_Peak</option>
                        <option value="9">Jungle_Arena</option>
                        <option value="10">Hog_Mountain</option>
                        <option value="11">Electro_Valley</option>
                        <option value="12">Spooky_Town</option>
                        <option value="13">Legendary_Aren</option>
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
                    <div class="btn edit-profile-btn" @click="updateClan()">Actualizar</div>
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
    props: {
        clanId: {
            type: String,
        }
    },

    components: {
        PlayerInputSugerence,
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
            typeClan: "",
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
                    this.typeClan = res.data.idType;
                    this.description = res.data.description;
                    this.numberOfTrophies = res.data.numberOfTrophiesObtainedInWars;
                    this.liderId = res.data.liderId;
                    this.condition = res.data.trophiesNeededToEnter;
                    this.region = res.data.region;
                })
                .catch(error => {
                    this.error = error.response.data;
                });
        },

        updateClan() {
            axios.post(`${API_URL}/admin/update-clan/${this.clanId}`, {
                name: this.name,
                idType: this.typeClan,
                description: this.description,
                numberOfTrophiesObtainedInWars: this.numberOfTrophies,
                liderId: this.liderId,
                trophiesNeededToEnter: this.condition,
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