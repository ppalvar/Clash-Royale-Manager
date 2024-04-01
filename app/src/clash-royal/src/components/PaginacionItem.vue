<template>
    <div class="pagination-container">
        <span class="page-item" @click="gotoPage(1)">Primera</span>
        <span class="page-item" @click="gotoPage(page - 1 > 0 ? page - 1 : 1)"> &laquo; </span>
        <span v-for="pageNumber in suggestedPages" :key="pageNumber" 
              class="page-item" @click="gotoPage(pageNumber)" :class="{ 'active': pageNumber === page }">
              {{ pageNumber }}
        </span>
        <span class="page-item" @click="gotoPage(page + 1 <= totalPage ? page + 1 : totalPage)"> &raquo; </span>
        <span class="page-item" @click="gotoPage(totalPage)"> Última</span>
    </div>
</template>

<script>
export default {
    props: ['page', 'totalPage'],
    data() {
        return {
            suggestedPages: []
        };
    },
    watch: {
        page() {
            this.calculateSuggestedPages();
        },
        totalPage() {
            this.calculateSuggestedPages();
        }
    },
    methods: {
        gotoPage(toPage) {
            if (toPage >= 1 && toPage <= this.totalPage) {
                this.$emit('goto-page', toPage);
            }
        },
        calculateSuggestedPages() {
            const currentPage = this.page;
            const maxSuggestedPages = 5;
            
            let startPage = Math.max(1, currentPage - Math.floor(maxSuggestedPages / 2));
            let endPage = startPage + maxSuggestedPages - 1;
            if (endPage > this.totalPage) {
                endPage = this.totalPage;
                startPage = Math.max(1, endPage - maxSuggestedPages + 1);
            }
            this.suggestedPages = Array.from({ length: endPage - startPage + 1 }, (_, i) => startPage + i);
        }
    },
    mounted() {
        this.calculateSuggestedPages();
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