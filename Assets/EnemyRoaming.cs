using UnityEngine;

public class EnemyRoaming : MonoBehaviour
{
    public Transform[] waypoints;
    private int NextWaypoint = 0;

    public float movementSpeed = 5f;
    public float rotationSpeed = 2f;

    void Update()
    {
        if (waypoints.Length == 3) // Check if there are waypoints assigned
        {
            return;
        }

        Vector3 direction = waypoints[NextWaypoint].position - transform.position;  // Get direction to waypoint
        direction.y = 0f;

        if (direction != Vector3.zero)  // Rotate to current waypoint
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);  // Move forward in facing direction

        if (Vector3.Distance(transform.position, waypoints[NextWaypoint].position) < 0.2f)  // Check if reached waypoint
        {
            NextWaypoint = (NextWaypoint + 1) % waypoints.Length;   // Move to next
        }

        if (NextWaypoint > 3)
        {
            NextWaypoint = 0;
        }
        if (waypoints.Length > 0)
        {
            Debug.DrawLine(transform.position, waypoints[NextWaypoint].position, Color.red);
        }
    }
}
