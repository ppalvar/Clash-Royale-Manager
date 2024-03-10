<template>
    <div class="profile-container">
        <slot name="entity">
            <h2>Perfil del Entity</h2>
        </slot>
        
        <div class="details">
            <div class="detail-column" :style="{ flexBasis }">
                <slot name="column1">
                    
                </slot>
            </div>

            <div class="detail-column" v-if="!oneColumn" :style="{ flexBasis }">
                <slot name="column2">
                    
                </slot>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    props: {
        oneColumn: {
            type: Boolean,
            default: false,
        },
    },

    mounted() {
        if (this.oneColumn) {
            this.flexBasis = 'calc(100% - 5px)'
        }
    },

    data() {
        return {
            flexBasis: 'calc(50% - 20px)',
        }
    },
}
</script>

<style>
.profile-container {
    background-color: rgba(0, 0, 0, 0.75);
    padding: 20px;
    border-radius: 15px;
    margin: 30px auto;
    max-width: 800px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.5);
}

.profile-container h2 {
    text-align: center;
    color: #ffde00;
    text-shadow: 1px 1px 2px #000000;
}

.details {
    display: flex;
    justify-content: space-between;
    flex-wrap: wrap;
    min-width: 85%;
}

.detail-column {
    display: flex;
    flex-direction: column;
    margin-bottom: 20px;
}

.detail {
    background-color: rgba(255, 255, 255, 0.1);
    margin-bottom: 15px;
    padding: 15px;
    border-radius: 10px;
}

.detail h3 {
    margin: 0 0 10px 0;
    color: #ffde00;
}

.detail p {
    margin: 0;
    color: #ffffff;
}

@media (max-width: 768px) {
    .details {
        flex-direction: column;
    }

    .detail-column {
        flex-basis: 100%;
    }
}
</style>