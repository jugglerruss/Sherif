using UnityEngine;

public class Goods 
{
 
    public int Id { get; }
    public int Price { get; set; }
    public string RuName { get; }
    public string EnName { get; }
    public int Penalty { get; }
    public bool Legal { get; }
    public Transform Prefab { get; }
    public static Good[] AllGoods = new Good[]
    {
        null,
        new Good("Салат","Salat", 4, 2, true),
        new Good("Руда","Ore", 4, 2, true),
        new Good("Морковь","Carrot", 4, 2, true),
        new Good("Хлеб","Bread", 5, 2, true),
        new Good("Метал","Metal", 5, 2, true),
        new Good("Мясо","Meat", 5, 2, true),
        new Good("Грибы","Mashrooms", 6, 2, true),
        new Good("Книги","Books", 6, 2, true),
        null,
        null,
        new Good("Красный порошок","RedDust", 7, 4, false),
        new Good("Бомбы","Bombs", 7, 4, false),
        new Good("Рубины","Rubins", 8, 4, false),
        new Good("Кости","Bones", 8, 4, false),
        new Good("Оружие","Weapon", 9, 5, false),
        new Good("Части тел","BodyParts", 10, 6, false),
        new Good("Яд","Poison", 11, 6, false),
        new Good("Рабы","Slaves", 12, 7, false),
    };
    public Goods(int id)
    {
        if (id > 0 && id != 9 && id != 10)
        {
            Id = id;
            Prefab = Game.ProductPrefabs[Id];
            RuName = AllGoods[Id].RuName;
            EnName = AllGoods[Id].EnName;
            Price = AllGoods[Id].Price;
            Penalty = AllGoods[Id].Penalty;
            Legal = AllGoods[Id].Legal;
        }
    }
    public class Good
    {
        public string RuName { get; }
        public string EnName { get; }
        public int Price { get; set; }
        public int Penalty { get; }
        public bool Legal { get; }
        public Good(string ruName, string enName, int price, int penalty, bool legal)
        {
            RuName = ruName;
            EnName = enName;
            Price = price;
            Penalty = penalty;
            Legal = legal;
        }
    }
}
