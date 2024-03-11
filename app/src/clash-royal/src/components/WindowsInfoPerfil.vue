<template>
    <div class="card__title">{{ username }}</div>
    <div class="card__subtitle">{{ email }}</div>
    
    <div class="actions">
        <div 
            class="btn edit-profile-btn" 
            @click="$emit('change-mode', 'edit-profile')"
            >Editar Cuenta</div>
            <div 
            class="btn change-password-btn"
            @click="$emit('change-mode', 'change-password')"
        >Cambiar Contrase&ntilde;a</div>
    </div>
</template>

<script>
export default {
    data() {
        return {
            username: '',
            email: ''
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
            }
        },
    },
}
</script>
