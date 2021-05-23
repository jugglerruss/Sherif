using UnityEngine;
using UnityEngine.UI;

public class OnSliderChange : MonoBehaviour
{
    public void ChangeGoldRange(float value) => this.GetComponent<Text>().text = value.ToString();
}
