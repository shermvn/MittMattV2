using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUpBehavior : MonoBehaviour
{
    private static PowerUpBehavior Instance;


    //private void Awake()
    //{

    //    // Singleton pattern
    //    if (Instance != null && Instance != this)
    //    {
    //        Destroy(this);
    //    }
    //    else
    //    {
    //        Instance = this;
    //    }

    //}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(" gone");
        if (other.gameObject.CompareTag("Player")&& this.gameObject.CompareTag("Coin"))
        {
            // Destroy the game object when it collides with the player
            GUIBehavior.Instance.CoinCount++;
            Destroy(this.gameObject);
            PowerCountBehavior.Instance.CoinValue(GUIBehavior.Instance.CoinCount++);
            AudioManager.Instance.PlaySound(AudioManager.Instance.Coin, 0.2f);




        }
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Pizza"))
        {
            // Destroy the game object when it collides with the player
            GUIBehavior.Instance.PizzaCount++;
            Destroy(this.gameObject);
            //Debug.Log(GUIBehavior.Instance.PizzaCount);
            PowerCountBehavior.Instance.PizzaValue(GUIBehavior.Instance.PizzaCount);
            AudioManager.Instance.PlaySound(AudioManager.Instance.Pizza, 0.2f);


        }
    }
}
