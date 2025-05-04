# Space Shooter - Juego Unity 2D

## Descripción General
Este proyecto es un juego de disparos espaciales (Space Shooter) desarrollado en Unity. El jugador controla una nave espacial que debe enfrentarse a enemigos que aparecen desde la parte superior de la pantalla.

## Cómo Jugar

1. **Objetivo**: Destruir a los enemigos y obtener la mayor puntuación posible.

2. **Controles**:
   - Usa las teclas de dirección o WASD para mover tu nave.
   - Presiona la tecla de espacio o el botón configurado para disparar.

3. **Mecánicas**:
   - Los enemigos aparecen desde la parte superior de la pantalla.
   - Cada enemigo destruido otorga 10 puntos.
   - Si un enemigo te golpea, pierdes una vida.
   - Tienes 3 vidas al inicio del juego.
   - El juego termina cuando pierdes todas tus vidas.
   - Los enemigos disparan periódicamente hacia abajo.

## Características Técnicas

1. **Object Pooling**: El juego utiliza un sistema de "object pooling" para gestionar las balas y los enemigos, lo que mejora el rendimiento al reutilizar objetos en lugar de crearlos y destruirlos constantemente.

2. **Patrón Singleton**: Se utiliza para clases como el GameManager y el PoolManager, asegurando que solo exista una instancia de estas clases en el juego.

3. **Sistema de Entrada**: Utiliza el nuevo sistema de entrada de Unity para controlar al jugador.

4. **Física 2D**: El movimiento de los objetos se basa en el sistema de física 2D de Unity, utilizando Rigidbody2D para el movimiento.

5. **Sistema de Enemigos**: 
   - Máximo 6 enemigos activos a la vez
   - Generación cada 2 segundos
   - Respawn automático cuando salen de la pantalla
   - Disparo periódico

## Estructura del Proyecto

- **Player.cs**: Controla el movimiento y disparo del jugador.
- **Enemy.cs**: Gestiona el comportamiento de los enemigos.
- **EnemySpawner.cs**: Genera enemigos a intervalos regulares.
- **GameManager.cs**: Controla la lógica general del juego, puntuación y vidas.
- **PoolManager.cs**: Gestiona el sistema de object pooling para balas y otros objetos.
- **DeadEnd.cs**: Desactiva las balas cuando salen de la pantalla.
- **Singleton.cs**: Implementa el patrón Singleton para otras clases.

## Posibles Mejoras

1. Añadir diferentes tipos de enemigos con comportamientos distintos.
2. Implementar power-ups para el jugador.
3. Añadir niveles con dificultad progresiva.
4. Mejorar los efectos visuales y sonoros.
5. Implementar un sistema de guardado de puntuaciones altas.