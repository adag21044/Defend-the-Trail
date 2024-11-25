using UnityEngine;
using UnityEngine.EventSystems;

public class TowerSelectionUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public TowerData TowerData;
    public GameObject draggingTowerIcon;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(TowerData == null) return;

        draggingTowerIcon = Instantiate(TowerData.TowerPrefab, transform.position, Quaternion.identity);
        draggingTowerIcon.GetComponent<Collider>().enabled = false;
        draggingTowerIcon.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(draggingTowerIcon == null) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Tower")))
        {
            draggingTowerIcon.transform.position = hit.point;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(draggingTowerIcon == null) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.CompareTag("Ground"))
        {
            // Kuleyi doğru bir şekilde yerleştir
            Instantiate(TowerData.TowerPrefab, hit.point, Quaternion.identity);
            Debug.Log("Tower Placed!");
        }
        else
        {
            // Geçerli bir yere bırakılmadıysa objeyi yok et
            Debug.Log("Invalid placement!");
            Destroy(draggingTowerIcon);
        }

        draggingTowerIcon = null; 
    }
}