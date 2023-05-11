using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderBehavior : MonoBehaviour
{
    public static FaderBehavior Instance;
    private void Awake()
    {

        //// Singleton pattern
        //if (Instance != null && Instance != this)
        //{
        //    Destroy(this);
        //}
        //else
        //{
        //    Instance = this;
        //}
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("fader");
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("fader");
    //        PlayerBehavior.Instance.TakeDamage(40);
    //    }
    //}
}
