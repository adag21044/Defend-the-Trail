using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TowerData SelectedTowerData; // Seçili kule verisi
    public int PlayerHealth = 3; // Oyuncunun başlangıç sağlığı

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Kule seçimi
    public void SelectTower(TowerData towerData)
    {
        SelectedTowerData = towerData;
        Debug.Log("Tower Selected: " + towerData.TowerName);
    }

    // Düşman hedefe ulaştığında çağrılan metod
    public void EnemyReachedGoal()
    {
        PlayerHealth--;

        Debug.Log("Enemy reached the goal! Remaining Health: " + PlayerHealth);

        if (PlayerHealth <= 0)
        {
            EndGame();
        }
    }

    // Oyunu bitirme işlemi
    private void EndGame()
    {
        Debug.Log("Game Over! You have lost all your health.");
        // Oyun bitiş ekranı veya başka bir işlem eklenebilir
    }
}
