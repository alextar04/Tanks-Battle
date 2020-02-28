using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTank : MonoBehaviour
{
    public float speed = 0.5f;
    public float rotationSpeed = 100f;
    // Кулдаун пушки красного танка = 10 с.
    public float cooldown = 10f;
    public float timer = 0;
    // Префабы(ссылки на них) задаются в редакторе
    public GameObject bullet;
    public GameObject dulo;
    public float speedBullet = 2f;


    // Первый кадр в отрисовке танка
    void Start()
    {}

    // Произведение выстрела
    void fire()
    {
        // Нажали на пробел -> произвести выстрел
        if (Input.GetKey(KeyCode.Space) && timer == 0)
        {
            // Координаты дула
            Vector3 SpawnPoint = dulo.transform.position;
            Quaternion SpawnRoot = dulo.transform.rotation;
            // Создание пули
            GameObject bulletForFire = Instantiate(bullet, SpawnPoint, SpawnRoot) as GameObject;
            // Придание ей ускорения (Rigidbody берется у bullet)
            Rigidbody Run = bulletForFire.GetComponent<Rigidbody>();
            Run.AddForce(bulletForFire.transform.right * speedBullet, ForceMode.Impulse);
            Destroy(bulletForFire, 5);
            // Выставить кулдаун
            timer = cooldown;
        }
    }

    void FixedUpdate()
    {
        // Слушатель прослушивает нажатую кнопку 
        fire();
    }

    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else
            timer = 0;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-1 * Vector3.up * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}
