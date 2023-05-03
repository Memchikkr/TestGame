using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100f;
    private float currentHealth;
    [SerializeField]
    private PlayerHealth health;
    [SerializeField]
    private Text healthText;

    private void Start()
    {
        currentHealth = maxHealth;
        health = GetComponent<PlayerHealth>();
        healthText = GetComponentInChildren<Text>();
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0f)      
        {
            Die();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Die()
    {
        // Рестарт после смерти
        RestartGame();
    }

    void Update()
    {
        healthText.text = "Health: " + health.currentHealth.ToString();
        Vector3 healthPos = Camera.main.WorldToScreenPoint(health.transform.position);
        healthText.transform.position = healthPos;
    }
}