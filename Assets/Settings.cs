using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class Settings : MonoBehaviour
{
    GameObject move, teleport;

    public static Settings Instance { get; private set; }
    public bool moveLocomotion = true;
    public bool teleportationLocomotion = true;
    void Awake()
    {
        move = FindObjectOfType<DynamicMoveProvider>().gameObject;
        teleport = FindObjectOfType<TeleportationProvider>().gameObject;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void SetSettingsValues()
    {
        move.SetActive(moveLocomotion);
        teleport.SetActive(teleportationLocomotion);
    }
}
