<template>
    <ErrorPopup v-if="error != ''" :msg="error"></ErrorPopup>

    <div class="actions">
        <div class="card__subtitle">Usuario</div>
        <div class="card__subtitle">Correo</div>
    </div>
    
    <div class="actions">
        <input type="text" v-model="username">
        <input type="email" v-model="email">
    </div>
    
    <div class="actions">
        <div 
            class="btn edit-profile-btn" 
            @click="update()"
            >Guardar</div>
            <div 
            class="btn change-password-btn"
            @click="$emit('change-mode', 'info')"
        >Cancelar</div>
    </div>
</template>

<script>
import ErrorPopup from './ErrorPopup.vue';
import { API_URL } from '@/config';
import axios from 'axios';

export default {
    components: {
        ErrorPopup,
    },

    data() {
        return {
            username: '',
            email: '',
            userId: '',
            error: '',
        }
    },

    mounted() {
        this.getInfo();
    },

    methods: {
        getInfo() {
            const token = localStorage.getItem('user-token');

            if (token) {
                const jwtPayload = JSON.parse(atob(token.split('.')[1]));

                this.username = jwtPayload.given_name;
                this.email = jwtPayload.email;
                this.userId = jwtPayload.sub;
            }
        },

        update() {
            axios.put(`${API_URL}/auth/update-account/${this.userId}`, {
                username: this.username,
                email: this.email
            })
            .then(res => {
                localStorage.setItem('user-token', res.data.token);

                this.$emit('msg', "Perfil actualizado con éxito.");
                this.$emit('change-mode', 'info');
            })
            .catch(error => {
                this.error = error.response.data;
            });
    },
  },
}
</script>
