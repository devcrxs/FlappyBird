using System.Collections.Generic;
using UnityEngine;
public class ObjectPoolingManager : MonoBehaviour
{
    [SerializeField] private int maxCountPrefabs;
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private GameObject prefabEnemy;
    [SerializeField] private Transform pointSpawnPools;
    private List<GameObject> prefabsBulletsFree = new ();
    private List<GameObject> prefabsBulletsUsed = new ();
    private List<GameObject> prefabsEnemyFree = new ();
    private List<GameObject> prefabsEnemyUsed = new ();
    
    public static ObjectPoolingManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        CreatePrefabs(maxCountPrefabs,prefabBullet,pointSpawnPools.position,Quaternion.identity,prefabsBulletsFree);
        CreatePrefabs(maxCountPrefabs,prefabEnemy,Vector3.zero, Quaternion.identity, prefabsEnemyFree);
    }
    public void CreatePrefabs(int maxPrefabs, GameObject prefabGo, Vector3 positionInstantiate, Quaternion rotationInstantiate, List<GameObject>listSavePrefabs)
    {
        int index = 0;
        while (index < maxPrefabs)
        {
            var prefab =Instantiate(prefabGo, positionInstantiate, rotationInstantiate);
            prefab.SetActive(false);
            listSavePrefabs.Add(prefab);
            index++;
        }
    }
    public GameObject GetBulletFree()
    {
        if (prefabsBulletsFree.Count <= 0) return null;
        var prefab = prefabsBulletsFree[0];
        prefabsBulletsUsed.Add(prefab);
        prefabsBulletsFree.RemoveAt(0);
        return prefab;
    }
    public GameObject GetEnemyFree()
    {
        if (prefabsEnemyFree.Count <= 0) return null;
        var prefab = prefabsEnemyFree[0];
        prefabsEnemyUsed.Add(prefab);
        prefabsEnemyFree.RemoveAt(0);
        return prefab;
    }
    
    public void AddBulletsToAvaible(GameObject prefab)
    {
        if (prefabsBulletsUsed.Contains(prefab))
        {
            prefabsBulletsUsed.RemoveAt(0);
            prefabsBulletsFree.Add(prefab);
        }
    }
    public void AddEnemyToAvaible(GameObject prefab)
    {
        if (prefabsEnemyUsed.Contains(prefab))
        {
            prefabsEnemyUsed.RemoveAt(0);
            prefabsEnemyFree.Add(prefab);
        }
    }
}
