using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float detectionRange = 10f;
    public float verticalDetectionRange = 5f;
    public float fieldOfViewAngle = 90f;
    private Transform player;
    public EnemyController enemyController;

    private Vector3 lastKnownPosition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Vector3 horizontalPlayerPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        float horizontalDistanceToPlayer = Vector3.Distance(transform.position, horizontalPlayerPosition);
        
        float verticalDistanceToPlayer = Mathf.Abs(player.position.y - transform.position.y);

        if (horizontalDistanceToPlayer <= detectionRange && verticalDistanceToPlayer <= verticalDetectionRange)
        {
            if (PlayerInFieldOfView(horizontalDistanceToPlayer, verticalDistanceToPlayer))
            {
                Debug.Log("Player Found");
                lastKnownPosition = player.position;
                enemyController.SetTarget(lastKnownPosition);
            }
        }
    }

    private bool PlayerInFieldOfView(float horizontalDistance, float verticalDistance)
    {
        Vector3 directionToPlayer = player.position - transform.position;
        Vector3 horizontalDirection = new Vector3(directionToPlayer.x, 0, directionToPlayer.z);
        float horizontalAngle = Vector3.Angle(horizontalDirection, transform.forward);

        bool isWithinHorizontalFOV = horizontalAngle < fieldOfViewAngle / 2f;

        bool isWithinVerticalFOV = Mathf.Abs(directionToPlayer.y) <= verticalDetectionRange;

        if (isWithinHorizontalFOV && isWithinVerticalFOV)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToPlayer, out hit, detectionRange))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    return true;
                }
            }
        }

        return false;
    }

    // Visualize the detection range and FOV in the scene view for debugging
    private void OnDrawGizmos()
    {
        // Detection range sphere
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // Draw FOV cone for horizontal detection
        Gizmos.color = Color.yellow;
        Vector3 forward = transform.forward * detectionRange;
        Gizmos.DrawLine(transform.position, transform.position + forward);

        // Draw left & right cone lines for FOV
        float halfAngle = fieldOfViewAngle / 2f;
        Quaternion leftRotation = Quaternion.Euler(0, -halfAngle, 0);
        Quaternion rightRotation = Quaternion.Euler(0, halfAngle, 0);
        Gizmos.DrawLine(transform.position, transform.position + leftRotation * forward);
        Gizmos.DrawLine(transform.position, transform.position + rightRotation * forward);
    }
}
