<script>
import RouterLink from 'vue-router'

export default {
    components: {
        RouterLink,
    },
}
</script>

<template>
    <div class="mininav">
        <RouterLink to="/carta">Cartas</RouterLink> |
        <RouterLink to="/mazo">Mazos</RouterLink>
    </div>
</template>

<style>
.mininav a {
    display: inline-block;
    color: #f2f2f2;
    text-align: center;
    padding: 5px 7px;
    text-decoration: none;
    font-weight: bold;
    transition: all 0.3s;
}

.mininav {
    position: relative;
    left: 30rem;
}
</style>