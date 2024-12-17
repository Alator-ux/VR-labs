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
    InputActionReference toggleCanvasButtonReference;

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

        usedKeysText.text = $"Ключей использовано 0/{allKeysCount}";

        toggleCanvasButtonReference.action.performed += ToggleCanvas;

        canvas.gameObject.SetActive(false);
    }

    void UpdateUsedKeysText(Key key)
    { 
        if (!usedKeysIds.Contains(key.Id))
        {
            usedKeysIds.Add(key.Id);
        }

        usedKeysText.text = $"Ключей использовано {usedKeysCount}/{allKeysCount}";
    }

   void ToggleCanvas(InputAction.CallbackContext ctx)
   {
        canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
   }
}
