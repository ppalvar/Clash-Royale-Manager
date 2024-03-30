<template>
    <div class="btn" @click="to_back()">Atrás</div>

    <WindowsInfo :oneColumn="false">
        <template #entity>
            <h2>Jugador</h2>
            <div class="info-code">
                <h4>{{ code }}</h4>
            </div>
        </template>
        <template #column1>
            <div class="detail">
                <h3>Apodo</h3>
                <p class="clan-name"> {{ apodo }} </p>
            </div>
            <div class="detail">
                <h3>Cant. de cartas encontradas</h3>
                <p class="clan-description"> {{ cartas }} </p>
            </div>
            <div class="detail">
                <h3>Cant. de trofeos</h3>
                <p class="clan-trophies-in-wars"> {{ trofeos }} </p>
            </div>
        </template>
        <template #column2>
            <div class="detail">
                <h3>Nivel</h3>
                <p class="clan-members"> {{ nivel }} </p>
            </div>
            <div class="detail">
                <h3>Cant. de victorias</h3>
                <p class="clan-trophies-to-enter"> {{ victorias }} </p>
            </div>
            <div class="detail">
                <h3>Max. racha de trofeos</h3>
                <p class="clan-region"> {{ racha }} </p>
            </div>
        </template>
    </WindowsInfo>
</template>

<script>
import WindowsInfo from "../components/WindowsInfo.vue"

export default {
    props:{
        code: {
            type: String,
            default: 'CODE'
        },
        apodo: {
            type: String,
            default: '',
        },
        nivel: {
            type: Number,
            default: 0,
        },
        cartas: {
            type: Number,
            default: 0,
        },
        victorias: {
            type: Number,
            default: 0,
        },
        trofeos: {
            type: Number,
            default: 0,
        },
        racha: {
            type: Number,
            default: 0,
        },
    },

    components: {
        WindowsInfo,
    },

    methods: {
        to_back() {
            let url = `/jugador`;
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

.info-code {
    text-align: center;
    margin: 8px auto;
}

</style>