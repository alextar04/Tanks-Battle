using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovingBulletScript : MonoBehaviour
{
    void Start(){}
    
    void Update(){}

    // Проверка на получение урона
    void OnCollisionEnter(Collision myTrigger){
  		if ((myTrigger.gameObject.name == "firstLevelBullet(Clone)") || (myTrigger.gameObject.name == "fiveLevelBullet(Clone)"))
  		{
    		Destroy(myTrigger.gameObject);
    		Debug.Log("Bullet removed: ");
  		}
	}
}
