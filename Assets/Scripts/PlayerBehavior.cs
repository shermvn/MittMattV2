using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public static PlayerBehavior Instance;
    [SerializeField] public PlayerHealthBehavior _healthPbar;
    private float _currentPHealth;
    private float maxPHealth = 100;
    private float count = 0;




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
        // Assuming you are accessing the object's position using transform
        
    }
    private void Start()
    {
        _currentPHealth = maxPHealth;
    }

    private void Update()
    {
        Debug.Log("PizzaCount= " + GUIBehavior.Instance.PizzaCount);
        Debug.Log("CoinCount= " + GUIBehavior.Instance.CoinCount);


        if (count == 0 && transform.position.y <= -15)
        {
            Debug.Log("fell");
            GameBehavior.Instance.GoSeq();
            count++;
        }
        if(GUIBehavior.Instance.CoinCount >= 3 && Input.GetKeyDown(KeyCode.C)){
            Debug.Log("C");
            TimerBehavior.Instance.timeValue += 20;
            GUIBehavior.Instance.CoinCount -= 3;
            AudioManager.Instance.PlaySound(AudioManager.Instance.TimeHit, 0.2f);

        }
        if (GUIBehavior.Instance.PizzaCount >= 1 && Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Z");

            _currentPHealth = 20;
            GUIBehavior.Instance.PizzaCount -= 1;
            AudioManager.Instance.PlaySound(AudioManager.Instance.HealHit, 0.2f);

        }
    }

    public void PlayerReset()
    {
        count = 0;

    }

   public void TakeDamage(int damage)
    {
        _currentPHealth -= damage;
        //Debug.Log(_currentHealth);
        _healthPbar.updateHealthBar(maxPHealth, _currentPHealth);


        if (_currentPHealth <= 0)
        {
            GameBehavior.Instance.GoSeq();

        }
    }

    public void Fell()
    {
   
    }
   
}   




