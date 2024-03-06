const carts = [
    { id: '0', nombre: 'name 0', descripcion: 'description 0', costo: 0, calidad: 'mala' },
    { id: '1', nombre: 'name 1', descripcion: 'description 1', costo: 1, calidad: 'buena' },
    { id: '2', nombre: 'name 2', descripcion: 'description 2', costo: 2, calidad: 'mala' },
    { id: '3', nombre: 'name 3', descripcion: 'description 3', costo: 3, calidad: 'regular' },
]

const getAllCarts = () => {
    return carts
}

const getCart = (id) => {
    let item = { id: '', nombre: '', descripcion: '', costo: 0, calidad: '' }

    carts.forEach(cart => {
        if (cart.id == id) {
            item = cart
        }
    });

    return item
}

const jugadores = [
    { id: '0', apodo: 'name 0', nivel: 0, trofeos: 0, victorias: 0, cartas: 20, racha: 0 },
    { id: '1', apodo: 'name 1', nivel: 1, trofeos: 1, victorias: 0, cartas: 20, racha: 1 },
    { id: '2', apodo: 'name 2', nivel: 2, trofeos: 2, victorias: 0, cartas: 20, racha: 2 },
    { id: '3', apodo: 'name 3', nivel: 3, trofeos: 3, victorias: 0, cartas: 20, racha: 3 },
    { id: '4', apodo: 'name 4', nivel: 4, trofeos: 4, victorias: 0, cartas: 20, racha: 4 },
    { id: '5', apodo: 'name 5', nivel: 5, trofeos: 5, victorias: 0, cartas: 20, racha: 5 },
    { id: '6', apodo: 'name 6', nivel: 6, trofeos: 6, victorias: 0, cartas: 20, racha: 6 },
    { id: '7', apodo: 'name 7', nivel: 7, trofeos: 7, victorias: 0, cartas: 20, racha: 7 },
]

const getAllJugadores = () => {
    return jugadores
}

const getJugador = (id) => {
    let item = { id: '', apodo: '', nivel: 0, trofeos: 0, victorias: 0, cartas: 0, racha: 0 }

    jugadores.forEach(jugador => {
        if (jugador.id == id) {
            item = jugador
        }
    });

    return item
}

const jugadoresDeClan = [
    { clan: '0', jugadores: [jugadores[0], jugadores[2]] },
    { clan: '1', jugadores: [jugadores[1], jugadores[5]] },
    { clan: '2', jugadores: [jugadores[3], jugadores[4], jugadores[6]] },
    { clan: '3', jugadores: [jugadores[7]] },
]

const getMembersOfClan = (id) => {
    let members = []

    jugadoresDeClan.forEach(item => {
        if (item.clan == id) {
            members = item.jugadores
        }
    });

    return members
}

const clanes = [
    { id: '0', nombre: 'name 0', descripcion: 'description 0', trofeos: 0, region: 'cuba', miembros: getMembersOfClan('0').length, condicion: 0 },
    { id: '1', nombre: 'name 1', descripcion: 'description 1', trofeos: 1, region: 'cuba', miembros: getMembersOfClan('1').length, condicion: 1 },
    { id: '2', nombre: 'name 2', descripcion: 'description 2', trofeos: 2, region: 'cuba', miembros: getMembersOfClan('2').length, condicion: 2 },
    { id: '3', nombre: 'name 3', descripcion: 'description 3', trofeos: 3, region: 'cuba', miembros: getMembersOfClan('3').length, condicion: 3 },
]

const getAllClanes = () => {
    return clanes
}

const getClan = (id) => {
    let item = { id: '', nombre: '', descripcion: '', trofeos: 0, region: '', miembros: 0, condicion: 0 }

    clanes.forEach(clan => {
        if (clan.id == id) {
            item = clan
        }
    });

    return item
}

export default {
    getAllCarts,
    getAllClanes,
    getAllJugadores,
    getCart,
    getClan,
    getJugador,
    getMembersOfClan,
}