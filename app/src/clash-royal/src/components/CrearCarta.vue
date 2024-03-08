<template>
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
                    <input type="text" placeholder="Nombre" required id="nombreCarta" /><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="descripcionCarta" class="descripcion-label">Descripcion de Carta</label>
                </th>
                <td>
                    <textarea type="text" placeholder="Descripcion" required id="descripcionCarta"></textarea><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="costo">Costo de elixir</label>
                </th>
                <td>
                    <input type="number" id="costo" required placeholder="0.0"><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="calidad">Calidad</label>
                </th>
                <td>
                    <select id="calidad">
                        <option value="buena" selected>Buena</option>
                        <option value="media">Media</option>
                        <option value="baja">Baja</option>
                    </select>
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
</style>
