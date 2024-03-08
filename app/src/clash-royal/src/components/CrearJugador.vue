<template>
    <CrearEntity>
        <template #entity>
            <h2>Crear Jugador</h2>
        </template>

        <template #form>
            <tr>
                <th>
                    <label for="apodo">Apodo</label>
                </th>
                <td>
                    <input type="text" placeholder="Apodo" required id="apodo" /><br>
                </td>
                <th class="rigth">
                    <label for="nivel">Nivel</label>
                </th>
                <td class="rigth">
                    <input type="number" id="nivel" required placeholder="0.0"><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="victorias">Victorias</label>
                </th>
                <td>
                    <input type="number" id="victorias" required placeholder="0.0"><br>
                </td>
                <th class="rigth">
                    <label for="trofeos">Trofeos</label>
                </th>
                <td class="rigth">
                    <input type="number" id="trofeos" required placeholder="0.0"><br>
                </td>
            </tr>
            <tr>
                <th>
                    <label for="cartas">Cartas encontradas</label>
                </th>
                <td>
                    <input type="number" id="cartas" required placeholder="0.0"><br>
                </td>
                <th class="rigth">
                    <label for="racha">Mayor racha</label>
                </th>
                <td class="rigth">
                    <input type="number" id="racha" required placeholder="0.0"><br>
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
tr .rigth {
    position: relative;
    left: 5rem;
}
</style>