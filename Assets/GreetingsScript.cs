using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GreetingsScript : MonoBehaviour
{
    [SerializeField]
    Button startButton;
    [SerializeField]
    TextMeshProUGUI text;
    [SerializeField]
    GameObject moveLocomotion, teleportLocomotion;

    void Start()
    {
        moveLocomotion.SetActive(false);
        teleportLocomotion.SetActive(false);

        var timer = Timer.Instance;
        text.text += $" {timer.SecondsLeft}";
        startButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            timer.StartTimer();
            var settings = Settings.Instance;
            moveLocomotion.SetActive(settings.moveLocomotion);
            teleportLocomotion.SetActive(settings.teleportationLocomotion);
        });

    }
}
