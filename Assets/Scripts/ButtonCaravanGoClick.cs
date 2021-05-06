using System.Linq;
using UnityEngine;

public class ButtonCaravanGoClick : MonoBehaviour
{
   
    public void CaravanGoClick()
    {
        if (!Game.CurrentPlayer.caravanIsGo)
        {
            Game.CurrentPlayer.caravanIsGo = true;
            foreach(int goodIndex in Game.CurrentPlayer.caravanGoods)
            {
                if (goodIndex != 0)
                {
                    Game.CurrentPlayer.Caravan.Add(new Goods(goodIndex));
                    var itemsToRemove = Game.CurrentPlayer.Goods.Where(r => r.Id == goodIndex);
                    Debug.Log(Game.CurrentPlayer.Goods.Remove(itemsToRemove.First()));
                }
            }
        }
        foreach (Goods aPart in Game.CurrentPlayer.Caravan)
        {
            Debug.Log(aPart.Id);
        }
    }
}
