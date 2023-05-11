using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class StartBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public static StartBehavior Instance;
    [SerializeField] private VisualEffect vfxGraph;

    void Start()
    {
        vfxGraph.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }
    //public void StartMenu()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -2);
    //}

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //StartAudioBehavior.Instance.PlaySound(StartAudioBehavior.Instance.SelectHit, 0.2f);

    }

    //public void InfoMenuGame()
    //{
    //    //StartAudioBehavior.Instance.PlaySound(StartAudioBehavior.Instance.SelectHit, 0.2f);

    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    //}
}