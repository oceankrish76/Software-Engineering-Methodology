using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    public float movementSpeed = .5f;
    public float distance = .75f;

   void Start()
    {
        iTween.MoveBy(gameObject, iTween.Hash("x", distance, "speed", movementSpeed, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
    }
}