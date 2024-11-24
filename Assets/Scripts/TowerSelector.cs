using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    public TowerData TowerData; // Bu simgeye bağlı kule verisi

    private void OnMouseDown()
    {
        // Simgeye tıklayınca kule seçimi yapılır
        GameManager.Instance.SelectTower(TowerData);
    }
}
