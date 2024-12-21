using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SettingsMenuScript : MonoBehaviour
{
    [SerializeField]
    GameObject previousObject;
    [SerializeField]
    Slider slider;
    [SerializeField]
    TextMeshProUGUI masterVolumePercentageText;
    [SerializeField]
    Button backButton;
    [SerializeField]
    Toggle toggleMoveLocomotion, toggleTeleportationLocomotion;
    
    PlayerController playerController;

   

    int MasterVolumePercentage { get => (int)(slider.value * 100); }
    
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        backButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            previousObject.SetActive(true);
        });

        toggleMoveLocomotion.onValueChanged.AddListener(playerController.SetMoveLocomotionStatus);
        toggleTeleportationLocomotion.onValueChanged.AddListener(playerController.SetTeleportationLocomotionStatus);
    }

    public void OnActivate()
    {
        slider.value = AudioListener.volume;
        masterVolumePercentageText.text = $"{MasterVolumePercentage}%";
        slider.onValueChanged.AddListener(ChangeMasterVolume);
        UpdateToggles();
    }

    void ChangeMasterVolume(float volume)
    {
        masterVolumePercentageText.text = $"{MasterVolumePercentage}%";
        AudioListener.volume = volume;
    }

    void UpdateToggles()
    {
        var moveStatus = PlayerController.GetStatusValue(PlayerController.moveLocomotionPref);
        var teleportationStatus = PlayerController.GetStatusValue(PlayerController.teleportationLocomotionPref);
        toggleMoveLocomotion.isOn = moveStatus;
        toggleTeleportationLocomotion.isOn = teleportationStatus;
    }
}
