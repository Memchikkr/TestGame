using UnityEngine;

public class GunShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform gun;
    [SerializeField]
    private float bulletForce = 1000f;
    private GameObject bullet;
    private Vector3 forwardDirection;
    private Vector3 targetDirection;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    
    private void Shoot()
    {
        bullet = Instantiate(bulletPrefab, gun.position, gun.rotation);
        forwardDirection = Camera.main.transform.forward;
        targetDirection = Quaternion.Euler(0f, -1f, -7f) * forwardDirection;

        // Наносим силу шарику
        bullet.GetComponent<Rigidbody>().useGravity = false;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(targetDirection * bulletForce);
        Destroy(bullet, 2f);
    }
}
