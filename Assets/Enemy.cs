using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    // Velocidad de movimiento del enemigo
    [SerializeField] float speed = 3f;
    
    [Header("Bullet Config")]
    // Prefab de la bala que disparará el enemigo
    [SerializeField] GameObject bulletPrefab;
    // Punto de origen desde donde se dispararán las balas
    [SerializeField] Transform bulletOrigin;
    // Velocidad a la que se moverán las balas
    [SerializeField] float bulletSpeed = 3f;
    
    // Componente Rigidbody2D para el movimiento físico
    private Rigidbody2D rb;
    // Límite inferior de la pantalla
    private float screenBottom;
    // Referencia al GameManager
    private GameManager gameManager;
    
    private void Start()
    {
        // Obtiene el componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        
        // Calcula el límite inferior de la pantalla
        screenBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y - 1f;
        
        // Obtiene referencia al GameManager
        gameManager = FindObjectOfType<GameManager>();
        
        // Inicia disparos repetitivos con intervalos aleatorios
        InvokeRepeating("Shoot", Random.Range(1f, 3f), Random.Range(1.5f, 3f));
    }
    
    private void FixedUpdate()
    {
        // Mueve el enemigo hacia abajo
        rb.linearVelocity = Vector2.down * speed * Time.deltaTime;
        
        // Verifica si salió de la pantalla
        if (transform.position.y < screenBottom)
        {
            Respawn();
        }
    }
    
    // Reposiciona el enemigo en la parte superior de la pantalla
    private void Respawn()
    {
        // Reposiciona en la parte superior con posición X aleatoria
        float randomX = Random.Range(-8f, 8f);
        float topOfScreen = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.1f, 0)).y;
        transform.position = new Vector3(randomX, topOfScreen, 0f);
    }
    
    // Método para disparar balas
    private void Shoot()
    {
        // Obtiene una bala del pool
        GameObject bullet = PoolManager.Instance.AddToPool(bulletOrigin.position);
        if (bullet != null && bullet.TryGetComponent<Rigidbody2D>(out Rigidbody2D bulletRB))
        {
            // Establece dirección y velocidad (hacia abajo)
            bulletRB.linearVelocityY = -bulletSpeed * Time.fixedDeltaTime;
        }
    }
    
    // Se llama cuando algo entra en el collider del enemigo
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si colisiona con una bala del jugador
        if (other.CompareTag("Bullet"))
        {
            // Desactiva la bala
            other.gameObject.SetActive(false);
            
            // Aumenta puntuación si existe un GameManager
            if (gameManager != null)
            {
                gameManager.AddScore(10);
            }
            
            // Desactiva el enemigo
            gameObject.SetActive(false);
        }
    }
}