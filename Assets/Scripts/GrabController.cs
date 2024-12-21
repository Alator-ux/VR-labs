using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    [SerializeField]
    GameObject GrabLocomotionObject;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collision enter");
        if (collider.gameObject.CompareTag("Player"))
        {
            GrabLocomotionObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        Debug.Log("Collision exit");
        if (collider.gameObject.CompareTag("Player"))
        {
            GrabLocomotionObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
