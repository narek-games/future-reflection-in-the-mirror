using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ForTheFutureScript : MonoBehaviour
{
    // ボタン背景の初期色を保存する変数
    Color firstColor;
    // ボタン背景の初期色の補色を保存する変数
    Color complementaryColor;

    // ボタン文字の初期色を保存する変数
    Color firstTextColor;
    // ボタン文字の初期色の補色を保存する変数
    Color complementaryTextColor;


    private void Start()
    {
        // ボタン背景の初期色を取得
        firstColor = this.GetComponent<Image>().color;
        // ボタン背景の初期色の補色を取得
        complementaryColor = new Color(Mathf.Abs(firstColor.r - 1.0f), Mathf.Abs(firstColor.g - 1.0f), Mathf.Abs(firstColor.b - 1.0f));

        // ボタン文字の初期色を取得
        firstTextColor = this.GetComponentInChildren<TextMeshProUGUI>().color;
        // ボタン文字の初期色の補色を取得
        complementaryTextColor = new Color(Mathf.Abs(firstTextColor.r - 1.0f), Mathf.Abs(firstTextColor.g - 1.0f), Mathf.Abs(firstTextColor.b - 1.0f));
    }

    public void OnPushedButton()
    {
        if(GameManager.phase != 2)
        {
            // 移動フェーズに移行
            GameManager.phase = 1;
        }       
    }

    private void Update()
    {
        if (GameManager.worldState == 0)
        {
            this.GetComponent<Image>().color = firstColor;
            this.GetComponentInChildren<TextMeshProUGUI>().color = firstTextColor;
        }
        else if (GameManager.worldState == 1)
        {
            this.GetComponent<Image>().color = complementaryColor;
            this.GetComponentInChildren<TextMeshProUGUI>().color = complementaryTextColor;
        }

        // 一度押したら消える(移動フェーズからは不可逆)
        if (GameManager.phase == 1)
        {
            this.gameObject.SetActive(false);
        }
    }
}
