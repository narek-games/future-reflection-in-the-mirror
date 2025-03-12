using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryScript : MonoBehaviour
{
    /*
        ボタン背景の反転が今の記述の仕方では未完
     */

    // ボタン背景の初期色を保存する変数
    Color firstColor;
    // ボタン背景の初期色の補色を保存する変数
    Color complementaryColor;

    // ボタン文字の初期色を保存する変数
    Color firstTextColor;
    // ボタン文字の初期色の補色を保存する変数
    Color complementaryTextColor;

    public int stageStartWorld;
    private void Start()
    {
        // ステージ開始時点のworldStateを保存
        stageStartWorld = GameManager.worldState;

        // ボタン背景の初期色を取得
        firstColor = this.GetComponent<Button>().colors.normalColor;
        // ボタン背景の初期色の補色を取得
        complementaryColor = new Color(Mathf.Abs(firstColor.r - 1.0f), Mathf.Abs(firstColor.g - 1.0f), Mathf.Abs(firstColor.b - 1.0f));

        // ボタン文字の初期色を取得
        firstTextColor = this.GetComponentInChildren<TextMeshProUGUI>().color;
        // ボタン文字の初期色の補色を取得
        complementaryTextColor = new Color(Mathf.Abs(firstTextColor.r - 1.0f), Mathf.Abs(firstTextColor.g - 1.0f), Mathf.Abs(firstTextColor.b - 1.0f));
    }
    public void OnPushedButton()
    {  
        // 現在のシーンの再読み込み
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.worldState = stageStartWorld;
    }

    private void Update()
    {
        if (GameManager.worldState == 0)
        {
            this.GetComponentInChildren<TextMeshProUGUI>().color = firstTextColor;
        }
        else if (GameManager.worldState == 1)
        {
            this.GetComponentInChildren<TextMeshProUGUI>().color = complementaryTextColor;
        }
    }
}