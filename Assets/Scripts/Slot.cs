using UnityEngine;

public class Slot : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Eğer bir kule seçili ve slot boşsa kule yerleştir
        if (GameManager.Instance.SelectedTowerData != null && transform.childCount == 0)
        {
            TowerData selectedTower = GameManager.Instance.SelectedTowerData;
            GameObject tower = Instantiate(selectedTower.TowerPrefab, transform.position, Quaternion.identity);
            tower.GetComponent<Tower>().Initialize(selectedTower); // Verileri ile kuleyi başlat
            tower.transform.SetParent(transform); // Slot'un altında olmasını sağlar
            GameManager.Instance.SelectTower(null); // Kule seçimini sıfırla
        }
    }
}
