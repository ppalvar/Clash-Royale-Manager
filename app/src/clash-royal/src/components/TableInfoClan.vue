<template>
    <TableInfo>
        <template #thead>
            <th>Nombre</th>
            <th>Tipo</th>
            <th>Region</th>
            <th>Miembros</th>
            
            <th>Trofeos de guerra</th>
            <th>Trofeos para entrar</th>
            <th v-if="isUserAuthenticated">Acciones</th>
        </template>
        <template #tbody>
            <tr v-for="clan in clanes" :key="clan.id">
                <td> {{ clan.clan.name }} </td>
                <td> {{ clan.type }} </td>
                <td> {{ getRegion(clan.clan.region) }} </td>
                <td> {{ clan.clan.numberOfMembers }} </td>
                <td> {{ clan.clan.numberOfTrophiesObtainedInWars }} </td>
                <td> {{ clan.clan.trophiesNeededToEnter }} </td>
                <td v-if="isUserAuthenticated">
                    <img height="20px" :src="Details" @click="$emit('info', clan.clan.id)"/>
                    <img v-if="isUserAuthenticated" height="20px" :src="Edit" @click="$emit('edit', clan.clan.id)"/>
                    <img v-if="isUserAuthenticated" height="20px" :src="Delete" @click="$emit('delete', clan.clan.id)"/>
                </td>
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