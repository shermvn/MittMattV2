using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBehavior : MonoBehaviour
{
    public static PlayerHealthBehavior Instance;
    [SerializeField] public Image _healthBarPSprites;
    private Camera _cam;
    // Start is called before the first frame update

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
    void Start()
    {
        //_cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateHealthBar(float maxHealth, float currentHealth)
    {
        _healthBarPSprites.fillAmount = (currentHealth / maxHealth);
        Debug.Log(currentHealth / maxHealth);
        Debug.Log(maxHealth);
        Debug.Log(currentHealth);


        //Debug.Log(_healthBarSprites.fillAmount);
    }
}