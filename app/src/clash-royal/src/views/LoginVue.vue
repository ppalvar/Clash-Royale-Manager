<script>
import Login from '@/components/LoginVue.vue'
import Footer from '@/components/FooterDefault.vue'
import Banner from '@/components/BannerDefault.vue'
import consts from '@/router/auth'

export default {
  components: {
    Login,
    Footer,
    Banner,
  },

  data() {
    return {
      auth: consts.auth,
      username: consts.username,
    }
  },

  methods: {
    change(username) {
      this.username = consts.username = username
      this.$router.push('/')
    },
  },
}
</script>

<template>
    <Login v-if="!auth" @authenticated="change"/>
    <Banner v-else>
      <template #body>
        <h1>Usted se ha autenticado</h1>
        <p>Bievenido administrador {{ username }}</p>
      </template>
    </Banner>
    <Footer />
</template>