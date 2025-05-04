using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Prefab del enemigo a generar
    [SerializeField] GameObject enemyPrefab;
    // Número máximo de enemigos en pantalla
    [SerializeField] int maxEnemies = 6;
    // Intervalo entre generación de enemigos
    [SerializeField] float spawnInterval = 2f;
    
    // Temporizador para controlar la generación
    private float spawnTimer = 0f;
    // Array para almacenar los enemigos en el pool
    private GameObject[] enemyPool;
    
    private void Start()
    {
        // Inicializa el pool de enemigos
        enemyPool = new GameObject[maxEnemies];
        for (int i = 0; i < maxEnemies; i++)
        {
            enemyPool[i] = Instantiate(enemyPrefab);
            enemyPool[i].SetActive(false);
        }
    }
    
    private void Update()
    {
        // Incrementa el temporizador
        spawnTimer += Time.deltaTime;
        
        // Genera un enemigo cuando se alcanza el intervalo
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemy();
        }
    }
    
    // Método para generar un enemigo del pool
    private void SpawnEnemy()
    {
        // Busca un enemigo inactivo en el pool
        for (int i = 0; i < enemyPool.Length; i++)
        {
            if (!enemyPool[i].activeInHierarchy)
            {
                // Posición aleatoria en X, fuera de la vista superior
                float randomX = Random.Range(-8f, 8f);
                float topOfScreen = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.1f, 0)).y;
                enemyPool[i].transform.position = new Vector3(randomX, topOfScreen, 0f);
                enemyPool[i].SetActive(true);
                return;
            }
        }
        // Si llegamos aquí, significa que todos los enemigos están activos
        // No hacemos nada para evitar overflow
    }
}