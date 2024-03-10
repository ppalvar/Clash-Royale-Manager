<template>
    <WindowsInfo :oneColumn="false">
        <template #entity>
            <h2>Jugador</h2>
        </template>
        <template #column1>
            
        </template>
        <template #column2>
            <div class="detail">
                <h3>Usuario</h3>
                <p> {{ username }} </p>
            </div>
            <div class="detail">
                <h3>Correo</h3>
                <p> {{ email }} </p>
            </div>
            <div class="detail">
                <h3>Contrase&ntilde;a</h3>
                <p> {{ password }} </p>
            </div>
        </template>
    </WindowsInfo>
</template>

<script>
import WindowsInfo from "../components/WindowsInfo.vue"

export default {
    data: {
        username: '',
        email: '',
        password: ''
    },

    components: {
        WindowsInfo,
    },

    methods: {
        authenticated() {
        axios.get(`${API_URL}/auth/login`)
            .then(res => {
            localStorage.setItem('user-token', res.data.token);

            this.$emit('authenticated', this.user);
            this.$router.push('/');
            })
            .catch(error => {
            this.error = error.response.data;
            });
        },
    },
}
</script>