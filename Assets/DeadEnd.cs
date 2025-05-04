using UnityEngine;

public class DeadEnd : MonoBehaviour
{
    // Se llama cuando un objeto entra en el collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si es una bala del jugador, la desactiva
        if(collision.CompareTag("PlayerBullet"))
        {
            PoolManager.Instance.Deacivate(collision.gameObject);
        }
    }
}
