using UnityEngine;

public class ExchangeOnClick : MonoBehaviour
{
    void OnMouseDown()
    {
        PlayerController.GetCurrentPlayer().DoExchange(this.transform.parent.parent.GetComponent<ProductController>());
    }
    
}
