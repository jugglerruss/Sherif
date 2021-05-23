using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customs : MonoBehaviour
{

    [SerializeReference] private Transform[] _customsCells;
    [SerializeField] private Slider _slider;
    [SerializeReference] private Text _textMaxVzyatky;

    private List<Product> productsInCaravan = new List<Product>();
    public void OpenCustomHouse(int gold, List<Product> products)
    {
        _slider.maxValue = gold;
        _textMaxVzyatky.text = gold.ToString();
        gameObject.SetActive(true);
        productsInCaravan = products;
        var i = 0;
        foreach(Product product in productsInCaravan)
        {
            MoveProductInCell(product.transform,i);
            i++;
        }
    }
    private void MoveProductInCell(Transform product, int i)
    {
        product.SetParent(_customsCells[i]);
        product.SetPositionAndRotation(_customsCells[i].position, Quaternion.identity);
    }
}
