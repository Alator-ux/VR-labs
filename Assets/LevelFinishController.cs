using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinishController : MonoBehaviour
{
    
    void Start()
    {
        var transition = GetComponent<Transition>();
        Timer.Instance.OnTimeLeft += () => {
            transition.LoadLevel("MainMenu");
        };
    }
}
