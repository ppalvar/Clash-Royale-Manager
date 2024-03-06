<template>
    <div class="search-filter-container">
        <SearchBox />
        <SelectTypeEntity @search-entity="changeTypeEntity" />
    </div>
</template>

<script>
import SearchBox from "../components/SearchBox.vue"
import SelectTypeEntity from "../components/SelectTypeEntity.vue"

export default {
    components: {
        SearchBox,
        SelectTypeEntity,
    },

    data() {
        return {
            entityType: 'jugadores',
        }
    },

    methods:{
        changeTypeEntity(entityType) {
            this.$emit('search-entity', entityType)
        }
    },
}
</script>

<style>
.search-filter-container {
    margin-bottom: 20px;
    position: relative;
}
</style>