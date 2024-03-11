<template>
    <ErrorPopup v-if="error != ''" :msg="error"></ErrorPopup>

    <div class="actions">
        <div class="card__subtitle">Contrase&ntilde;a Actual</div>
        <div class="card__subtitle">Nueva Contrase&ntilde;a</div>
    </div>
    
    <div class="actions">
        <input type="password" v-model="old_password">
        <input type="password" v-model="new_password">
    </div>
    
    <div class="actions">
        <div 
            class="btn edit-profile-btn" 
            @click="save()"
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
            old_password: '',
            new_password: '',
            userId: '',
            error: '',
        }
    },

    mounted() {
      this.load();
    },

    methods: {
      save() {
        axios.post(`${API_URL}/auth/change-password/${this.userId}`, {
          oldPassword: this.old_password,
          newPassword: this.new_password
        })
          .then(res => {
            res;
            this.$emit('msg', "Contraseña actualizada con éxito.");
            this.$emit('change-mode', 'info');
          })
          .catch(error => {
            this.error = error.response.data;
          });
      },

      load() {
        const token = localStorage.getItem('user-token');

        if (token) {
            const jwtPayload = JSON.parse(atob(token.split('.')[1]));

            this.userId = jwtPayload.sub;
        }
      }
  },
}
</script>
