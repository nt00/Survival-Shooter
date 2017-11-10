using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public float health = 50f;
    private Transform target;
    [SerializeField]
    private float movementSpeed;
    private NavMeshAgent agent;

    private void Awake()
    {
        //Randomises enemy movement speeds within limits
        movementSpeed = Random.Range(2f, 4f);
    }
    void Start()
    {
        //Get reference to NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Seek();
        // If an enemy falls off the platform, they will die
        if (transform.position.y < -2)
        {
            EnemyDeath();
        }
    }

    void Seek()
    {
        //Finds gameobject with the tag "Player" as the enemies target
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //Sets the enemies destination as player
        agent.SetDestination(target.position);
        agent.speed = movementSpeed;
    }

    public void GunDamage(float amount)
    {
        //Removing the amount of damage the enemy takes from its health
        health -= amount;
        //If the enemy's health reaches 0, it will die
        if (health <= 0f)
        {
            EnemyDeath();
        }
    }

    void EnemyDeath()
    {
        Destroy(gameObject);
    }
}
