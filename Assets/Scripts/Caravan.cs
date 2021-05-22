using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Caravan : MonoBehaviour
{
    [SerializeReference] private Transform[] _toCaravanCells;
    [SerializeField] private Slider _slider;
    [SerializeReference] private Text _textMaxVzyatky;

    private int[] products = new int[5]; 
    public void CaravanGoClick()
    {
        if (!Game.GetCurrentPlayer().caravanIsGo)
        {
            Game.GetCurrentPlayer().caravanIsGo = true;
            products = Game.GetCurrentPlayer().caravanGoods.ToArray();
            Game.GetCurrentPlayer().caravanGoods = new List<int> { };
            foreach (int goodIndex in products)
            {                 
               Game.GetCurrentPlayer().HavingGoodsIds.Remove(goodIndex);                
            }
            _slider.maxValue = Game.GetCurrentPlayer().Gold;
            _textMaxVzyatky.text = Game.GetCurrentPlayer().Gold.ToString();
        }
        Debug.Log(products.ToString());
        Game.GetCurrentPlayer().RefreshPlayerInfo();
    }
    public Transform GetEmptyCell(){
        var i = -1;
        foreach (Transform cell in _toCaravanCells)
        {
            i++;
            if (cell.transform.childCount == 0)
            {
                return cell;
            }
        }
        return null;
    }
    public bool ConteinsProduct(Transform prod)
    {
        return _toCaravanCells.Contains(prod);
    }
}
