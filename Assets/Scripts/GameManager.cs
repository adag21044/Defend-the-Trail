using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TowerData SelectedTowerData; // Seçili kule verisi
    

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

    public void ClearSelection()
    {
        SelectedTowerData = null;
        Debug.Log("Tower Selection Cleared");
    }

    public void EnemyReachedGoal()
    {
        Debug.Log("Enemy Reached Goal!");
    }
}
