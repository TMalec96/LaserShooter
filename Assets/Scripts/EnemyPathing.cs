using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    private List<Transform> waypoints;
    private int wayPointIndex = 0;

    public WaveConfig WaveConfig {set => waveConfig = value; }



    // Start is called before the first frame update
    void Start()
    {
       waypoints = waveConfig.GetWaypoint();
       this.transform.position = waypoints[wayPointIndex].transform.position;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    
    private void Move()
    {
        
        if(wayPointIndex < waypoints.Count)
        {
            var targetPosition = waypoints[wayPointIndex].transform.position;
            var movementThisFrame = Time.deltaTime * waveConfig.MoveSpeed;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            
            if(transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
