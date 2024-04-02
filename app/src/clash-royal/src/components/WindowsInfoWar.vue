<template>
  <div class="target-list">
    <TargetWar v-for="war in wars" :key="war.id" :war="war" @info="infoClan" @edit="editWar" @delete="deleteWar" />
  </div>
</template>

<script>
import TargetWar from '@/components/TargetWar.vue';

export default {
  props: {
    wars: []
  },

  components: {
    TargetWar
  },

  methods: {
    infoClan(id) {
      this.$emit('info', id)
    },

    editWar(id) {
      this.$emit('edit', id)
    },

    deleteWar(id) {
      this.$emit('delete', id)
    },
  },
}
</script>

<style>
.target-list {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
  gap: 20px;
  padding: 20px;
}
</style>