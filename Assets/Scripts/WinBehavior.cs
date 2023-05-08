using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBehavior : MonoBehaviour
{
    public static WinBehavior Instance;
    private void Awake()
    {

        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Win");
        if (collision.gameObject.CompareTag("Player"))
        {
            GUIBehavior.Instance.WinScreen.SetActive(true);
            Time.timeScale = 0f;
            GameBehavior.Instance.CurrentState = State.Win;
        }
    }
}
