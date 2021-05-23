using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Text _playerNameRightPanelText;
    [SerializeField] private Text _playerNameUnderCastleText;
    [SerializeField] private Text _playerGoldText;
    [SerializeField] private Transform _playerCastle;
    [SerializeField] private Caravan _playerCaravan;
    private List<int> havingGoodsIds { get; set; } = new List<int>();
    public bool caravanIsGo { get; set; }
    public int Gold { get; set; }
    public string NicName { get; set; }
    public int CastleLvl { get; set; }
    public int CriminalLvl { get; set; }
    public List<Product> HaveProducts { get; set; } = new List<Product>();
    public Caravan Caravan { get; set; }
    public List<Product> caravanGoods { get; set; } = new List<Product>();
    public bool isSherif { get; set; }
    private int exchangeCount;
    private int maxExchangeCount { get; set; }
    public void Awake()
    {
        Caravan = _playerCaravan;
    }
    public void DoExchange(ProductController productController)
    {
        if (exchangeCount + 1 <= maxExchangeCount)
        {
            exchangeCount += 1;
            productController.OnExchancgeClick();
        }
        else
        {
            Debug.Log("Количество обменов исчерпано");
        }
    }

    public void ActivatePlayer()
    {
        this.gameObject.SetActive(true);
        NicName = this.name;
        Gold = 50;
        CastleLvl = 1;
        CriminalLvl = 0;
        caravanIsGo = false;
        isSherif = false;
        exchangeCount = 0;
        maxExchangeCount = 5;
        for (var i = 1; i < 9; i++)
        {
            havingGoodsIds.Add(Random.Range(0, 8));
            havingGoodsIds.Add(Random.Range(8, 16));
        }
        _playerNameUnderCastleText.text = NicName;
        foreach (Transform productsController in ProductControllers.ProductsControllers)
        {
            foreach (int goodId in havingGoodsIds)
            {
                HaveProducts.Add(productsController.GetComponent<ProductController>().CreateProducts(goodId));
            }
        }
    }
    void OnMouseDown()
    {
        PlayerController.SetCurrentPlayer(this);
        RefreshPlayerInfo();
    }
    public void RefreshPlayerInfo()
    {
        _playerNameRightPanelText.text = NicName;
        _playerGoldText.text = Gold.ToString();
        //ClearChildren(ProductControllers.ProductsControllers);
        ProductControllers.ClearProducts();
        foreach (Transform productsController in ProductControllers.ProductsControllers)
        {
            foreach (Product product in HaveProducts)
            {
                if (product!=null) productsController.GetComponent<ProductController>().ShowProducts(product);
            }
        }
    }
    private static void ClearChildren(Transform[] productsP)
    {

        var caravanCells = GameObject.FindGameObjectsWithTag("caravanCell");
        foreach (GameObject cell in caravanCells)
        {
            if (cell.transform.childCount > 0)
            {
                int j = 0;
                GameObject[] allChildren = new GameObject[cell.transform.childCount];
                foreach (Transform child in cell.transform)
                {
                    allChildren[j] = child.gameObject;
                    j += 1;
                }
                foreach (GameObject child in allChildren)
                {
                    if (child != null)
                        DestroyImmediate(child.gameObject);
                }

            }
        }

    }
}
