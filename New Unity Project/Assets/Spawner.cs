using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static int CountEnemyAlive = 0;
    public Wave[] waves;
    public Transform START;
    public float waveRate = 0.3f;

    private bool WaveStart = false;
    private bool Started = false;


    public void StartWave()
    {
        WaveStart = true;

        if (Started == false)
        {
            Started = true;
            Start();
        }
        
    }

    public void EndWave()
    {
        WaveStart = false;
    }

    void Start()
    {
        if (WaveStart == true)
        {
            StartCoroutine(SpawnEnemy());
        }
       
    }

    IEnumerator SpawnEnemy()
    {
        foreach(Wave wave in waves)
        {
            for (int i = 0; i < wave.count; i++)
            {
                GameObject.Instantiate(wave.enemyPrefab, START.position, Quaternion.identity);
                CountEnemyAlive++;
                if (i != wave.count - 1)
                {
                    yield return new WaitForSeconds(wave.rate);
                }
            }
            while (CountEnemyAlive > 0)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(waveRate);
        }
        while (CountEnemyAlive>0)
        {
            yield return 0;
        }
        EndManager.Instance.Win();
    }
    public void Stop()
    {
        StopAllCoroutines();
    }
}
