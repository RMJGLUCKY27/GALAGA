using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    // Etiqueta para identificar objetos en el pool
    [SerializeField] string targetTag;
    // Prefab que se usará para crear objetos
    [SerializeField] GameObject prefab;
    // Lista que almacena los objetos en el pool
    [SerializeField] List<GameObject> objectPool;

    // Añade un objeto existente al pool
    public void AddToPool(GameObject obj)
    {
        objectPool.Add(obj);
    }

    // Obtiene un objeto del pool o crea uno nuevo si es necesario
    public GameObject AddToPool(Vector2 position)
    {
        // Busca un objeto inactivo en el pool
        foreach (GameObject obj in objectPool)
        {
            if(!obj.activeSelf)
            {
                // Activa el objeto y lo posiciona
                obj.SetActive(true);
                obj.transform.position = position;
                return obj;
            }
        }

        // Si no hay objetos inactivos, crea uno nuevo
        GameObject instance = Instantiate(prefab, position, Quaternion.identity);
        // Añade el nuevo objeto al pool
        objectPool.Add(instance);

        return instance;
    }

    // Elimina un objeto del pool
    public void RemoveFromPool(GameObject obj)
    {
        objectPool.Remove(obj);
    }

    // Desactiva un objeto del pool
    public void Deacivate(GameObject obj)
    {
        if(objectPool.Contains(obj))
        {
            obj.SetActive(false);
        }
    }

    // Limpia el pool completamente
    public void Clear()
    {
        objectPool.Clear();
    }
}
