using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBlueBullet : MonoBehaviour
{
    [SerializeField]
    private float damageAmount = 20f;


    private void OnCollisionEnter(Collision collision) 
    {
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damageAmount);
        }
    }
}
