<template>
  <div class="challenge-list">
    <region-card v-for="region in regions" :key="region.id" :region="region" />
  </div>

  {{ regions }}
</template>

<script>
import RegionCard from '@/components/RegionCard.vue';

export default {
  props: {
    regions: []
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