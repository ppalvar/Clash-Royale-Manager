<template>
  <div class="challenge-list">
    <region-card v-for="region_card in best_cards" :key="region_card.id" :region_card="region_card" />
  </div>
</template>

<script>
import RegionCard from '@/components/RegionCard.vue';

export default {
  props: {
    best_cards: []
  },

  components: {
    RegionCard,
  },
}
</script>

<style scoped>
.challenge-list {
  display: grid;
  display: grid;
  grid-template-columns: 1fr 1fr 1fr 1fr 1fr;
  gap: 10px;
  gap: 20px;
  padding: 20px;
}
</style>