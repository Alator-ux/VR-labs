using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject move, teleportation;

    public static string moveLocomotionPref = "moveLocomotion";
    public static string teleportationLocomotionPref = "teleportationLocomotion";

    void Start()
    {
        var moveStatus = GetStatusValue(moveLocomotionPref);
        var teleportationStatus = GetStatusValue(teleportationLocomotionPref);
        SetMoveLocomotionStatus(moveStatus);
        SetTeleportationLocomotionStatus(teleportationStatus);
    }

    public static bool GetStatusValue(string prefName)
    {
        return PlayerPrefs.GetInt(prefName, 1) == 1 ? true : false;
    }

    public static void SetStatusValue(string prefName, bool value)
    {
        PlayerPrefs.SetInt(prefName, value ? 1 : 0);
    }

    public void SetMoveLocomotionStatus(bool value)
    {
        SetStatusValue(moveLocomotionPref, value);
        move.SetActive(value);
        Settings.Instance.moveLocomotion = value;
    }
    public void SetTeleportationLocomotionStatus(bool value)
    {
        SetStatusValue(teleportationLocomotionPref, value);
        teleportation.SetActive(value);
        Settings.Instance.teleportationLocomotion = value;
    }
}
