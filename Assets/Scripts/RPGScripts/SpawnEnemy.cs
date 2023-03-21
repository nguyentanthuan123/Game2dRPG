using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : ThuanBehaviour
{
    float xPos;
    float yPos;
    int enemyCount;
    public int enemySpawn;
    // Start is called before the first frame update

    private void Start()
    {
        StartCoroutine(SpawnAfterTime());
    }

    //public void SpawnNewEmemy()
    //{
    //    StartCoroutine(SpawnAfterTime());
    //}

    IEnumerator SpawnAfterTime()
    {
        //yield return new WaitForSeconds(2);
        //GameObject sE = Instantiate(spawnEnemy[Random.Range(0, spawnEnemy.Length)], this.transform) as GameObject;
        //sE.transform.localPosition = new Vector3(Random.Range(-2f, 2f), 0.08f, 0);
        while (enemyCount < enemySpawn)
        {
            xPos = Random.Range(1f, 3f);
            yPos = Random.Range(1f, 3f);
            Transform newEnemy = EnemySpawner.Instances.Spawns(EnemySpawner.enemyOne, new Vector3(xPos, yPos, 0), Quaternion.identity);

            newEnemy.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
            enemyCount += 1;
        }
    }
}
