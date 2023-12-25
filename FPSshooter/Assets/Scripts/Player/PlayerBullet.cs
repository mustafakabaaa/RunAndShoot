using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField]
    private float destroyDelay = 25f;
   
    private void Start()
    {
        Destroy(gameObject,destroyDelay);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        Transform hitTransform = collision.transform;
        if (hitTransform.CompareTag("Enemy"))
        {
            //Debug.Log("Hit Enemy");
           hitTransform.GetComponent<EnemyHealth>().TakeDamageEnemy(10);
        }
       
        Destroy(gameObject);
    }
}
