using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandCanvasController : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;
    [SerializeField]
    TextMeshProUGUI usedKeysText;
    [SerializeField]
    TextMeshProUGUI timerText;
    [SerializeField]
    InputActionReference toggleCanvasButtonReference;
    [SerializeField]
    float secondsLeft;

    HashSet<string> usedKeysIds;
    Key[] allKeys;
    int usedKeysCount { get => usedKeysIds.Count; }
    int allKeysCount { get => allKeys.Length; }

    void Start()
    {
        allKeys = FindObjectsByType<Key>(FindObjectsSortMode.None);
        foreach (var key in allKeys)
        {
            key.OnKeyUsed += UpdateUsedKeysText;
        }

        usedKeysIds = new HashSet<string>();

        usedKeysText.text = $"������ ������������ 0/{allKeysCount}";

        toggleCanvasButtonReference.action.performed += ToggleCanvas;

        canvas.enabled = false;
    }

    void UpdateUsedKeysText(Key key)
    { 
        if (!usedKeysIds.Contains(key.Id))
        {
            usedKeysIds.Add(key.Id);
        }

        usedKeysText.text = $"������ ������������ {usedKeysCount}/{allKeysCount}";
    }

   void ToggleCanvas(InputAction.CallbackContext ctx)
   {
        canvas.enabled = !canvas.enabled;
        //canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
   }

    private void FixedUpdate()
    {
        secondsLeft = Mathf.Max(secondsLeft - Time.deltaTime, 0);
        timerText.text = $"�������� �������: {(int)Mathf.Round(secondsLeft)}";
    }
}
