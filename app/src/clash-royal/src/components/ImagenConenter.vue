<template>
    <div class="contener-img">
        <img :src="selectRandomImg()" class="img">
    </div>
</template>

<script>
import img1 from '../assets/personaje1.jpg'
import img2 from '../assets/personaje2.jpg'
import img3 from '../assets/personaje3.jpg'
import img4 from '../assets/personaje4.jpg'
import img5 from '../assets/personaje5.jpg'
import img6 from '../assets/personaje6.jpg'
import img7 from '../assets/personaje7.jpg'
import img8 from '../assets/personaje8.jpg'
import img9 from '../assets/personaje9.jpg'
import img10 from '../assets/personaje10.jpg'
import img11 from '../assets/personaje11.jpg'
import img12 from '../assets/personaje12.jpg'
import img13 from '../assets/personaje13.jpg'
import img14 from '../assets/personaje14.jpg'
import img15 from '../assets/personaje15.jpg'
import img16 from '../assets/personaje16.jpg'

export default {
    data() {
        return {
            options: [
                img1, img2, img3, img4,
                img5, img6, img7, img8,
                img9, img10, img11, img12,
                img13, img14, img15, img16,
            ],
        }
    },

    methods: {
        selectRandomImg() {
            const n = parseInt((15 * Math.random() + 1).toString())
            return this.options[n]
        },
    },
}
</script>

<style>
.contener-img {
    padding: 5px;
    text-align: left;
    cursor: pointer;
}
</style>