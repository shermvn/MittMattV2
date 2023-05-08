using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIBehavior : MonoBehaviour
{
    public static GUIBehavior Instance;
    [SerializeField] public GameObject GameOverScreen;
    [SerializeField] public GameObject PauseScreen;
    [SerializeField] public GameObject UI;
    [SerializeField] public GameObject PHB;
    [SerializeField] public GameObject Time;
    [SerializeField] public GameObject WinScreen;








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


        private void Start()
    {
        // Deactivate the game object at the start of the scene
        GameOverScreen.SetActive(false);
        WinScreen.SetActive(false);
        PauseScreen.SetActive(false);
        UI.SetActive(true);
        PHB.SetActive(true);
        Time.SetActive(true);





    }
    public void GoState(GameObject other)
    {
        other.SetActive(!other.activeSelf);
    }
   
}
