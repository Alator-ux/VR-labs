using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    [SerializeField]
    GameObject GrabLocomotionObject, vignetteObject;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collision enter");
        if (collider.gameObject.CompareTag("Player"))
        {
            vignetteObject.SetActive(true);
            GrabLocomotionObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        Debug.Log("Collision exit");
        if (collider.gameObject.CompareTag("Player"))
        {
            vignetteObject.SetActive(false);
            GrabLocomotionObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
