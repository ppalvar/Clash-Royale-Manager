<template>
  <div class="challenge-list">
    <challenge-card v-for="challenge in challenges" :key="challenge.id" :challenge="challenge" />
  </div>
</template>

<script>
import ChallengeCard from '@/components/ChallengeCard.vue';

export default {
  props: {
    challenges: []
  },

  components: {
    ChallengeCard,
  },
}
</script>

<style scoped>
.challenge-list {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr 1fr;
  gap: 20px;
  padding: 20px;
}
</style>