using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIButtonBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public static GUIButtonBehavior Instance;

    void Start()
    {

    }

    public void StartMenu()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -2);
    }

    public void StartGame()
    {
        GameBehavior.Instance.CurrentState = State.Title;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //StartAudioBehavior.Instance.PlaySound(StartAudioBehavior.Instance.SelectHit, 0.2f);

    }

    public void InfoMenuGame()
    {
        //StartAudioBehavior.Instance.PlaySound(StartAudioBehavior.Instance.SelectHit, 0.2f);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }
}
