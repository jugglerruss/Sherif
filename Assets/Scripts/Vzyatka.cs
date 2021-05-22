using UnityEngine;
using UnityEngine.UI;

public class Vzyatka : MonoBehaviour
{
    [SerializeReference] private Text TextVzyatky;

    public void ChangeGoldRange(float value)
    {
        TextVzyatky.text = value.ToString();

    }
 }
