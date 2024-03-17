<template>
    <div class="contener-img-carta">
        <img :src="selectRandomImg()" class="img-carta">
    </div>
</template>

<script>
import cartaImg from '../assets/carta.jpg'

export default {
    data() {
        return {
            options: [
                cartaImg,
            ],
        }
    },

    methods: {
        selectRandomImg() {
            // const n = parseInt((15 * Math.random() + 1).toString())
            return this.options[0]
        },
    },
}
</script>

<style>
.contener-img-carta {
    padding: 5px;
    text-align: center;
    cursor: pointer;
    display: inline-block;
}

.img-carta {
    width: 45px;
    height: 45px;
}
</style>