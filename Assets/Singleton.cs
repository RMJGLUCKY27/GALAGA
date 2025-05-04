using UnityEngine;

// Clase genérica para implementar el patrón Singleton
public class Singleton<T> : MonoBehaviour where T : Component
{
    // Instancia única del singleton
    private static T instance;
    public static T Instance
    {
        get
        { 
            // Si la instancia no existe, la busca en la escena
            if (instance == null)
            {
                var objs = FindObjectsByType<T>(FindObjectsSortMode.None);
                if (objs.Length > 0)
                {
                    instance = objs[0];
                }

                // Advierte si hay más de una instancia
                if (objs.Length > 1)
                {
                    Debug.LogError("There is more than one " + typeof(T).Name + " in the scene.");
                }
            }

            return instance;
        }
    }
}
