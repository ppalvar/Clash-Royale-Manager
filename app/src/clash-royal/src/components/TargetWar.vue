<template>
  <div class="target-war">
    <h3>Fecha: {{ war.date }}</h3>
    <button class="btn-info" v-if="!clanesOrPlayers" @click="clanesOrPlayers = !clanesOrPlayers">Clanes</button>
    <button class="btn-info" v-else @click="clanesOrPlayers = !clanesOrPlayers">Jugadores</button>

    <TableInfo v-if="!clanesOrPlayers">
      <template #thead>
        <th>Clan</th>
        <th>Trofeos Ganados</th>
        <th>Acciones</th>
      </template>

      <template #tbody>
        <tr v-for="clan in clans" :key="clan.id">
          <td> {{ clan.name }} </td>
          <td>{{ clan.numberOfTrophiesObtainedInWars }}</td>
          <td>
            <img height="20px" :src="Details" @click="$emit('info', clan.id)" />
          </td>
        </tr>
      </template>
    </TableInfo>

    <TableInfo v-else>
      <template #thead>
        <th>Jugador</th>
        <th>Trofeos Ganados</th>
        <th>Acciones</th>
      </template>

      <template #tbody>
        <tr v-for="player in players" :key="player.id">
          <td> {{ player.nickname }} </td>
          <td>{{ player.numberOfTrophies }}</td>
          <td>
            <img height="20px" :src="Details" @click="$emit('info', clan.id)" />
          </td>
        </tr>
      </template>
    </TableInfo>

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
import { API_URL } from '@/config';
import axios from 'axios';

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
      players: [],
      clans: [],
      clanesOrPlayers: false,
      Edit,
      Delete,
      Details,
    }
  },

  mounted() {
    this.getClans();
    this.getPlayers();
  },

  methods: {
    getPlayers() {
      axios.get(`${API_URL}/players/best-in-war/${this.war.id}`)
        .then(res => {
          this.players = res.data.players;
        })
        .catch(error => {
          this.error = error.response.data;
        });
    },

    getClans() {
      axios.get(`${API_URL}/clans/clans-by-war/${this.war.id}`)
        .then(res => {
          this.clans = res.data.clans;
        })
        .catch(error => {
          this.error = error.response.data;
        });
    },
  }
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
  display: inline-block;
}

.btn-info {
  display: inline-block;
}

.actions {
  position: fixed,
}

.actions button {
  margin-right: 10px;
}
</style>