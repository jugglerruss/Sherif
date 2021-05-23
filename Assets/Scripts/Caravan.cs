using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Caravan : MonoBehaviour
{
    [SerializeReference] private Transform[] _toCaravanCells;
    [SerializeField] private Slider _slider;
    [SerializeField] private Customs _customs;

    public void CaravanGoClick()
    {
        var player = PlayerController.GetCurrentPlayer();
        if (!player.caravanIsGo)
        {
            player.caravanIsGo = true;
            foreach (Product product in player.HaveProducts)
            {
                if (product != null) Debug.Log(product.Id);
            }
            foreach (Product product in player.caravanGoods)
            {
                player.HaveProducts.Remove(product);
            }
            _customs.OpenCustomHouse(player.Gold, player.caravanGoods);
            player.caravanGoods.Clear();
        }
        player.RefreshPlayerInfo();
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
