using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToTitleScript : MonoBehaviour
{
    // ボタン背景の初期色を保存する変数
    Color firstColor;
    // ボタン背景の初期色の補色を保存する変数
    Color complementaryColor;

    // ボタン文字の初期色を保存する変数
    Color firstTextColor;
    // ボタン文字の初期色の補色を保存する変数
    Color complementaryTextColor;

    void Start()
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
        // アイテム保持一時的保存変数を初期化
        GameManager.holdRanunculus = false;
        // ステージセレクトへ戻る
        SceneManager.LoadScene("Title");
    }

    // Update is called once per frame
    void Update()
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
