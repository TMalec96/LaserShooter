using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserType : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] float projectileFiringPeriod = 3f;
    [SerializeField] enum projectileType  {A,B,C};
    [Header("Audio")]
    [SerializeField] AudioClip fireSound;
    [SerializeField] [Range(0, 1)] float fireSoundVolume = 5;

    public float ProjectileSpeed { get => projectileSpeed; set => projectileSpeed = value; }
    public float ProjectileFiringPeriod { get => projectileFiringPeriod; set => projectileFiringPeriod = value; }
    public AudioClip FireSound { get => fireSound; set => fireSound = value; }
    public float FireSoundVolume { get => fireSoundVolume; set => fireSoundVolume = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }
   
}
