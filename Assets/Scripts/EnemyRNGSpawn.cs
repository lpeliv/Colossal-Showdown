using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRNGSpawn : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject Player;
    public Vector3 center;
    public Vector3 size;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    int numberOfEnemies = 0;

    public void Start()
    {
        center = transform.position;
        
        InvokeRepeating("SpawnEnemy", spawnTime, spawnDelay);
    }

    public void SpawnEnemy()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        Instantiate(EnemyPrefab, pos, Quaternion.identity);
        numberOfEnemies++;

        if (numberOfEnemies > 1)
            stopSpawning = true;

        if (stopSpawning)
        {
            CancelInvoke("SpawnEnemy()");
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
        Gizmos.DrawCube(transform.localPosition, size);
    }

    private IEnumerator WaitBeforeshow(float seconds)
    {
        yield return new WaitForSeconds(12.5f);
        SpawnEnemy();
        

    }
}
