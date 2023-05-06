using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Big Jump");
            StarterAssets.FirstPersonController.Instance.JumpHeight = 6f;


            //hasJumped = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("norm Jump");
            StarterAssets.FirstPersonController.Instance.JumpHeight = 1.2f;


            //hasJumped = true;
        }
    }
}
