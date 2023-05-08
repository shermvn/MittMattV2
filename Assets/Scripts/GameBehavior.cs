using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    public int score;
    //public TextMeshProUGUI Score;
    //public TextMeshProUGUI gameOver;
    //public TextMeshProUGUI playButton;
    //public GameObject GameOverCanvas;


    public static GameBehavior Instance;

    public State CurrentState;

    //public void GameOver()
    //{
    //    Debug.Log("no");
    //    GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
    //}
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
        // Changed to Play fromt title
        //GuiBehavior.Instance.UpdateMessageGUI("Press Return to Start");
        //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
        //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.ScoreGui);
        //GuiBehavior.Instance.ToggleHealthVisibility(GuiBehavior.Instance.Health);
        //Time.timeScale = 0f;
        CurrentState = State.Title;

    }
    public void GameOverReset()
    {
        Time.timeScale = 0f;
        BulletBehavior.Instance.DestroyBullet();
    }
    private void Update()
    {
        //Debug.Log(CurrentState);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        switch (CurrentState)
        {
            case State.Title:

                //Player.Instance.enabled = false;
                //Debug.Log(CurrentState);
                //GUIBehavior.Instance.GameOverScreen.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Return))
                {

                    PlaySeq();
                    Debug.Log(CurrentState);
                    //Time.timeScale = 1f;
                    //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
                    //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.ScoreGui);
                    //GuiBehavior.Instance.ToggleHealthVisibility(GuiBehavior.Instance.Health);
                    //CurrentState = State.Play;
                    //AudioBehavior.Instance.Soundtrack.loop = true;
                    //AudioBehavior.Instance.Soundtrack.Play();
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    GoSeq();
                    //AudioBehavior.Instance.PlaySound(AudioBehavior.Instance.DeathHit, 0.2f);
                    //AudioBehavior.Instance.Soundtrack.Pause();


                }
                break;
            case State.Play:
                if (Input.GetKeyDown(KeyCode.P))
                {
                    PauseSeq();
                    //Time.timeScale = 0f;
                    //Player.Instance.enabled = false;
                    //GuiBehavior.Instance.UpdateMessageGUI("Pause");
                    //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
                    //CurrentState = State.Pause;
                    //AudioBehavior.Instance.Soundtrack.Pause();


                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    GoSeq();
                    //AudioBehavior.Instance.PlaySound(AudioBehavior.Instance.DeathHit, 0.2f);
                    //AudioBehavior.Instance.Soundtrack.Pause();


                    //GuiBehavior.Instance.UpdateMessageGUI("Game Over");
                    //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
                    //Time.timeScale = 0f;
                    //CurrentState = State.GameOver;

                }
                break;
            case State.Win:
                //Debug.Log(CurrentState);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    //Player.Instance.enabled = true;
                    //Time.timeScale = 1f;
                    //AudioBehavior.Instance.Soundtrack.Play();
                    TitleSeq();
                    //GUIBehavior.Instance.GoState(GUIBehavior.Instance.PauseScreen);
                    //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
                    //CurrentState = State.Play;
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    //GoSeq();
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -1);
                    //AudioBehavior.Instance.PlaySound(AudioBehavior.Instance.DeathHit, 0.2f);
                    //AudioBehavior.Instance.Soundtrack.Pause();
                }
                break;
                
            case State.GameOver:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    TitleSeq();
                    //Player.Instance.ResetPlayer();
                    //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.ScoreGui);
                    //GuiBehavior.Instance.ToggleHealthVisibility(GuiBehavior.Instance.Health);
                    //GuiBehavior.Instance.UpdateMessageGUI("Press Return to Start");

                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -1);
                    //GuiBehavior.Instance.UpdateMessageGUI("Game Over");
                    //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
                    //Time.timeScale = 0f;
                    //CurrentState = State.GameOver;

                }
                break;
            case State.Pause:
                //Debug.Log(CurrentState);
                if (Input.GetKeyDown(KeyCode.P))
                {
                    //Player.Instance.enabled = true;
                    //Time.timeScale = 1f;
                    //AudioBehavior.Instance.Soundtrack.Play();
                    PlaySeq();
                    GUIBehavior.Instance.GoState(GUIBehavior.Instance.PauseScreen);
                    //GuiBehavior.Instance.ToggleGUIVisibility(GuiBehavior.Instance.OverGui);
                    //CurrentState = State.Play;
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    GoSeq();
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -1);
                    //AudioBehavior.Instance.PlaySound(AudioBehavior.Instance.DeathHit, 0.2f);
                    //AudioBehavior.Instance.Soundtrack.Pause();
                }
                break;
        }
 

    }
    public void GoSeq()
    {
        Time.timeScale = 0f;
        GUIBehavior.Instance.GoState(GUIBehavior.Instance.GameOverScreen);
        UIOff();
        CurrentState = State.GameOver;
        PlayerBehavior.Instance.PlayerReset();
        TimerBehavior.Instance.GameOverTimer();
    }
    private void PauseSeq()
    {
        Time.timeScale = 0f;
        GUIBehavior.Instance.GoState(GUIBehavior.Instance.PauseScreen);
        UIOff();

        CurrentState = State.Pause;

    }

    private void PlaySeq()
    {
        Time.timeScale = 1f;
        CurrentState = State.Play;
        StarterAssets.FirstPersonController.Instance.transform.position = Vector3.zero;
        PlayerBehavior.Instance.transform.position = Vector3.zero;
        GUIBehavior.Instance.UI.SetActive(true);
        GUIBehavior.Instance.PHB.SetActive(true);
        GUIBehavior.Instance.WinScreen.SetActive(false);


    }
    private void TitleSeq()
    {
        CurrentState = State.Title;
        Time.timeScale = 0f;
        Debug.Log(CurrentState);
        //PlayerBehavior.Instance.PlayerReset();
        GUIBehavior.Instance.GameOverScreen.SetActive(false);
        GUIBehavior.Instance.WinScreen.SetActive(false);
        StarterAssets.FirstPersonController.Instance.transform.position = new Vector3(0, 0, 0);




    }
    private void UIOff()
    {
        GUIBehavior.Instance.UI.SetActive(false);
        GUIBehavior.Instance.PHB.SetActive(false);
        GUIBehavior.Instance.Time.SetActive(false);


    }

}





