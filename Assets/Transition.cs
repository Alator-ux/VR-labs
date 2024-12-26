using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Transition : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    CanvasGroup canvasGroup;

    public float transitionDelayTime = 4.0f;


    float previousTime;
    void Awake()
    {
        //animator.SetTrigger("TriggerTransition");
        UnfadeWithDelay();
    }

    void FadeWithDelay(Action onFinal = null)
    {
        StartCoroutine(ContinuousTransition(0, 1, false, onFinal));
    }

    void UnfadeWithDelay(Action onFinal = null)
    {
        StartCoroutine(ContinuousTransition(1, 0, true, onFinal));
    }

    IEnumerator ContinuousTransition(float from, float to, bool originalState, Action onFinal)
    {
        canvasGroup.interactable = originalState;
        canvasGroup.blocksRaycasts = originalState;

        var sign = Mathf.Sign(to - from);
        float sections = Mathf.Abs(to - from) / (transitionDelayTime * 100 / 2);
        canvasGroup.alpha = from;

        while (canvasGroup.alpha * sign < to)
        {
            yield return new WaitForSeconds(sections);
            canvasGroup.alpha += sections * sign;
        }

        canvasGroup.interactable = !originalState;
        canvasGroup.blocksRaycasts = !originalState;

        onFinal?.Invoke();
    }

    public void LoadLevel(string levelName)
    {
        FadeWithDelay(() => SceneManager.LoadScene(levelName));
    }
    IEnumerator DelayLoadLevel(string levelName)
    {
        animator.SetTrigger("TriggerStart");
        yield return new WaitForSeconds(transitionDelayTime);
        SceneManager.LoadScene(levelName);
    }
}