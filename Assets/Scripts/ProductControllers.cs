using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ProductControllers : MonoBehaviour
{
    [SerializeReference] private Transform[] _productsControllers;

    public static Transform[] ProductsControllers { get; private set; }


    private void Awake()
    {
        ProductsControllers = _productsControllers;
        foreach (Transform controller in ProductsControllers)
        {
            controller.GetComponent<ProductController>().OnGameStartFillTextLables();
        }
    }
    public static void ClearProducts()
    {
        foreach (Transform controller in ProductsControllers)
        {
            int i = 0;
            Transform[] allChildren = new Transform[controller.transform.childCount];
            foreach (Transform child in controller)
            {
                if (child.tag == "productItem")
                {
                    allChildren[i] = child;
                    i += 1;
                }
            }
            foreach (Transform child in allChildren)
            {
                if (child != null)
                {
                    child.SetParent(controller.GetChild(0));
                    child.transform.position = new Vector3(20000f, 0, 0);
                }
            }
        }
    }
}
