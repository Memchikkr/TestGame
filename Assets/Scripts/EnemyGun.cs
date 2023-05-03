using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField]
    private float fireDistance = 10f;
    [SerializeField]
    private float fireRate = 1f;
    [SerializeField]
    private float shotForce = 500;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform gun;

    private GameObject player;
    private float nextFireTime = 0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // Если игрок достаточно близко оружие стреляет
        if (Vector3.Distance(transform.position, player.transform.position) < fireDistance && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + (1f / fireRate);
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, gun.position, gun.rotation);
        bullet.GetComponent<Rigidbody>().useGravity = false;

        Vector3 shootDirection = (player.transform.position - transform.position).normalized;
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(shootDirection * shotForce);

        Destroy(bullet, 2f);
    }
}