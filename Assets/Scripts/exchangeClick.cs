using System.Linq;
using UnityEngine;

public class exchangeClick : MonoBehaviour
{
    public byte productId;
    void OnMouseDown()
    {
        var ParentGood = transform.parent.gameObject;
        var GoodsCount = ParentGood.transform.childCount;
        if (GoodsCount > 1 && productId!=1 && productId!=11)
        {
            var itemsToRemove = Game.CurrentPlayer.Goods.Where(r => r.Id == productId);
            if (itemsToRemove.Count() > 0)
            {
                Game.CurrentPlayer.Goods.Remove(itemsToRemove.First());

                var RandomNum = Random.Range(1, productId);
                if (RandomNum == 9 || RandomNum == 10)
                    RandomNum = Random.Range(productId, 18);
                Game.CurrentPlayer.Goods.Add(new Goods(RandomNum));

                Game.RefreshPlayerInfo();
            }            

        }

    }

}
