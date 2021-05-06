using UnityEngine;

public class toCaravanClick : MonoBehaviour
{
    private GameObject caravanCell;
    void OnMouseDown()
    {
        caravanCell = null;
        var caravanCells = GameObject.FindGameObjectsWithTag("caravanCell");
        foreach(GameObject cell in caravanCells)
        {
            if (cell.transform.childCount == 0)
            { 
                caravanCell = cell;
                break;
            }
        }
        var ParentGood = transform.parent.parent.gameObject;
        var GoodsCount = ParentGood.transform.childCount;
        if (GoodsCount > 1 && caravanCell != null)
        {
            var Good = ParentGood.transform.GetChild(GoodsCount - 1);
            Good.SetParent(caravanCell.transform);
            Good.SetPositionAndRotation(caravanCell.transform.position, Quaternion.identity);
        }
        

    }
}
