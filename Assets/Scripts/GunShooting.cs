using UnityEngine;

public class GunShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform gun;

    void Update()
    {
        // Проверяем, была ли нажата левая кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    
    public void Shoot()
    {
        // Создаем новый шарик из префаба
        GameObject bullet = Instantiate(bulletPrefab, gun.position, gun.rotation);

        // Наносим силу шарику
        bullet.GetComponent<Rigidbody>().useGravity = false;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(gun.forward * 500f);

        // Удаляем шарик через 2 секунды
        Destroy(bullet, 2f);
    }
}