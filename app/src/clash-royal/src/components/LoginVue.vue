<template>
  <ErrorPopup v-if="error != ''" :msg="error"></ErrorPopup>
  
  <div class="login-container">
    <h2>Iniciar Sesión</h2>
    <form class="login-form"  @submit.prevent="authenticated">
      
      <input type="text" placeholder="Usuario" v-model="user" required /><br />
      <input type="password" placeholder="Contraseña" v-model="password" required /><br />
      <button type="submit">Entrar</button>
    </form>
  </div>
</template>

<script>
import ErrorPopup from './ErrorPopup.vue';
import { API_URL } from '@/config';
import axios from 'axios';

export default {
  components: {
    ErrorPopup
  },
  data() {
    return {
      user: '',
      password: '',
      error: ''
    }
  },

  methods: {
    authenticated() {
      axios.post(`${API_URL}/auth/login`, {
        email: this.user,
        password: this.password
      })
        .then(async res => {
          localStorage.setItem('user-token', res.data.token);

          this.$emit('authenticated', this.user);
          await this.$router.push('/');
          location.reload()
        })
        .catch(error => {
          this.error = error.response.data;
        });
    },
  },
}
</script>

<style>
.login-container {
  background-color: rgba(0, 0, 0, 0.75);
  width: 250px;
  margin: 50px auto;
  padding: 20px;
  border-radius: 15px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.5);
}

.login-container h2 {
  color: #ffde00;
  text-shadow: 1px 1px 2px #000000;
}

.login-form {
  display: flex;
  flex-direction: column;
}

.login-form input {
  margin-bottom: 10px;
  padding: 10px;
  border: none;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.25);
}

.login-form button {
  background-color: #ffde00;
  color: #121212;
  padding: 10px;
  border: none;
  border-radius: 8px;
  cursor: pointer;
  font-weight: bold;
  text-transform: uppercase;
  transition: background-color 0.3s;
}

.login-form button:hover {
  background-color: #f1c40f;
}
</style>