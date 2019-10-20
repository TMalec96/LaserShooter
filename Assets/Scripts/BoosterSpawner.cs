using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterSpawner : MonoBehaviour
{
    [SerializeField] bool looping = false;
    [SerializeField] float maxTimeBetweenSpawns = 1f;
    [SerializeField] float minTimeBetweenSpawns = 2f;
    [SerializeField] List<FireBooster> boosters;
    private List<Transform> spawnPoints;
    
    // Start is called before the first frame update

    public List<Transform> GetBoosterPoints()
    {
        List<Transform> boosterPoints = new List<Transform>();
        foreach(Transform child in this.transform)
        {
            boosterPoints.Add(child);
        }
        return boosterPoints;
    }
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnBoosters());
        } while (looping);
        
    }

    private FireBooster GetRandomFireBoster()
    {
        return boosters[Random.Range(0,boosters.Capacity)];
    }
    private Transform GetRandomSpawnPointTransform()
    {
        List<Transform> spawnPoints = GetBoosterPoints();
        return spawnPoints[Random.Range(0, spawnPoints.Capacity)];
    }

    private IEnumerator SpawnBoosters()
    {
        FireBooster randomBooster = GetRandomFireBoster();
        var newBooster = Instantiate(randomBooster, GetRandomSpawnPointTransform().position, Quaternion.identity);
        newBooster.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-randomBooster.boosterSpeed);
        yield return new WaitForSeconds(Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
