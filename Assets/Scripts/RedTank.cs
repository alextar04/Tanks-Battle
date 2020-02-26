using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTank : MonoBehaviour
{
    public float speed = 0.5f;
    public float rotationSpeed = 100;
    //private Rigidbody linkRigidBody;


    // Первый кадр в отрисовке танка
    void Start()
    {
        // Инициализация компонента с физикой, который прицеплен в unity
        //linkRigidBody = GetComponent<Rigidbody>();

    }

    void Update()
    {

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
