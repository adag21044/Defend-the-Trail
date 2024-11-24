using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed = 10f;
    private Transform target;

    public void Initialize(Transform target)
    {
        this.target = target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // Hedefe doğru hareket et
        transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            OnHitTarget();
        }
    }

    private void OnHitTarget()
    {
        Debug.Log("Target Hit!");
        Destroy(gameObject);
    }
}
