using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ProductController : MonoBehaviour
{
    [SerializeField] private byte _productId;
    [SerializeField] private Transform _productPrefub;
    [SerializeField] private Text _productPrice;
    [SerializeField] private Text _productPenalty;
    
    public void OnGameStartFillTextLables()
    {
        var good = Product.AllGoods[_productId];
        _productPrice.text = good.Price.ToString();
        _productPenalty.text = good.Penalty.ToString();
    }
    public void CreateProducts(int goodId)
    {
        if(goodId == _productId)
        {
            var productItem = Instantiate(_productPrefub, this.transform.position + new Vector3((this.transform.childCount - 1) * 0.2f, 0, 0), Quaternion.identity);
            productItem.SetParent(this.transform);
            productItem.GetComponent<Product>().ProductParent = this.transform;
            var SRenderer = productItem.GetComponent<SpriteRenderer>();
            SRenderer.sortingOrder = SRenderer.sortingOrder + 2 - this.transform.childCount;
        }        
    }
    public void OnExchancgeClick()
    {
        var GoodsCount = this.transform.childCount;
        if (GoodsCount > 1 && _productId != 0)
        {
            var itemsToRemove = Game.GetCurrentPlayer().HavingGoodsIds.Where(Id => Id == _productId);
            if (itemsToRemove.Count() > 0)
            {
                Game.GetCurrentPlayer().HavingGoodsIds.Remove(itemsToRemove.First());
                var RandomNum = Random.Range(0, _productId-1);
                Game.GetCurrentPlayer().HavingGoodsIds.Add(RandomNum);
                Game.GetCurrentPlayer().RefreshPlayerInfo();
            }
        }
    }
}
