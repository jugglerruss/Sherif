using UnityEngine;
using UnityEngine.UI;

public class CastleClick : MonoBehaviour
{
    public byte PlayerIndex;

    void OnMouseDown()
    {
        Game.CurrentPlayer = Game.allPlayers[PlayerIndex];
        Game.RefreshPlayerInfo();
    }
    
}
