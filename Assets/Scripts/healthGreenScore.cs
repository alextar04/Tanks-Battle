using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class healthGreenScore : MonoBehaviour, IPunObservable
{
    public GameObject go;
    GreenTank healthController;
    public float healthPointTotal = -1;
    public float healthPointCurrent = -1;
    public float timerCooldown = -1;
    private TextMeshProUGUI manipulatorText;
    public TextMeshProUGUI manipulatorCooldown;

    // Локальное представление объекта для клиента
    private PhotonView photonView;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if (stream.IsWriting){
            Debug.Log("ОТПРАВКА ДАННЫХ ПО ПАНЕЛИ");
            stream.SendNext(healthPointCurrent);
            stream.SendNext(healthPointTotal);
            stream.SendNext(timerCooldown);
        }else{
            Debug.Log("ПРИЕМ ДАННЫХ ПО ПАНЕЛИ");
            healthPointCurrent = (float) stream.ReceiveNext();
            healthPointTotal = (float) stream.ReceiveNext();
            timerCooldown = (float) stream.ReceiveNext();
            Debug.Log("HPC " + healthPointCurrent);
            Debug.Log("HPT " + healthPointTotal);
            Debug.Log("TC " + timerCooldown);
        }
    }


    void Start()
    {
        manipulatorText = GetComponent<TextMeshProUGUI>();
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (photonView.IsMine){
            //while (go == null)
            go = GameObject.Find("GreenTankNetwork(Clone)");
            healthController = go.GetComponent<GreenTank>();
            healthPointTotal = healthController.healthPointTotal;
            healthPointCurrent = healthController.healthPointCurrent;
            timerCooldown = healthController.timer;
        }

        string s = string.Format("{0:0.00}", timerCooldown);
        manipulatorText.text = '[' + healthPointCurrent.ToString() + '/' + healthPointTotal.ToString() + ']';
        manipulatorCooldown.text = "КД: " + s + " с";
        }
    }
