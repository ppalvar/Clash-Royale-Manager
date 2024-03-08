<template>
    <div class="profile-container">
        <slot name="entity">
            <h2>Crear Entity</h2>
        </slot>

        <table class="form">
            <slot name="form">
            
            </slot>
        </table>
    </div>
</template>

<style>
.form {
    color: #ffde00;
}

.form th {
    text-align: left;
    padding: 5px;
}

.form input,
textarea {
    position: relative;
    top: 5px;
    margin-bottom: 10px;
    padding: 10px;
    border: none;
    border-radius: 8px;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.25);
}
</style>