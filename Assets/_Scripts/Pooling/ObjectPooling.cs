using System.Collections.Generic;
using UnityEngine;
public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;
    [SerializeField] private int maxCountPrefabs;
    [SerializeField] private GameObject prefabPool;
    [SerializeField] private Transform pointSpawnPools;
    private List<GameObject> prefabsFree = new ();
    private List<GameObject> prefabsUsed = new ();

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        CreatePrefabs();
    }

    private void CreatePrefabs()
    {
        int index = 0;
        while (index < maxCountPrefabs)
        {
            var prefab =Instantiate(prefabPool, pointSpawnPools.position, Quaternion.identity);
            prefab.SetActive(false);
            prefabsFree.Add(prefab);
            index++;
        }
    }

    public GameObject GetPrefabFree()
    {
        if (prefabsFree.Count <= 0) return null;
        var prefab = prefabsFree[0];
        prefabsUsed.Add(prefab);
        prefabsFree.RemoveAt(0);
        return prefab;
    }

    public void AddPrefabToAvaible(GameObject prefab)
    {
        if (prefabsUsed.Contains(prefab))
        {
            prefabsUsed.RemoveAt(0);
            prefabsFree.Add(prefab);
        }
        
    }
}
