using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] int numerOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject EnemyPrefab { get => enemyPrefab;}
    public List<Transform> GetWaypoint()
    {
        List<Transform> listOfWaypoints = new List<Transform>();
        foreach(Transform child in pathPrefab.transform)
        {
            listOfWaypoints.Add(child);
        }
        return listOfWaypoints;
    }
    public float TimeBetweenSpawns { get => timeBetweenSpawns; }
    public int NumerOfEnemies { get => numerOfEnemies;}
    public float MoveSpeed { get => moveSpeed; }
}
