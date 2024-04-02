<template>
  <div class="challenge-detail">
    <h1><i class="fas fa-trophy"></i> {{ challenge.name }}</h1>
    <p>{{ challenge.description }}</p>
    <div class="challenge-info">
      <span><i class="fas fa-coins"></i> Costo: {{ challenge.cost }}</span>
      <span><i class="fas fa-gift"></i> Premios: {{ challenge.numberOfPrizes }}</span>
      <span><i class="fas fa-hourglass-end"></i> Duración: {{ challenge.duration }} horas</span>
      <span><i class="fas fa-skull-crossbones"></i> Derrotas admisibles: {{ challenge.numberOfAdmissibleDefeats
        }}</span>
    </div>
    <h2>Jugadores que completaron el reto</h2>
    <ul>
      <li v-for="player in playerChallenges" :key="player.id">
        <i class="fas fa-user"></i>
        {{ player.nickname }}   -   🏆{{ player.numberOfTrophies }}
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  props: {
    challenge: Object,
    playerChallenges: []
  },
}
</script>

<style scoped>
.challenge-detail {
  color: #d1d2d3;
  background-color: rgba(0, 0, 0, 0.75);
  padding: 20px;
  border-radius: 10px;
  margin: 20px 25%;
  display: flex;
  /* Habilita Flexbox */
  flex-direction: column;
  /* Los elementos hijos se apilan verticalmente */
  align-items: center;
  /* Centra los elementos hijos horizontalmente */
}

.challenge-detail h1,
h2 {
  color: #e9c46a;
  text-align: center;
  /* Alinea el texto al centro */
}

.challenge-info span,
ul li {
  display: block;
  margin-bottom: 10px;
  text-align: center;
  /* Alinea el texto de cada info span y lista al centro */
}

.challenge-info span i,
ul li i {
  margin-right: 8px;
}
</style>