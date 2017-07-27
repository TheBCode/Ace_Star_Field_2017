using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;

    float spawnDistance = 12f;

    float enemyRate = 5;
    float nextEnemy = 1;

    // Update is called once per frame
    void Update()
    {
        nextEnemy -= Time.deltaTime;
        Vector3 pos = transform.position;
        if (nextEnemy <= 0)
        {
            nextEnemy = enemyRate;
            enemyRate *= 0.01f;
            if (enemyRate < 2)
                enemyRate = 2;

            Vector3 offset = Random.onUnitSphere;
            if (pos.x < -3)
                pos.x = -3;
            if (pos.x > 3)
                pos.x = 3;
            if (pos.y < -5)
                pos.y = -5;
            if (pos.y > 7)
                pos.y = 7;
            offset.z = -1;

            offset = offset.normalized * spawnDistance;
            offset.z = -1;
            Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
            offset.z = -1;
            //print(spawn.transform.position.x + ", " + spawn.transform.position.y + ", " + spawn.transform.position.z);
        }
    }
}
