using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Transition : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    public float transitionDelayTime = 4.0f;
    void Awake()
    {
        animator.SetTrigger("TriggerTransition");
    }
    public void LoadLevel(string levelName)
    {
        StartCoroutine(DelayLoadLevel(levelName));
    }
    IEnumerator DelayLoadLevel(string levelName)
    {
        animator.SetTrigger("TriggerStart");
        yield return new WaitForSeconds(transitionDelayTime);
        SceneManager.LoadScene(levelName);
    }
}