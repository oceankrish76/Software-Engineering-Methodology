using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyWeaponController : MonoBehaviour
{

    public Weapon weapon;
    public Transform shotSpawn;
    public float fireDelayMax;
    public float delay;

    private SimpleGameManager manager;


    private List<Weapon> shotsFired = new List<Weapon>();

    void Start()
    {
        manager = FindObjectOfType<SimpleGameManager>();
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        yield return new WaitForSecondsRealtime(delay);
        while(true)
        {
            weapon.Fire(shotSpawn, gameObject);
            yield return new WaitForSecondsRealtime(Random.Range(1f, fireDelayMax));
        }
    }


}