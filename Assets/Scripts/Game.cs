using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeReference] private static int PlayerCount;
    [SerializeReference] public static Transform[] ProductPrefabs;
    public static Player CurrentPlayer  {get; set;}
    public static Player[] allPlayers;

    public Transform[] ProductPrefabsSet;
    public int PlayerCountSet;
    void Start()
    {
        PlayerCount = PlayerCountSet;
        allPlayers = new Player[PlayerCount + 1];
        ProductPrefabs = ProductPrefabsSet;

        for (var i = 1; i < 19; i++)
        {
            if (i != 9 && i != 10)
            {
                var good = new Goods(i);
                var prod = GameObject.Find("product" + good.Id.ToString()).transform;
                var productPrice = prod.transform.Find("CanvasProduct/price");
                productPrice.GetComponent<Text>().text = good.Price.ToString();
                var Penalty = prod.transform.Find("CanvasProduct/penalty");
                Penalty.GetComponent<Text>().text = good.Penalty.ToString();
            }
        }
        for (byte i = 1; i <= PlayerCount; i++)
        {
            Player player = new Player("Player" + i.ToString(),GameObject.Find("castle"+i.ToString()));
            allPlayers[i] = player;
            var PlayerName = GameObject.Find("PlayerName" + i).GetComponent<Text>();
            PlayerName.text = player.NicName;
        }
        allPlayers[allPlayers.Length-1].isSherif = true;
        var SherifName = GameObject.Find("sherifName").GetComponent<Text>();
        SherifName.text = allPlayers[allPlayers.Length - 1].NicName;

        var castles = GameObject.FindGameObjectsWithTag("castle");
        foreach (GameObject castle in castles)
        {
            castle.SetActive(false);
        }

    }    
    public static void RefreshPlayerInfo()
    {
        var PlayerName = GameObject.Find("PlayerName").GetComponent<Text>();
        PlayerName.text = Game.CurrentPlayer.NicName;

        var Gold = GameObject.Find("Gold").GetComponent<Text>();
        Gold.text = Game.CurrentPlayer.Gold.ToString();

        var GoodsPlayer = Game.CurrentPlayer.Goods;
        var productsParent = GameObject.FindGameObjectsWithTag("product");
        ClearChildren(productsParent);
        foreach (Goods good in GoodsPlayer)
        {
            var productParent = GameObject.Find("product" + good.Id.ToString()).transform;
            var productItem = Instantiate(Game.ProductPrefabs[good.Id], productParent.transform.position + new Vector3((productParent.childCount - 1) * 0.2f, 0, 0), Quaternion.identity);
            productItem.SetParent(productParent);
            var SRenderer = productItem.GetComponent<SpriteRenderer>();
            SRenderer.sortingOrder = SRenderer.sortingOrder + 2 - productParent.childCount;
        }

    }
    private static void ClearChildren(GameObject[] productsP)
    {
        foreach (GameObject prod in productsP)
        {

            int i = 0;

            //Array to hold all child obj
            GameObject[] allChildren = new GameObject[prod.transform.childCount];

            //Find all child obj and store to that array
            foreach (Transform child in prod.transform)
            {
                if (child.tag == "productItem")
                {
                    allChildren[i] = child.gameObject;
                    i += 1;
                }
            }

            //Now destroy them
            foreach (GameObject child in allChildren)
            {
                if (child != null)
                    DestroyImmediate(child.gameObject);
            }
        }

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
