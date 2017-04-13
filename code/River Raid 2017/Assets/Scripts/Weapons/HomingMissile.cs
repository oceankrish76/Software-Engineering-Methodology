using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : Weapon {

    public float missileSpeed = 0.02f;

    private SimpleGameManager manager;
  
    void Awake()
    {
        manager = FindObjectOfType<SimpleGameManager>();
    }

    public override void Fire(Transform position, GameObject owner)
    {
        base.Fire(position,owner);
        StartCoroutine("MoveTowards");
    }


    IEnumerator MoveTowards()
    {
        while (gameObject != null && manager.playerIsAlive)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindWithTag("Player").transform.position, missileSpeed);
            yield return new WaitForEndOfFrame();
        }
    }

}
