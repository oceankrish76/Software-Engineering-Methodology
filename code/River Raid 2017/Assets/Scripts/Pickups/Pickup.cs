using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{


    public enum PickupTypes
    {
        Pickup_Fuel,
        Pickup_Weapon,
        Pickup_Other
    };

    public PickupTypes pickupType;
    public GameObject explosion;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Pickup");

            switch (pickupType)
            {
                case PickupTypes.Pickup_Fuel:

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

        if (other.gameObject.tag == "Bullets")
        {
            GameObject particles = Instantiate(explosion, transform.position, transform.rotation);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }



}
