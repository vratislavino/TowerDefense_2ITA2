using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> enemyPrefabs;

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
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        GameObject randomPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        Instantiate(randomPrefab, transform.position, Quaternion.identity);
    }
}
