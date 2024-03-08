<template>
    <CrearEntity>
        <template #entity>
            <h2>Crear Jugador</h2>
        </template>

        <template #form>
            <tr>
                <th>
                    <label for="nombreClan">Nombre</label>
                </th>
                <td>
                    <input type="text" placeholder="Nombre" required id="nombreClan" /><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="descripcion" class="descripcion-label">Descripcion</label>
                </th>
                <td>
                    <textarea type="text" placeholder="Descripcion" required id="descripcionCarta"></textarea><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="jugadores">Miembros</label>
                </th>
                <td>
                    <input type="number" id="jugadores" required placeholder="0.0"><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="trofeos">Trofeos</label>
                </th>
                <td>
                    <input type="number" id="trofeos" required placeholder="0.0"><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="region">Region</label>
                </th>
                <td>
                    <select id="region">
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
                    <input type="number" id="condicion" required placeholder="0.0"><br>
                </td>
            </tr>
        </template>
    </CrearEntity>
</template>

<script>
import CrearEntity from '../components/CrearEntity.vue'

export default {
    components: {
        CrearEntity,
    },
}
</script>