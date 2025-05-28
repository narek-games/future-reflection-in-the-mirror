using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryScript : MonoBehaviour
{
    GameManager gameManager;

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
            // アイテム保持一時的保存変数を初期化
            GameManager.holdRanunculus = false;
            // 現在のシーンの再読み込み
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameManager.worldState = stageStartWorld;
            GameManager.phase = 0;
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
    }
}