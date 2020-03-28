using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class healthRedScore : MonoBehaviour, IPunObservable
{
	public GameObject go;
    RedTank healthController;
    public float healthPointTotal;
    public float healthPointCurrent;
    public float timerCooldown;
    public TextMeshProUGUI manipulatorText;
    public TextMeshProUGUI manipulatorCooldown;

    // Локальное представление объекта для клиента
    private PhotonView photonView;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if (stream.IsWriting){
            stream.SendNext(healthPointCurrent);
            stream.SendNext(healthPointTotal);
            stream.SendNext(timerCooldown);
        }else{
            healthPointCurrent = (float) stream.ReceiveNext();
            healthPointTotal = (float) stream.ReceiveNext();
            timerCooldown = (float) stream.ReceiveNext();
        }
    }

    void Start()
    {
            // Найти объект по имени
    		go = GameObject.Find("RedTankMaus");
    		// взять его компонент где лежит здоровье
    		healthController = go.GetComponent<RedTank>();
    		// взять переменную здоровья
    		healthPointTotal = healthController.healthPointTotal;
    		healthPointCurrent = healthController.healthPointCurrent;
    		timerCooldown = healthController.timer;
        
            photonView = GetComponent<PhotonView>();
    }

    
    void Update()
    {
        if (photonView.IsMine){
            healthController = go.GetComponent<RedTank>();
        	timerCooldown = healthController.timer;
        	healthPointCurrent = healthController.healthPointCurrent;
            healthPointTotal = healthController.healthPointTotal;
        }
        	string s = string.Format("{0:0.00}", timerCooldown);
        	manipulatorText.text = '[' + healthPointCurrent.ToString() + '/' + healthPointTotal.ToString() + ']';
            manipulatorCooldown.text = "КД: " + s + " с";
    }
}
