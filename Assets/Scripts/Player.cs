using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    public bool caravanIsGo { get; set; }
    public int Gold { get; set; }
    public string NicName { get; }
    public GameObject Castle { get;}
    public int CastleLvl { get; set; }
    public int CriminalLvl { get; set; }
    public List<Goods> Goods { get; set; } = new List<Goods>();
    public List<Goods> Caravan { get; set; }  = new List<Goods>();
    public int[] caravanGoods { get; set; } = new int[5];
    public bool isSherif { get; set; }

public Player(string nicname,GameObject castle)
    {
        NicName = nicname;
        Gold = 50;
        CastleLvl = 1;
        CriminalLvl = 0;
        caravanIsGo = false;
        isSherif = false;
        for(var i = 1; i <9; i++)
        {
            Goods.Add(new Goods(Random.Range(1, 9)));
            Goods.Add(new Goods(Random.Range(11, 19)));

        }
        Castle = castle;
        Castle.tag = "ActiveCastle";
    }
}
