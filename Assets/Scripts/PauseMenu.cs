using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PauseMenu : MonoBehaviourPunCallbacks
{

	public GameObject pauseObject;

    public void OpenStartMenu()
    {
        Time.timeScale = 1;
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(0);
    }

    public void PauseButtonClicked(){
    	pauseObject.gameObject.SetActive(true);
    	Time.timeScale = 0;
    }

    public void BackToGame(){
    	Time.timeScale = 1;
        pauseObject.gameObject.SetActive(false);
    }
    
}
