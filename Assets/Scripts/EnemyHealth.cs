using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] 
    private float maxHealth = 100f;
    [SerializeField]
    private float currentHealth;
    private event System.Action onDeath;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        onDeath?.Invoke();

        Destroy(gameObject);
    }
}