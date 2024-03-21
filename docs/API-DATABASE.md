# Consultas Solicitadas

> [!INFO]
> Ésto es s'lo una guía para organizar las consultas a realizar en la base de datos.

**1. Conocer los mejores jugadores que participan en una guerra**
```sql
SELECT g.id_guerra, c.nombre AS clan_nombre, j.id_jugador, j.apodo, MAX(j.trofeos) AS max_trofeos
FROM Guerras_Clanes gc
JOIN Clanes c ON gc.id_clan = c.id_clan
JOIN Clanes_Jugadores cj ON c.id_clan = cj.id_clan
JOIN Jugadores j ON cj.id_jugador = j.id_jugador
GROUP BY g.id_guerra, c.nombre;
```

**2. Conocer el clan con mejor desempeño durante las guerras por región del mundo**
```sql
SELECT c.region, c.nombre, SUM(gc.trofeos_ganados) AS total_trofeos
FROM Guerras_Clanes gc
JOIN Clanes c ON gc.id_clan = c.id_clan
GROUP BY c.region
ORDER BY total_trofeos DESC;
```

**3. La carta o las cartas más donadas por región en el último mes**
```sql
SELECT c.region, d.id_carta, ca.nombre, SUM(d.cantidad) AS total_donado
FROM Donaciones d
JOIN Jugadores j ON d.id_jugador = j.id_jugador
JOIN Clanes_Jugadores cj ON j.id_jugador = cj.id_jugador
JOIN Clanes c ON cj.id_clan = c.id_clan
JOIN Cartas ca ON d.id_carta = ca.id_carta
WHERE d.fecha_donacion > DATE('now', '-1 month')
GROUP BY c.region, d.id_carta
ORDER BY total_donado DESC;
```

**4. La carta más popular de cada tipo dentro de cada clan existente**
```sql
-- Esta consulta puede ser compleja y variar según las interpretaciones de "popular", por ejemplo, la cantidad de jugadores que la tienen como favorita.
SELECT c.id_clan, c.nombre AS clan_nombre, ca.tipo, ca.nombre AS carta_nombre, COUNT(j.id_jugador) AS num_favorita
FROM Clanes_Jugadores cj
JOIN Clanes c ON cj.id_clan = c.id_clan
JOIN Jugadores j ON cj.id_jugador = j.id_jugador
JOIN Cartas ca ON j.carta_favorita = ca.id_carta
GROUP BY c.id_clan, ca.tipo
ORDER BY num_favorita DESC;
```

**5. Dado un jugador saber a qué clanes se puede unir, conociendo los requisitos de cada clan**
```sql
SELECT c.id_clan, c.nombre, c.trofeos_entrar
FROM Clanes c
WHERE c.trofeos_entrar <= (SELECT j.trofeos FROM Jugadores j WHERE j.id_jugador = ?)
ORDER BY c.trofeos_entrar DESC;
```
*Nota: Reemplaza '?' por el id del jugador.*

**6. Los desafíos donde haya participado al menos un jugador que lo haya completado**
```sql
SELECT d.id_desafio, d.nombre
FROM Desafíos d
JOIN Jugadores_Desafios jd ON d.id_desafio = jd.id_desafio
WHERE jd.premios_alcanzados = d.premios
GROUP BY d.id_desafio;
```
