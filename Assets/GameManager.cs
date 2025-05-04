using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Vidas iniciales del jugador
    [SerializeField] int playerLives = 3;
    // Puntuación inicial
    [SerializeField] int score = 0;
    
    [Header("UI References")]
    // Referencias a elementos de la interfaz
    [SerializeField] Text scoreText;
    [SerializeField] Text livesText;
    [SerializeField] GameObject gameOverPanel;
    
    // Implementación del patrón Singleton
    public static GameManager Instance { get; private set; }
    
    private void Awake()
    {
        // Asegura que solo exista una instancia del GameManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        // Actualiza la interfaz al inicio
        UpdateUI();
        
        // Oculta el panel de Game Over
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }
    
    // Método para añadir puntos a la puntuación
    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }
    
    // Método llamado cuando el jugador recibe daño
    public void PlayerHit()
    {
        playerLives--;
        UpdateUI();
        
        // Si no quedan vidas, termina el juego
        if (playerLives <= 0)
        {
            GameOver();
        }
    }
    
    // Actualiza los elementos de la interfaz
    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Puntuación: " + score;
        }
        
        if (livesText != null)
        {
            livesText.text = "Vidas: " + playerLives;
        }
    }
    
    // Método para manejar el fin del juego
    private void GameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        
        // Reinicia el juego después de 3 segundos
        Invoke("RestartGame", 3f);
    }
    
    // Método para reiniciar el juego
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
