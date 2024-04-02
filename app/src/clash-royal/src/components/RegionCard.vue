<template>
    <div class="challenge-card">
        <h3>{{ region.name }}</h3>
        <h4>M&aacute;s donadas:</h4> 
        <p>{{ region.card }}</p>
        
        <h4> Mejor clan: </h4>
        <p>🏆{{ region.clan.tropheos }}  {{ region.clan.name }}</p>
    </div>
</template>

<script>
export default {
    props: {
        region: Object
    },
}
</script>

<style scoped>
.challenge-card {
    background: #264653;
    border-radius: 10px;
    padding: 20px;
    color: #d1d2d3;
    margin: 10px;
    transition: transform 0.3s ease;
}

.challenge-card h3 {
    color: #e9c46a;
}

.challenge-card p {
    color: #f4a261;
}

.info span {
    display: inline-block;
    margin-right: 10px;
    color: #2a9d8f;
}

.actions button {
    margin-right: 10px;
}
</style>