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
        if (count == 0 && transform.position.y <= -15)
        {
            Debug.Log("fell");
            GameBehavior.Instance.GoSeq();
            count++;
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




