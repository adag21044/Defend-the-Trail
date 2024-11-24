using UnityEngine;

public class Tower : MonoBehaviour
{
    private TowerData towerData;
    private float lastAttackTime;

    public void Initialize(TowerData data)
    {
        towerData = data; // Scriptable Object'ten verileri al
    }

    private void Update()
    {
        if (towerData == null) return;

        // Yakınlardaki düşmanı bul
        Enemy target = FindNearestEnemy();
        if (target != null && Time.time - lastAttackTime > towerData.AttackCooldown)
        {
            Attack(target);
            lastAttackTime = Time.time;
        }
    }

    private Enemy FindNearestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Enemy nearest = null;
        float shortestDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance && distance <= towerData.AttackRange)
            {
                nearest = enemy;
                shortestDistance = distance;
            }
        }
        return nearest;
    }

    private void Attack(Enemy target)
    {
        Debug.Log("Attacking: " + target.name);

        // Mermi oluştur ve hedefe yönlendir
        GameObject projectile = Instantiate(towerData.ProjectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().Initialize(target.transform);
    }
}
