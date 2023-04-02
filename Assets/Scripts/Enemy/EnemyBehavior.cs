//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public enum PreferredTargetType
//{
//    Player,
//    Turret,
//    Base,
//};

//public class EnemyBehavior : Entity
//{
//    private NavMeshAgent agent;

//    [SerializeField]
//    private float chasingRange;

//    public LayerMask groundLayer, playerLayer, turretLayer, baseLayer;

//    // patrolling
//    [SerializeField]
//    private Vector3 walkPoint;
//    private bool walkingPointSelected;
//    public float walkPointRange;

//    // attacking
//    [SerializeField]
//    private float timeBetweenAttacks;
//    private bool alreadyAttacked;

//    // states
//    [SerializeField]
//    private float sightRange, attackRange;
//    [SerializeField]
//    private bool preferredTargetInSightRange, preferredTargetInAttackRange;

//    public PreferredTargetType PreferredTarget;

//    Collider[] targetsInSightRange;
//    Collider[] targetsInAttackRange;

//    Collider target;

//    private void Awake()
//    {
//        agent = GetComponent<NavMeshAgent>();
//    }

//    private void Update()
//    {
//        if (PreferredTarget == PreferredTargetType.Player)
//        {
//            CheckForTargetInRange(playerLayer);
//        }
//        else if (PreferredTarget == PreferredTargetType.Turret)
//        {
//            CheckForTargetInRange(turretLayer);
//        }
//        else if (PreferredTarget == PreferredTargetType.Base)
//        {
//            CheckForTargetInRange(baseLayer);
//        }

//        if (!preferredTargetInSightRange && !preferredTargetInAttackRange) 
//        {
//            int rnd = Random.Range(0, 100);

//            if (rnd <= 80)
//            {
//                Patrolling();
//            }

//            else if (rnd > 80)
//            {
//                ChasingNearestTarget();
//            }
//        }

//        if (preferredTargetInSightRange && !preferredTargetInAttackRange)
//        {
//            ChasingTarget();
//        }

//        if (preferredTargetInSightRange && preferredTargetInAttackRange)
//        {
//            AttackingTarget();
//        }
//    }
//    private void CheckForTargetInRange(LayerMask preferredTarget)
//    {
//        preferredTargetInSightRange = Physics.CheckSphere(transform.position, sightRange, preferredTarget);
//        preferredTargetInAttackRange = Physics.CheckSphere(transform.position, attackRange, preferredTarget);

//        targetsInSightRange = Physics.OverlapSphere(transform.position, sightRange, preferredTarget);
//        targetsInAttackRange = Physics.OverlapSphere(transform.position, attackRange, preferredTarget);
//    }

//    private void Patrolling()
//    {
//        if (!walkingPointSelected)
//            SearchWalkPoint();
//        else
//            agent.SetDestination(walkPoint);

//        Vector3 distanceToWalkPoint = transform.position - walkPoint;

//        // Walkpoint reached
//        if (distanceToWalkPoint.magnitude < 1f)
//            walkingPointSelected = false;
//    }

//    private void SearchWalkPoint()
//    {
//        // calculcate random point in range
//        float randomZ = Random.Range(-walkPointRange, walkPointRange);
//        float randomX = Random.Range(-walkPointRange, walkPointRange);

//        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

//        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundLayer))
//        {
//            walkingPointSelected = true;
//        }
//    }

//    private void ChasingTarget()
//    {
//        target = targetsInSightRange[0];
//        agent.SetDestination(target.gameObject.transform.position);
//    }

//    // if enemy doesn't find its preferred type and rolls a specific number, it instead just chases the closest target regardless of its layer
//    private void ChasingNearestTarget()
//    {

//    }

//    private void AttackingTarget()
//    {
//        agent.SetDestination(transform.position);

//        transform.LookAt(target.gameObject.transform);
//    }

//    //// if enemy doesn't find its preferred type and rolls a specific number, it instead just attacks the closest target regardless of its layer
//    //private void AttackingNearestTarget()
//    //{

//    //}


//    // PSEUDOCODE:
//    // 3 states: patrolling, chasing, attacking
//    // patrolling: walks around randomly with your navmesh agent brain,
//    // choose a target to walk to at random, move over there,
//    // if your preferred target ends up in your "sight" range (set elsewhere) and you're not in range, start chasing
//    // if your preferred target is in your sight range and in your attack range, go to attacking state
//    // chasing: run towards your preferred target until you reach your attack range,
//    // if target leaves your chase/sight range, go back to patrolling
//    // attacking: invoke your attack event when your preferred target is in range,
//    // if target leaves your attack range, go back to chasing

//    // unit targeting pseudocode:
//    // if (preferred unit type = within range && int rnd (Random.Range(0,100) <= 70)
//    //      attack preferred unit type (closest to you?)
//    // else if (preferred unit type != within range && rnd (Random.Range(0,100) > 90)
//    //      do something
//    // else
//    //      attack closest enemy to you, despite its type not matching your preferred one
//}
