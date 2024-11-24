using UnityEngine;

[CreateAssetMenu(fileName = "New Tower", menuName = "Tower Defense/Tower Data")]
public class TowerData : ScriptableObject
{
    public string TowerName; // Kule ismi
    public GameObject TowerPrefab; // Prefab referansı
    public float AttackRange = 5f; // Saldırı menzili
    public float AttackCooldown = 1f; // Mermi atım süresi
    public GameObject ProjectilePrefab; // Mermi prefab'ı
}
