<template>
  <div class="target-war">
    <h3>Fecha: {{ war.date }}</h3>
    <TableInfo>
      <template #thead>
        <th>Clan</th>
        <th>Trofeos Ganados</th>
        <th>Acciones</th>
      </template>

      <template #tbody>
        <tr v-for="clan in war.clanes" :key="clan.id">
          <td> {{ clan.clan.nombre }} </td>
          <td>{{ clan.numberOfPrizes }}</td>
          <td>
            <img height="20px" :src="Details" @click="$emit('info', clan.id)" />
          </td>
        </tr>
      </template>
    </TableInfo>

    <br>

    <td class="actions">
      <img v-if="isUserAuthenticated" height="20px" :src="Edit" @click="$emit('edit', war.id)" />
      <img v-if="isUserAuthenticated" height="20px" :src="Delete" @click="$emit('delete', war.id)" />
    </td>
  </div>
</template>

<script>
import TableInfo from './TableInfo.vue';
import Edit from '@/assets/svg/edit.svg';
import Delete from '@/assets/svg/delete.svg';
import Details from '@/assets/svg/details.svg';
import { isAuthenticated } from '@/auth/auth';

export default {
  props: {
    war: {
      type: Object,
    }
  },

  components: {
    TableInfo,
  },

  computed: {
      isUserAuthenticated() {
          return isAuthenticated();
      }
  },

  data() {
    return {
      Edit,
      Delete,
      Details,
    }
  },
}
</script>

<style>
.target-war {
  background-color: rgba(0, 0, 0, 0.75);
  border-radius: 10px;
  padding: 20px;
  color: #d1d2d3;
  margin: 10px;
  transition: transform 0.3s ease;
  text-align: center;
}

.date-war {
  margin-bottom: 10px;
  display: block;
}

.target-war h3 {
  color: #e9c46a;
}

.actions {
  position: fixed,

}

.actions button {
  margin-right: 10px;
}
</style>