using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRedBullet : MonoBehaviour
{
    [SerializeField]
    private float damageAmount = 10f;


    private void OnCollisionEnter(Collision collision) 
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
