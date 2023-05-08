using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerBehavior : MonoBehaviour
{
    public static DamagePlayerBehavior Instance;
    [SerializeField] public int Damage = 20;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnBullet"))
        {
            Debug.Log("Enbullet");
            PlayerBehavior.Instance.TakeDamage(20);
            }
        //if (collision.gameObject.CompareTag("EnBullet"))
        //{
        //    Debug.Log("enbullet");
        //    PlayerBehavior.Instance.TakeDamage(10);
        //}
    }
}
