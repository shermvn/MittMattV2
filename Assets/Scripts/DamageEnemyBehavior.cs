using UnityEngine;

public class DamageEnemyBehavior : MonoBehaviour
{
    [SerializeField] public int Damage = 20;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("bullet");
            EnemyBehavior.Instance.TakeDamage(Damage);

            //            EnemyBehavior.Instance.TakeDamage(Damage);
            //    EnemyBehavior enemyBehavior = collision.gameObject.GetComponent<EnemyBehavior>();
            //    if (enemyBehavior = true)
            //    {
            //        Debug.Log("damage");
            //        enemyBehavior.TakeDamage(Damage);
            //    }
            //}
            //if (collision.gameObject.CompareTag("EnBullet"))
            //{
            //    Debug.Log("enbullet");
            //    PlayerBehavior.Instance.TakeDamage(10);
            //}
        }
    }
}
//using UnityEngine;

//public class DamageEnemyBehavior : MonoBehaviour
//{
//    public static DamageEnemyBehavior Instance;
//    [SerializeField] public int Damage = 20;

//    private void Awake()
//    {


//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("Bullet"))
//        {
//            Debug.Log("bullet");
//            EnemyBehavior.Instance.TakeDamage(Damage);
//        }
//        //if (collision.gameObject.CompareTag("EnBullet"))
//        //{
//        //    Debug.Log("enbullet");
//        //    PlayerBehavior.Instance.TakeDamage(10);
//        //}
//    }
//}

