import { ref } from "vue"

const auth = ref(false)

const typeEntity = {
    cart: 'cart',
    player: 'player',
    clan: 'clan',
}

export default {
    auth,
    typeEntity,
}