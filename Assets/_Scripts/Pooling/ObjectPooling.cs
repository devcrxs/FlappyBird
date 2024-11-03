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

    
}
