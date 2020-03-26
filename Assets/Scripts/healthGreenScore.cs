using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class healthGreenScore : MonoBehaviour
{
    public GameObject go;
    GreenTank healthController;
    public float healthPointTotal;
    public float healthPointCurrent;
    public float timerCooldown;
    private TextMeshProUGUI manipulatorText;
    public TextMeshProUGUI manipulatorCooldown;

    void Start()
    {
        // Найти объект по имени
        go = GameObject.Find("GreenTank");
        // взять его компонент где лежит здоровье
        healthController = go.GetComponent<GreenTank>();
        // взять переменную здоровья
        healthPointTotal = healthController.healthPointTotal;
        healthPointCurrent = healthController.healthPointCurrent;
        timerCooldown = healthController.timer;
        manipulatorText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timerCooldown = healthController.timer;
        healthPointCurrent = healthController.healthPointCurrent;
        string s = string.Format("{0:0.00}", timerCooldown);
        manipulatorText.text = '[' + healthPointCurrent.ToString() + '/' + healthPointTotal.ToString() + ']';
        manipulatorCooldown.text = "КД: " + s + " с";
    }
}
