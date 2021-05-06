using UnityEngine;
using UnityEngine.UI;

public class Vzyatka : MonoBehaviour
{
    public Transform TextVzyatky;
    public void giveVzyatka()
    {

    }

    public void ChangeGoldRange(float value)
    {
        var sliderComp = TextVzyatky.GetComponent<Text>();
        sliderComp.text = value.ToString();


    }
 }
