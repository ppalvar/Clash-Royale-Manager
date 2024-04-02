<template>
    <div class="challenge-card">
        <h3>{{ challenge.name }}</h3>
        <p>{{ challenge.description }}</p>
        <div class="info">
            <span>Costo: {{ challenge.cost }}</span>
            <span>Trofeos: {{ challenge.numberOfPrizes }}</span>
            <span>Nivel M&aacute;ximo: {{ challenge.maximumLevel }}</span>
        </div>
        <div class="actions">
            <button @click="editChallenge(challenge.id)">Editar</button>
            <button @click="infoChallenge(challenge.id)">Ver M&aacute;s</button>
            <button @click="deleteChallenge(challenge.id)">Borrar</button>
        </div>
    </div>
</template>

<script>
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    props: {
        challenge: Object
    },
    methods: {
        editChallenge(id) {
            this.$router.push({ name: 'EditChallenge', params: { id } });
        },
        infoChallenge(id) {
            this.$router.push({ name: 'InfoChallenge', params: { id } });
        },
        deleteChallenge(id) {
            if (confirm('Está seguro que desea eliminar el reto seleccionado?')) {
                axios.delete(`${API_URL}/admin/delete-challenge/${id}`)
                    .then(async res => {
                        res;
                        location.reload();
                        this.msg = 'Reto eliminado con éxito.';
                    })
                    .catch(error => {
                        this.error = error.response.data;
                    });
            }
        }
    }
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