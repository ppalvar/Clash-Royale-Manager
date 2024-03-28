<template>
    <table class="players-table">
        <thead>
            <tr>
                <slot name="thead">
                    <th>column name 1</th>
                    <th>column name 2</th>
                    <th> ... </th>
                    <th>column name n</th>
                </slot>
            </tr>
        </thead>
        <tbody>
            <slot name="tbody">
                <!-- <tr name="fila 1"> -->
                    <td colspan="4" class="row-none">Sin elementos</td>
                <!-- </tr> -->
            </slot>
        </tbody>
    </table>
</template>

<style>
.row-none {
    text-align: center;
}
tr {
    border-bottom: 1px solid #ddd;
}

.players-table {
    width: 100%;
    border-collapse: collapse;
}

.players-table th {
    text-align: left;
    padding: 15px;
    border-bottom: 1px solid #ddd;
}

.players-table td {
    text-align: left;
    padding: 15px;
    cursor: pointer;
}

.players-table th {
    background-color: #ffde00;
    color: #121212;
}

.players-table tr:hover {
    background-color: #f1c40844;
}
</style>