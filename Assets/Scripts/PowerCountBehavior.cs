using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerCountBehavior : MonoBehaviour
{
    public static PowerCountBehavior Instance;
    public TextMeshProUGUI PizzaText;
    public TextMeshProUGUI CoinText;

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
        // Call the TransferValue function to update the TextMeshPro object with the integer value
    }

   public void PizzaValue(int intValue)
    {
        // Convert the integer value to string
        string stringValue = intValue.ToString();


        // Set the text of the TextMeshPro object to the string value
        PizzaText.SetText(stringValue);
    }
    public void CoinValue(int intValue)
    {
        // Convert the integer value to string
        string stringValue = intValue.ToString();
       
        // Set the text of the TextMeshPro object to the string value
        CoinText.SetText(stringValue);
    }

}
