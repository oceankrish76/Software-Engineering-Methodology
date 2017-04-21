using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#else

# endif
using System.Collections;
using System.Collections.Generic;

public class EnemyWeaponController : MonoBehaviour
{
    public enum FireType { SingleShot, Burst };

    public Weapon weapon;
    public FireType firingMethod;
    public Transform shotSpawn;
    public float fireDelayMin = 1f;
    public float fireDelayMax;
    public float delay;

    private SimpleGameManager manager;
    //Custom editor variables
    [HideInInspector]
    public int burstAmount;

    void Start()
    {
        manager = FindObjectOfType<SimpleGameManager>();
        if(firingMethod == FireType.SingleShot)
        {
            StartCoroutine(Fire());
        } else
        {
            StartCoroutine(BurstFire());
        }
 
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(delay);
        while(true)
        {
            weapon.Fire(shotSpawn, gameObject);
            yield return new WaitForSeconds(Random.Range(1f, fireDelayMax));
        }
    }


    IEnumerator BurstFire()
    {
        yield return new WaitForSeconds(delay);
        while (true)
        {
            for(int i = 0; i < burstAmount; ++i)
            {
                weapon.Fire(shotSpawn, gameObject);
                yield return new WaitForSecondsRealtime(.1f);
            }

            yield return new WaitForSeconds(Random.Range(fireDelayMin, fireDelayMax));
        }
    }

}
#if UNITY_EDITOR
//Custom editor class  
[CustomEditor(typeof(EnemyWeaponController))]
[CanEditMultipleObjects]
public class EnemyWeaponEditor: Editor
{
    void OnEnable()
    {

    }
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        var controller = target as EnemyWeaponController;

        if (controller.firingMethod == EnemyWeaponController.FireType.Burst)
        {
            controller.burstAmount = EditorGUILayout.IntField("Burst Amount", controller.burstAmount);
        }

    }
}
#endif