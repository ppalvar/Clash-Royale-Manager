<template>
    <div class="btn" @click="to_back()">Atrás</div>

    <WindowsInfo>
        <template #entity>
            <h2>Carta</h2>
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

        <template #column2>
            <div class="detail">
                <h3>Tipo</h3>
                <p class="clan-description"> {{ type }} </p>
            </div>
            <div class="detail" v-if="type != 'hechizo'">
                <h3>Puntos de vida</h3>
                <p class="clan-description"> {{ lifePoints }} </p>
            </div>
            <div class="detail" v-if="type != 'estructura'">
                <h3>Daño en Área</h3>
                <p class="clan-description"> {{ damageInArea }} </p>
            </div>
            <div class="detail" v-if="type == 'tropa'">
                <h3>Número de unidades</h3>
                <p class="clan-description"> {{ numberOfUnits }} </p>
            </div>
            <div class="detail" v-if="type == 'hechizo'">
                <h3>Radio</h3>
                <p class="clan-description"> {{ radio }} </p>
            </div>
            <div class="detail" v-if="type == 'hechizo'">
                <h3>Duración</h3>
                <p class="clan-description"> {{ duration }} </p>
            </div>
            <div class="detail" v-if="type == 'hechizo'">
                <h3>Daño a torres</h3>
                <p class="clan-description"> {{ damageToTowers }} </p>
            </div>
        </template>
    </WindowsInfo>
</template>

<script>
import WindowsInfo from "@/components/WindowsInfo.vue"

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
        lifePoints: {
            type: Number,
            default: 5,
        },
        damageToTowers: {
            type: Number,
            default: 5,
        },
        damageInArea: {
            type: Number,
            default: 5,
        },
        numberOfUnits: {
            type: Number,
            default: 5,
        },
        radio: {
            type: Number,
            default: 5,
        },
        duration: {
            type: Number,
            default: 5,
        },
        type: {
            type: String,
            default: 'tropa',
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