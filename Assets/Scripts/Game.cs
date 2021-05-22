using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeReference] private Player[] _allPlayers;
    [SerializeReference] private int PlayerCountSet;
    private static int _playersCount { get; set; }
    public static Player[] ActivePlayers;
  
    private static Player _currentPlayer;
    public static Player GetCurrentPlayer()
    {
        return _currentPlayer;
    }

    public static void SetCurrentPlayer(Player player)
    {
        _currentPlayer = player;
    }

    public static Player[] GetAllPlayers()
    {
        return ActivePlayers;
    }

    private void Awake()
    {
        _playersCount = PlayerCountSet;
        ActivePlayers = new Player[_playersCount + 1];
    }
    void Start()
    {        
        for (int i = 0; i < _playersCount; i++)
        {
            _allPlayers[i].ActivatePlayer();
            ActivePlayers[i] = _allPlayers[i];
        }
        ActivePlayers[0].isSherif = true;
        var SherifName = GameObject.Find("sherifName").GetComponent<Text>();
        SherifName.text = ActivePlayers[0].NicName;
    }    
  
   

}
