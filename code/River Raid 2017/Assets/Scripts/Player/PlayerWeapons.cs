using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerWeapons : MonoBehaviour {


    public WeaponTypes availableWeapons;
    public Transform ShotSpawn;

    private Weapon currentWeapon;


	void Start () {
        currentWeapon = availableWeapons.defaultWeapon;
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FireCurrentWeapon()
    {
        currentWeapon.Fire(ShotSpawn);
    }
}
