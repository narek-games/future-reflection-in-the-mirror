using TMPro;
using UnityEngine;

public class TextColorChanger : MonoBehaviour
{
    // 初期色を保存する変数
    Color firstColor;
    // 初期色の補色を保存する変数
    Color complementaryColor;

    void Start()
    {
        // 自身の初期色を保存
        firstColor = this.GetComponent<TextMeshProUGUI>().color;
        // 初期色の補色を取得
        complementaryColor = new Color(Mathf.Abs(firstColor.r - 1.0f), Mathf.Abs(firstColor.g - 1.0f), Mathf.Abs(firstColor.b - 1.0f));
    }

    void Update()
    {
        if(GameManager.worldState == 0)
        {
            this.GetComponent<TextMeshProUGUI>().color = firstColor;
        }
        else if(GameManager.worldState == 1)
        {
            this.GetComponent<TextMeshProUGUI>().color = complementaryColor;
        }
    }
}
