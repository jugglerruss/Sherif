using UnityEngine;

public class ExchangeOnClick : MonoBehaviour
{
    void OnMouseDown()
    {
        Game.GetCurrentPlayer().DoExchange(this.transform.parent.parent.GetComponent<ProductController>());
    }
    
}
