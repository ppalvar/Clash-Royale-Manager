<template>
    <div class="challenge-card">
        <h3>{{ region_card.region }}</h3>
        <p>{{ region_card.card }}</p>
    </div>
</template>

<script>
export default {
    props: {
        region_card: Object
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