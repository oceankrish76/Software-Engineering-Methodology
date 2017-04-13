using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Pickup : MonoBehaviour
{


    public enum PickupTypes
    {
        Pickup_Fuel,
        Pickup_Weapon,
        Pickup_Other
    };

    public PickupTypes pickupType;
    public int scoreForPickup = 100;
    public int scoreForDestroying = -100;
    public GameObject explosion;
    public AudioClip explosionSound;


    //Custom editor variables
    [HideInInspector]
    public float refuelRate;
    [HideInInspector]
    public int refuelScore;


    //Private stuff
    private SimpleGameManager manager;

    // Use this for initialization
    void Start()
    {
        manager = FindObjectOfType<SimpleGameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            switch (pickupType)
            {
                case PickupTypes.Pickup_Fuel:
                    //Do nothing, since we're handling this in OnTriggerStay
                    break;
                case PickupTypes.Pickup_Weapon:

                    Destroy(gameObject);
                    break;
                case PickupTypes.Pickup_Other:

                    Destroy(gameObject);
                    break;
                default:
                    Debug.Log("whatsthis");
                    break;
            }

            
        }

        if (other.gameObject.tag == "PlayerBullets" || other.gameObject.tag == "EnemyBullets")
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            Instantiate(explosion, transform.position, transform.rotation);
            manager.PlayerScore += scoreForDestroying;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void OnTriggerStay (Collider other)
    {
        if(other.gameObject.tag == "Player" && pickupType == PickupTypes.Pickup_Fuel)
        {
            manager.PlayerFuel += refuelRate;
            manager.PlayerScore += refuelScore;
        }

    }



}


//Custom editor class  
[CustomEditor(typeof(Pickup))]
[CanEditMultipleObjects]
public class PickupEditor : Editor
{
    void OnEnable()
    {

    }
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        var pickup = target as Pickup;

        if(pickup.pickupType == Pickup.PickupTypes.Pickup_Fuel)
        {
            pickup.refuelRate = EditorGUILayout.FloatField("Refuel rate", pickup.refuelRate);
            pickup.refuelScore = EditorGUILayout.IntField("Refuel score", pickup.refuelScore);
        }
        
    }
}