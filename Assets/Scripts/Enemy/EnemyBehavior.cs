using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum preferredTarget
{
    Player,
    Turret,
    Base,
};

public class EnemyBehavior : Entity
{
    private NavMeshAgent agent;

    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float chasingRange;

    public LayerMask whatIsGround, whatIsPlayer;

    // patrolling
    [SerializeField]
    private Vector3 walkPoint;
    private bool walkingPointSelected;

    // attacking
    [SerializeField]
    private float timeBetweenAttacks;
    private bool alreadyAttacked;

    // states
    [SerializeField]
    private float sightRange, attackRange;
    [SerializeField]
    private bool targetInSightRange, targetInAttackRange;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        targetInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        targetInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!targetInSightRange && !targetInAttackRange) Patrolling();
        if (targetInSightRange && !targetInAttackRange) ChasingTarget();
        if (targetInSightRange && targetInAttackRange) AttackingTarget();
    }

    private void Patrolling()
    {

    }

    private void ChasingTarget()
    {

    }

    private void AttackingTarget()
    {

    }

    // PSEUDOCODE:
    // 3 states: patrolling, chasing, attacking
    // patrolling: walks around randomly with your navmesh agent brain,
    // choose a target to walk to at random, move over there,
    // if your preferred target ends up in your "sight" range (set elsewhere) and you're not in range, start chasing
    // if your preferred target is in your sight range and in your attack range, go to attacking state
    // chasing: run towards your preferred target until you reach your attack range,
    // if target leaves your chase/sight range, go back to patrolling
    // attacking: invoke your attack event when your preferred target is in range,
    // if target leaves your attack range, go back to chasing

    // unit targeting pseudocode:
    // if (preferred unit type = within range && int rnd (Random.Range(0,100) <= 70)
    //      attack preferred unit type (closest to you?)
    // else if (preferred unit type != within range && rnd (Random.Range(0,100) > 90)
    //      do something
    // else
    //      attack closest enemy to you, despite its type not matching your preferred one
}
