using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 3f;
    [SerializeField] private Transform[] waypoints;
    private int waypointIndex = 0;

    public void Initialize(Transform[] path)
    {
        waypoints = path;
        transform.position = waypoints[0].position; // İlk noktadan başla
    }

    private void Update()
    {
        if (waypoints == null || waypointIndex >= waypoints.Length) return;

        // Hedefe doğru hareket et
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, Speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < 0.1f)
        {
            waypointIndex++;
            if (waypointIndex >= waypoints.Length)
            {
                OnReachGoal();
            }
        }
    }

    private void OnReachGoal()
    {
        GameManager.Instance.EnemyReachedGoal();
        Destroy(gameObject);
    }
}
