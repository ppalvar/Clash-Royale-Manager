<template>
    <TableInfo>
        <template #thead>
            <th>Nombre</th>
            <th>Descripcion</th>
            <th>Trofeos de guerra</th>
            <th>Region</th>
            <th>Miembros</th>
            <th>Trofeos para entrar</th>
            <!-- <th v-if="isUserAuthenticated">Acciones</th> -->
        </template>
        <template #tbody>
            <tr v-for="clan in clanes" :key="clan.id" @click="$emit('info', clan.id, type)">
                <td> {{ clan.name }} </td>
                <td> {{ clan.description }} </td>
                <td> {{ clan.numberOfTrophiesObtainedInWars }} </td>
                <td> {{ clan.region }} </td>
                <td> {{ clan.numberOfMembers }} </td>
                <td> {{ clan.condicion }} </td>
                <!-- <td v-if="isUserAuthenticated">aqui van botones</td> -->
            </tr>
        </template>
    </TableInfo>
</template>

<script>
import TableInfo from '@/components/TableInfo.vue';
import Edit from '@/assets/svg/edit.svg';
import Delete from '@/assets/svg/delete.svg';
import Details from '@/assets/svg/details.svg';
import { isAuthenticated } from '@/auth/auth';

export default {
    props: {
        clanes: [],
        edit: {
            type: Boolean,
            default: true,
        },
    },

    components: {
        TableInfo,
    },

    data() {
        return {
            Edit,
            Delete,
            Details,
        }
    },

    computed: {
        isUserAuthenticated() {
            return isAuthenticated();
        },
    },

    methods: {
        getRegion(id) {
            const regions = [
                "Training_Camp",
                "Goblin_Stadium",
                "Bone_Pit",
                "Barbarian_Bowl",
                "PEKKAs_Playhouse",
                "Spell_Valley",
                "Builder_Workshop",
                "Royal_Arena",
                "Frozen_Peak",
                "Jungle_Arena",
                "Hog_Mountain",
                "Electro_Valley",
                "Spooky_Town",
                "Legendary_Aren"
            ]

            return regions[id];
        }
    },

}
</script>