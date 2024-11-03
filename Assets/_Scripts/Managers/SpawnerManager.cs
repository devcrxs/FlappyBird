using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private List<Transform> pointsInstance;
    private Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Invoke(nameof(Spawn),1f);
    }

    private void Spawn()
    {
        
        var countSpawn = Random.Range(5, 10);
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
            if (Vector2.Distance(player.position, pointsInstance[i].position) < 0.1f)
            {
                pointInRange = pointsInstance[i].position;
            }
        }
        pointInRange.x += Random.Range(-5f, 6f);
        pointInRange.y += Random.Range(-5f, 6f);
        return pointInRange;
    }
}
