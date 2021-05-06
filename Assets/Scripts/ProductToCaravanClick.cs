using System;
using UnityEngine;

public class ProductToCaravanClick : MonoBehaviour
{
    public byte productId;
    private GameObject caravanCell;
    void OnMouseDown()
    {
        caravanCell = null;
        var ParentGood = transform.parent.gameObject;
        if (ParentGood.tag == "product")
        {
            var caravanCells = GameObject.FindGameObjectsWithTag("caravanCell");
            var i = -1;
            foreach (GameObject cell in caravanCells)
            {
                i++;
                if (cell.transform.childCount == 0)
                {
                    caravanCell = cell;
                    break;
                }
            }

            var GoodsCount = ParentGood.transform.childCount;
            if (GoodsCount > 1 && caravanCell != null)
            {
                var Good = ParentGood.transform.GetChild(GoodsCount - 1);
                Good.SetParent(caravanCell.transform);
                Good.SetPositionAndRotation(caravanCell.transform.position, Quaternion.identity);


                Game.CurrentPlayer.caravanGoods[i] = productId;
            }
        }
        else
        {
            var productParent = GameObject.Find("product" + productId.ToString()).transform;
            transform.SetPositionAndRotation(productParent.position + new Vector3((productParent.childCount - 1) * 0.2f, 0, 0), Quaternion.identity);
            transform.SetParent(productParent);
            var SRenderer = transform.GetComponent<SpriteRenderer>();
            SRenderer.sortingOrder = SRenderer.sortingOrder + 2 - productParent.childCount;
            int cellId = Int32.Parse(ParentGood.name[ParentGood.name.Length - 1].ToString());
            Game.CurrentPlayer.caravanGoods[cellId - 1] = 0;

        }

    }
}
