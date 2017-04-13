using UnityEngine;
using System.Collections;

public class EnemyWeaponController : MonoBehaviour
{

    public Weapon shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    private AudioSource audioSource;

    void Start()
    {
        InvokeRepeating("Fire", delay, fireRate);
    }

    void Fire()
    {
        shot.Fire(shotSpawn);
    }
}