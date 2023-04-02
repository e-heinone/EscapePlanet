using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum PreferredTargetType
{
    Player,
    Turret,
    Base,
};

public class EnemyController : MonoBehaviour
{
    ChooseRandomRayFromSpace rayFromSpace;

    public List<GameObject> targets;

    public PreferredTargetType PreferredTarget;

    private NavMeshAgent agent;

    [SerializeField]
    private float chasingRange;

    // patrolling
    [SerializeField]
    private Vector3 walkPoint;
    private bool walkingPointSelected = false;
    public float walkPointRange;

    // attacking
    [SerializeField]
    private float timeBetweenAttacks;
    private bool alreadyAttacked;

    // states
    [SerializeField]
    private float sightRange, attackRange;
    [SerializeField]
    private bool preferredTargetInSightRange, preferredTargetInAttackRange;

    [SerializeField]
    GameObject temp;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //agent.SetDestination(GameObject.Find("Player").transform.position);

        //if (targets == null && !walkingPointSelected)
        //{
        //    Patrolling();
        //}
    }

    void Patrolling()
    {
        walkingPointSelected = true;
        rayFromSpace.ShootRay();
        agent.SetDestination(rayFromSpace.targetLocation);
    }
}
