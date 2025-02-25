using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public float detectionRange = 10f;
    public float fieldOfViewAngle = 90f;
    public Transform player;
    public EnemyController enemyController;

    private Vector3 lastKnownPosition;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            if (PlayerInFieldOfView())
            {
                lastKnownPosition = player.position;
                enemyController.SetTarget(lastKnownPosition);
            }
        }
    }

    private bool PlayerInFieldOfView()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float angle = Vector3.Angle(directionToPlayer, transform.forward);
        
        return angle < fieldOfViewAngle / 2f;
    }

    // Visualize The Detection
    // Delete after 3D model with cone
    private void OnDrawGizmos()
    {
        // Sphere
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // Middle Cone Line
        Gizmos.color = Color.yellow;
        Vector3 forward = transform.forward * detectionRange;
        Gizmos.DrawLine(transform.position, transform.position + forward);

        // Left & Right Cone Line
        float halfAngle = fieldOfViewAngle / 2f;
        Quaternion leftRotation = Quaternion.Euler(0, -halfAngle, 0);
        Quaternion rightRotation = Quaternion.Euler(0, halfAngle, 0);
        Gizmos.DrawLine(transform.position, transform.position + leftRotation * forward);
        Gizmos.DrawLine(transform.position, transform.position + rightRotation * forward);
    }
}
