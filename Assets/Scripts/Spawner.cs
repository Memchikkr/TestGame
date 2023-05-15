using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private Transform spawnPoint;
    private float timer = 0f;
    [SerializeField]
    private float spawnTime = 5f;
    private GameObject obj;

    private void Update()
    {
        timer += Time.deltaTime;
        if ((obj == null || obj.Equals(null)) && timer >= spawnTime)
        {
            timer = 0f;
            obj = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}

