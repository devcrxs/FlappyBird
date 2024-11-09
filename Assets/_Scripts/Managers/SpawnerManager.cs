using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private List<Transform> pointsInstance;
    private Transform _player;
    public static SpawnerManager instance;

    private void Awake()
    {
        if(instance == null) instance = this;
    }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        Invoke(nameof(Spawn),1f);
    }

    private void Spawn()
    {
        var countSpawn = Random.Range(5, 10);
        countSpawn = countSpawn >= ObjectPoolingManager.instance.GetCountEnemiesFree()
            ? ObjectPoolingManager.instance.GetCountEnemiesFree() - 2: countSpawn;
        if (countSpawn <= 1) return;
        for (int i = 0; i < countSpawn; i++)
        {
            var go = ObjectPoolingManager.instance.GetEnemyFree();
            go.transform.position = GetPositionPlayer();
            go.SetActive(true);
        }
    }

    private Vector2 GetPositionPlayer()
    {
        var pointInRange = Vector2.zero;
        for (int i = 0; i < pointsInstance.Count; i++)
        {
            if (Vector2.Distance(_player.position, pointsInstance[i].position) < 5f)
            {
                pointInRange = pointsInstance[i].position;
                break;
            }
        }
        pointInRange.x += Random.Range(-5f, 6f);
        pointInRange.y += Random.Range(-5f, 6f);
        return pointInRange;
    }

    public void CanSpawn()
    {
        if (ObjectPoolingManager.instance.GetCountEnemiesUsed() <= 2)
        {
            Spawn();
        }
    }
}
