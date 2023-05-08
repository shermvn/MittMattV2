using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemyBehavior : MonoBehaviour
{
    public static DamageEnemyBehavior Instance;
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
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("bullet");
            EnemyBehavior.Instance.TakeDamage(20);
            }
        //if (collision.gameObject.CompareTag("EnBullet"))
        //{
        //    Debug.Log("enbullet");
        //    PlayerBehavior.Instance.TakeDamage(10);
        //}
    }
}
