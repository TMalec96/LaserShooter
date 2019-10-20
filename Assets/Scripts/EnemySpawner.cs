using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool looping = false;
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnWaves(waveConfigs));
        }
        while (looping);
    }

    private IEnumerator SpawnWaves(List<WaveConfig> waveConfigs)
    {
        foreach(WaveConfig waveConfig in waveConfigs)
        {
            var currentWave = waveConfig;
            yield return StartCoroutine(SpawnEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnEnemiesInWave(WaveConfig currentWave)
    {
        for (int i = 0; i < currentWave.NumerOfEnemies; i++)
        {
            var newEnemy = Instantiate(currentWave.EnemyPrefab, currentWave.GetWaypoint()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().WaveConfig = currentWave;
            yield return new WaitForSeconds(currentWave.TimeBetweenSpawns);
        }
    }

    
}
