using System.Linq;
using UnityEngine;

public class Product : MonoBehaviour
{
    [SerializeReference] public byte ProductId;
    public Transform ProductParent { get; set; }
    public byte Id
    {
        get
        {
            return ProductId;
        }
    }
    public int Price
    {
        get
        {
            return AllGoods[Id].Price;
        }
    }
    public string RuName
    {
        get
        {
            return AllGoods[Id].RuName;
        }
    }
    public string EnName
    {
        get
        {
            return AllGoods[Id].EnName;
        }
    }
    public int Penalty
    {
        get
        {
            return AllGoods[Id].Penalty;
        }
    }
    public bool Legal
    {
        get
        {
            return AllGoods[Id].Legal;
        }
    }
    public Transform Prefab
    {
        get
        {
            return this.transform;
        }
    }
    public static ProductDictionary[] AllGoods = new ProductDictionary[]
    {
        new ProductDictionary("Салат","Salat", 4, 2, true),
        new ProductDictionary("Руда","Ore", 4, 2, true),
        new ProductDictionary("Морковь","Carrot", 4, 2, true),
        new ProductDictionary("Хлеб","Bread", 5, 2, true),
        new ProductDictionary("Метал","Metal", 5, 2, true),
        new ProductDictionary("Мясо","Meat", 5, 2, true),
        new ProductDictionary("Грибы","Mashrooms", 6, 2, true),
        new ProductDictionary("Книги","Books", 6, 2, true),
        new ProductDictionary("Красный порошок","RedDust", 7, 4, false),
        new ProductDictionary("Бомбы","Bombs", 7, 4, false),
        new ProductDictionary("Рубины","Rubins", 8, 4, false),
        new ProductDictionary("Кости","Bones", 8, 4, false),
        new ProductDictionary("Оружие","Weapon", 9, 5, false),
        new ProductDictionary("Части тел","BodyParts", 10, 6, false),
        new ProductDictionary("Яд","Poison", 11, 6, false),
        new ProductDictionary("Рабы","Slaves", 12, 7, false),
    };
    void OnMouseDown()
    {
        var player = Game.GetCurrentPlayer();
        var ParentConteiner = this.transform.parent;
        if (ParentConteiner == ProductParent)
        {
            var caravanCell = player.Caravan.GetEmptyCell();

            var GoodsCount = ParentConteiner.transform.childCount;
            if (GoodsCount > 1 && caravanCell != null)
            {
                var Good = ParentConteiner.transform.GetChild(GoodsCount - 1);
                Good.SetParent(caravanCell.transform);
                Good.SetPositionAndRotation(caravanCell.transform.position, Quaternion.identity);
                player.caravanGoods.Add(Good.GetComponent<Product>().Id);
            }
        }
        else if (player.Caravan.ConteinsProduct(ParentConteiner))
        {
            transform.SetPositionAndRotation(ProductParent.position + new Vector3((ProductParent.childCount - 1) * 0.2f, 0, 0), Quaternion.identity);
            transform.SetParent(ProductParent);
            var SRenderer = transform.GetComponent<SpriteRenderer>();
            SRenderer.sortingOrder = SRenderer.sortingOrder + 2 - ProductParent.childCount;
            int cellId = int.Parse(ParentConteiner.name[ParentConteiner.name.Length - 1].ToString());
            player.caravanGoods.Remove(this.Id);
        }
        foreach(var t in player.caravanGoods)
        {
            Debug.Log(t);
        }
    }

}
public class ProductDictionary
{
    public string RuName { get; }
    public string EnName { get; }
    public int Price { get; set; }
    public int Penalty { get; }
    public bool Legal { get; }
    public ProductDictionary(string ruName, string enName, int price, int penalty, bool legal)
    {
        RuName = ruName;
        EnName = enName;
        Price = price;
        Penalty = penalty;
        Legal = legal;
    }
}