using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBooster : MonoBehaviour
{
    [SerializeField] LaserType laserPrefab;
    [SerializeField] float durationTime = 2;
    [System.Serializable] public enum shootType { normal, trio, wide };
    [SerializeField] shootType shootingType = shootType.normal;
    [SerializeField] public float boosterSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        StartCoroutine(getBoosted(player));
        
    }

    private IEnumerator getBoosted(Player player)
    {
        
        LaserType oldLaserPrefab = player.LaserPrefab;
        player.ShootingType = shootingType;
        player.LaserPrefab = laserPrefab;
        gameObject.GetComponent<SpriteRenderer>().sprite = null;
        yield return new WaitForSeconds(durationTime);
        player.LaserPrefab = oldLaserPrefab;
        player.ShootingType = shootType.normal;
        Destroy(this.gameObject);
    }

}
