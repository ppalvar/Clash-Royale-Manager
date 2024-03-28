<template>
    <CrearEntity>
        <template #entity>
            <h2>Crear Clan</h2>
        </template>

        <template #form>
            <tr>
                <th>
                    <label for="nombreClan">Nombre</label>
                </th>
                <td>
                    <input type="text" placeholder="Nombre" required id="nombreClan" v-model="nombre" /><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="descripcion" class="descripcion-label">Descripcion</label>
                </th>
                <td>
                    <textarea type="text" placeholder="Descripcion" v-model="descripcion" required id="descripcionCarta"></textarea><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="jugadores">Miembros</label>
                </th>
                <td>
                    <button @click="show = true">AgregarMiembros</button>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="trofeos">Trofeos</label>
                </th>
                <td>
                    <input type="number" id="trofeos" v-model="trofeos" required placeholder="0.0"><br>
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
                    <input type="number" v-model="condicion" id="condicion" required placeholder="0.0"><br>
                </td>
            </tr>
        </template>
    </CrearEntity>

    <Teleport to="body">
        <ReclutarJugadores :show="show" @close="setMembers" />
    </Teleport>
</template>

<script>
import CrearEntity from '@/components/CrearEntity.vue';
import ReclutarJugadores from '@/components/ReclutarJugadores.vue';

export default {
    components: {
        CrearEntity,
        ReclutarJugadores,
    },

    data() {
        return {
            show: false,
            nombre: '',
            descripcion: '',
            miembros: [],
            trofeos: 0,
            region: '',
            condicion: 0,
        }
    },

    methods: {
        setMembers(members) {
            this.miembros = members
            this.show = false
        },
    },
}
</script>
