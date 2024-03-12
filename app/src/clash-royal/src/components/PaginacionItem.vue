<template>
    <div class="pagination-container">
        <!-- <span class="page-item" @click="gotoPage(1)">Primera</span>
        <span class="page-item" @click="gotoPage(2)"> &laquo; </span>
        <span class="page-item" @click="gotoPage(3)">1</span>
        <span class="page-item" @click="gotoPage(4)">2</span>
        <span class="page-item" @click="gotoPage(5)">3</span>
        <span class="page-item" @click="gotoPage(6)"> &raquo; </span>
        <span class="page-item" @click="gotoPage(7)"> Última</span> -->
    </div>
</template>

<script>
export default {
    props: ['page', 'totalPage'],
    methods: {
        gotoPage(toPage) {
            toPage;
            alert('NO IMPLEMENTED');
        }
    }
}
</script>

<style>
.pagination-container {
    text-align: center;
    margin-top: 20px;
    display: flex;
    justify-content: center;
    align-items: center;
    padding: 10px;
}

.page-item {
    margin: 0 5px;
    padding: 5px 10px;
    cursor: pointer;
    background-color: #ffde00;
    color: #121212;
    border-radius: 5px;
    font-weight: bold;
    transition: background-color 0.2s ease-in-out;
}

.page-item:hover {
    background-color: #f1c40f;
}

.page-item.active {
    background-color: #f39c12;
    color: white;
}
</style>