<template>
  <ErrorPopup v-if="error != ''" :msg="error"></ErrorPopup>
  
  <div class="register-container">
    <h2>Registro</h2>
    <form class="register-form"  @submit.prevent="authenticated">
      
      <input type="text" placeholder="Usuario" v-model="username" required /><br />
      <input type="email" placeholder="Correo" v-model="email" required /><br />
      <input type="password" placeholder="Contraseña" v-model="password" required /><br />
      <button type="submit">Entrar</button>
    </form>
  </div>
</template>

<script>
import ErrorPopup from '@/components/ErrorPopup.vue';
import { API_URL } from '@/config';
import axios from 'axios';

export default {
  components: {
    ErrorPopup
  },
  data() {
    return {
      username: '',
      email: '',
      password: '',
      error: ''
    }
  },

  methods: {
    authenticated() {
      axios.post(`${API_URL}/auth/register`, {
        username: this.username,
        email: this.email,
        password: this.password
      })
        .then(async res => {
          localStorage.setItem('user-token', res.data.token);

          this.$emit('authenticated', this.user);
          await this.$router.push('/');
          location.reload();
        })
        .catch(error => {
          this.error = error.response.data;
        });
    },
  },
}
</script>

<style>
.register-container {
  background-color: rgba(0, 0, 0, 0.75);
  width: 250px;
  margin: 50px auto;
  padding: 20px;
  border-radius: 15px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.5);
}

.register-container h2 {
  color: #ffde00;
  text-shadow: 1px 1px 2px #000000;
}

.register-form {
  display: flex;
  flex-direction: column;
}

.register-form input {
  margin-bottom: 10px;
  padding: 10px;
  border: none;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.25);
}

.register-form button {
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

.register-form button:hover {
  background-color: #f1c40f;
}
</style>