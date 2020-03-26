using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTank : MonoBehaviour
{
    public float speed = 1f;
    public float rotationSpeed = 100f;
    // Кулдаун пушки красного танка = 10 с.
    public float cooldown = 10f;
    public float timer = 0;
    // Префабы(ссылки на них) задаются в редакторе
    public GameObject bullet;
    public GameObject dulo;
    public float speedBullet = 6000f;

    // Здоровье игрока
    public float healthPointTotal = 500;
    public float healthPointCurrent = 500;
    public float countDamage = 200;
    public bool alive = true;
    private GameObject go;
    RedTank PositionController;


    // Первый кадр в отрисовке танка
    void Start()
    {
        go = GameObject.Find("RedTankMaus");
        // Найти контроллер позиции танка
        PositionController = go.GetComponent<RedTank>();
    }

    // Проверка на получение урона
    // Проверка на взятие бонуса
    void OnCollisionEnter(Collision myTrigger){
        if (myTrigger.gameObject.name == "fiveLevelBullet(Clone)")
        {
            healthPointCurrent -= 100;
            Debug.Log("Damaged RedTank : " + healthPointCurrent);
            Destroy(myTrigger.gameObject);
            Debug.Log("Bullet removed: ");
            if (healthPointCurrent <= 0){
                alive = false;
                Debug.Log("RedAlive: " + alive);
                healthPointCurrent = 0;
            }
        }
        // Бонус-аптечка
        if (myTrigger.gameObject.name == "firstaid(Clone)")
        {
            if (healthPointCurrent + 100 <= healthPointTotal)
                healthPointCurrent += 100;
            else
                healthPointCurrent = healthPointTotal;
            Destroy(myTrigger.gameObject);
            Debug.Log("HealthBox removed: ");
        }
        // Бонус-дрель
        if (myTrigger.gameObject.name == "Drill(Clone)")
        {
            if (healthPointCurrent + 100 <= healthPointTotal)
                healthPointCurrent += 100;
            else
                healthPointCurrent = healthPointTotal;
            Destroy(myTrigger.gameObject);
            Debug.Log("Drill removed: ");
        }
    }

    // Произведение выстрела
    void fire()
    {
        // Нажали на пробел -> произвести выстрел
        if (Input.GetKey(KeyCode.Space) && timer == 0 && alive)
        {
            // Координаты дула
            Vector3 SpawnPoint = dulo.transform.position;
            Quaternion SpawnRoot = dulo.transform.rotation;
            // Quaternion SpawnRoot = bullet.transform.rotation;
            // Создание пули
            GameObject bulletForFire = Instantiate(bullet, SpawnPoint, SpawnRoot) as GameObject;
            // Придание ей ускорения (Rigidbody берется у bullet)
            Rigidbody Run = bulletForFire.GetComponent<Rigidbody>();
            Run.AddForce(bulletForFire.transform.up * speedBullet, ForceMode.Impulse);
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

        if (alive && PositionController.transform.position.y < 7.1f){
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
}
