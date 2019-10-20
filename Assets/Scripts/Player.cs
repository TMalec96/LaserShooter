using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FireBooster;

public class Player : MonoBehaviour
{
    
    [Header("Player")]
    [SerializeField] float speed = 3f;
    [SerializeField] int health = 200;
    private float speedDeltaTime;
    private float xMin;
    private float yMin;
    private float xMax;
    private float yMax;
    public float padding = 1f;
    [Header("Projectile")]
    [SerializeField] LaserType laserPrefab;
    private shootType shootingType = shootType.normal;


    [Header("Audio")]
    [SerializeField]  AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 5;
    

    Coroutine fireCoroutine;

    public int Health { get => health; set => health = value; }
    public LaserType LaserPrefab { get => laserPrefab; set => laserPrefab = value; }
    public shootType ShootingType { get => shootingType; set => shootingType = value; }

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
        speedDeltaTime = speed * Time.deltaTime;
        
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector2(0 , 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector2(1 , 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector2(0 , 0 )).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector2(0 , 1)).y - padding;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
        
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
          fireCoroutine = StartCoroutine(Shoot(shootingType));
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireCoroutine);
        }
    }
    public IEnumerator Shoot(shootType shootingType)
    {
        if(shootingType == shootType.normal)
        {
            while (true)
            {
                AudioSource.PlayClipAtPoint(laserPrefab.FireSound, Camera.main.transform.position, laserPrefab.FireSoundVolume);
                GameObject laser = Instantiate(laserPrefab.gameObject, transform.position, Quaternion.identity) as GameObject;
                laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserPrefab.ProjectileSpeed);
                yield return new WaitForSeconds(laserPrefab.ProjectileFiringPeriod);
            }
        }
        else if (shootingType == shootType.trio)
        {
            while (true)
            {
                for(int i = 0; i < 3; i++)
                {
                    AudioSource.PlayClipAtPoint(laserPrefab.FireSound, Camera.main.transform.position, laserPrefab.FireSoundVolume);
                    GameObject laser = Instantiate(laserPrefab.gameObject, new Vector3(transform.position.x, transform.position.y + i,0), Quaternion.identity) as GameObject;
                    laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserPrefab.ProjectileSpeed);
                }
                yield return new WaitForSeconds(laserPrefab.ProjectileFiringPeriod);


            }
        }
        else if (shootingType == shootType.wide)
        {
            while (true)
            {
                for (int i = -1; i < 2; i++)
                {
                    AudioSource.PlayClipAtPoint(laserPrefab.FireSound, Camera.main.transform.position, laserPrefab.FireSoundVolume);
                    GameObject laser = Instantiate(laserPrefab.gameObject, new Vector3(transform.position.x, transform.position.y , 0), Quaternion.identity) as GameObject;
                    laser.GetComponent<Rigidbody2D>().velocity = new Vector2(i, laserPrefab.ProjectileSpeed);
                }
                yield return new WaitForSeconds(laserPrefab.ProjectileFiringPeriod);


            }
        }


    }


    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal")  * speedDeltaTime;
        var deltaY = Input.GetAxis("Vertical") * speedDeltaTime;

        var newXPose = Mathf.Clamp(transform.position.x + deltaX,xMin,xMax);
        var newYPose = Mathf.Clamp(transform.position.y + deltaY,yMin,yMax);

        transform.position = new Vector2(newXPose, newYPose);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        processDamage(damageDealer);
    }

    private void processDamage(DamageDealer damageDealer)
    {
        health -= damageDealer.Damage;
        damageDealer.Hit();
        if (health <= 0)
        {
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
            FindObjectOfType<LevelLoader>().LoadGameOverScreen();
        }
    }
}
