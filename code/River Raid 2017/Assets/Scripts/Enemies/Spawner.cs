using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


    public GameObject Enemy;
    public Vector3 spawnRange;
    public Vector3 spawnOffset;
    public int spawnCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(spawnRange.x-spawnOffset.x, spawnRange.x+spawnOffset.x), Random.Range(spawnRange.y-spawnOffset.y, spawnRange.y+spawnOffset.y), Random.Range(spawnRange.z-spawnOffset.z, spawnRange.z+spawnOffset.z));
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(Enemy, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
