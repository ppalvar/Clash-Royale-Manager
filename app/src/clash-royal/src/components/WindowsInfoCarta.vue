<template>
    <div class="btn" @click="to_back()">Atrás</div>

    <WindowsInfo :oneColumn=true>
        <template #entity>
            <h2>Informaci&oacute;n de Carta</h2>
        </template>
        <template #column1>
            <div class="detail">
                <h3>Nombre</h3>
                <p class="clan-name"> {{ nombre }} </p>
            </div>
            <div class="detail">
                <h3>Calidad</h3>
                <p class="clan-name"> {{ calidad }} </p>
            </div>
            <div class="detail">
                <h3>Costo de elixir</h3>
                <p class="clan-name"> {{ costo }} </p>
            </div>
            <div class="detail">
                <h3>Descripción</h3>
                <p class="clan-description"> {{ descripcion }} </p>
            </div>
        </template>
    </WindowsInfo>
</template>

<script>
import WindowsInfo from "../components/WindowsInfo.vue"

export default {
    props: {
        nombre: {
            type: String,
            default: 'cart',
        },
        descripcion: {
            type: String,
            default: 'cart',
        },
        calidad: {
            type: String,
            default: 'media',
        },
        costo: {
            type: Number,
            default: 5,
        },
    },
    components: {
        WindowsInfo,
    },

    methods: {
        to_back() {
            let url = `/carta`;
            this.$router.push(url);
        }
    }
}
</script>

<style scoped>
.btn {
  text-align: center;
  height: 1em;
  padding: 10px;
  border: solid 1px;
  background-color: #ffde00;
  border-radius: 0.5em;
  color: #121212;
  margin-left: 15px;
  margin-bottom: 15px;
  cursor: pointer;
  margin: 20px auto;
}

.btn:hover {
  background-color: #f1c208dd;
}
</style>