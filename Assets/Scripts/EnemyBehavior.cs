using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private HealthBarBehavior _healthbar;
    private float _currentHealth;
    private float maxHealth = 100;

    public NavMeshAgent agent;

    private Transform player;



    public GameObject projectile;


    public static EnemyBehavior Instance;


    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;


    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        // Singleton pattern

        //if (Instance != null && Instance != this)
        //{
        //    Destroy(this);
        //}
        //else
        //{
        //    Instance = this;
        //}

    }
    private void Start()
    {
        _currentHealth = maxHealth;
        _healthbar.updateHealthBar(maxHealth, _currentHealth);

    }

    private void Update()
    {
        //Check for sight and attcak range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
        Vector3 distancetoWalkPoint = transform.position - walkPoint;
        //WalkPoint reached

        if (distancetoWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }

    }

    private void SearchWalkPoint()
    {
        //calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }

    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        //make sure enemy doesnt move
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //Attack code
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            AudioManager.Instance.PlaySound(AudioManager.Instance.EnShootHit, 0.2f);
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 1f, ForceMode.Impulse);




            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);

        }

    }
    private void ResetAttack()
    {
        alreadyAttacked = false;

    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        //Debug.Log(_currentHealth);
        _healthbar.updateHealthBar(maxHealth, _currentHealth);


        if (_currentHealth <= 0)
        {
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);

    }





}