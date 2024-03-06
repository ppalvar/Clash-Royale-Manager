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
                <tr name="fila 1">
                    <td>column value 1</td>
                    <td>column value 2</td>
                    <td> ... </td>
                    <td>column value n</td>
                </tr>
                <tr name="fila 2">
                    <td>column value 1</td>
                    <td>column value 2</td>
                    <td> ... </td>
                    <td>column value n</td>
                </tr>
            </slot>
        </tbody>
    </table>
</template>

<style>
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