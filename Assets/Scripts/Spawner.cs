using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public event System.Action SpawnedAll;

    [SerializeField]
    List<SpawnData> enemyPrefabs;

    [SerializeField]
    GameObject bossPrefab;

    [SerializeField]
    private int countOfNormalEnemies = 30;
    private int currentlySpawnedEnemies = 0;

    private bool bossSpawned = false;


    [SerializeField]
    private float speedInterval;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(speedInterval);
            if (currentlySpawnedEnemies < countOfNormalEnemies)
            {
                SpawnEnemy();
            } else
            {
                if(!bossSpawned)
                    SpawnBoss();
            }

        }
    }

    private void SpawnBoss()
    {
        bossSpawned = true;
        Instantiate(bossPrefab, transform.position, Quaternion.identity);

        SpawnedAll?.Invoke();
    }

    private void SpawnEnemy()
    {
        currentlySpawnedEnemies++;
        GameObject randomPrefab = GetRandomPrefab(); 
        Instantiate(randomPrefab, transform.position, Quaternion.identity);
    }

    private GameObject GetRandomPrefab()
    {
        float currentProb = 0;
        float rnd = Random.Range(0f, enemyPrefabs.Sum(ep => ep.probabilty));
        for(int i = 0; i < enemyPrefabs.Count; i++)
        {
            currentProb += enemyPrefabs[i].probabilty;
            if(rnd <= currentProb)
            {
                return enemyPrefabs[i].prefab;
            }
        }
        return enemyPrefabs.First().prefab;
    }
}

[System.Serializable]
class SpawnData
{
    public float probabilty;
    public GameObject prefab;
}
