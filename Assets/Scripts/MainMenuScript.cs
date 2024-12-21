using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    Button startGameButton, settingsButton, exitButton;
    [SerializeField]
    SettingsMenuScript settings;
    [SerializeField]
    Transition transition;
    private void Start()
    {

        startGameButton.onClick.AddListener(() => transition.LoadLevel("BasicScene"));
        exitButton.onClick.AddListener(OnExitButtonClick);
        settingsButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            settings.gameObject.SetActive(true);
            settings.OnActivate();
        });
    }

    void OnExitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
