using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuCanvasController : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;
    [SerializeField]
    Slider slider;
    [SerializeField]
    TextMeshProUGUI masterVolumePercentageText;
    [SerializeField]
    Button exitButton;
    [SerializeField]
    InputActionReference toggleCanvasButtonReference;

    int MasterVolumePercentage { get => (int)(slider.value * 100); }

    void Start()
    {
        slider.value = AudioListener.volume;
        masterVolumePercentageText.text = $"{MasterVolumePercentage}%";
        slider.onValueChanged.AddListener(ChangeMasterVolume);

        exitButton.onClick.AddListener(OnExitButtonClick);

        toggleCanvasButtonReference.action.performed += ToggleCanvas;

        canvas.gameObject.SetActive(false);
    }

    void ChangeMasterVolume(float volume)
    {
        masterVolumePercentageText.text = $"{MasterVolumePercentage}%";
        AudioListener.volume = volume;
    }

    void OnExitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void ToggleCanvas(InputAction.CallbackContext ctx)
    {
        canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
    }
}
