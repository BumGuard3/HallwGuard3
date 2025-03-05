using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask isGround, isPlayer;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange = 25f;
    public float sightRange = 12f;
    public bool inSightRange;
    
    public float normalSpeed = 3.5f;
    public float increasedSpeed = 10f;

    private Vector3 lastKnownPosition;
    private bool isChasing = false;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        inSightRange = Physics.CheckSphere(transform.position, sightRange, isPlayer);

        if (!inSightRange)
        {
            if (!isChasing)
            {
                Patrolling();
            }
        }

        if (inSightRange)
        {
            Chase();
        }

        if (isChasing)
        {
            
            agent.SetDestination(lastKnownPosition);

            if (Vector3.Distance(transform.position, lastKnownPosition) < 1f)
            {
                isChasing = false;
                agent.speed = normalSpeed;
                PatrollingFromLastKnownPosition();
            }
            
        }
    }

    public void SetTarget(Vector3 targetPosition)
    {
        lastKnownPosition = targetPosition;
        isChasing = true;
        agent.speed = increasedSpeed;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, isGround) && IsWalkPointReachable(walkPoint))
        {
            walkPointSet = true;
        }
        else
        {
            walkPointSet = false;
        }
    }

    private bool IsWalkPointReachable(Vector3 targetPoint)
    {
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(targetPoint, path);
        
        return path.status == NavMeshPathStatus.PathComplete;
    }

    private void Patrolling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void PatrollingFromLastKnownPosition()
    {
        walkPoint = lastKnownPosition;
        walkPointSet = true;
        agent.SetDestination(walkPoint);
    }

    private void Chase()
    {
        agent.SetDestination(player.position);
    }
}