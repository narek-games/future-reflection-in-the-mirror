using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Recorder.OutputPath;

public class MoveButtonScript : MonoBehaviour
{
    // ボタン背景の初期色を保存する変数
    Color firstColor;
    // ボタン背景の初期色の補色を保存する変数
    Color complementaryColor;

    // ボタン文字の初期色を保存する変数
    Color firstTextColor;
    // ボタン文字の初期色の補色を保存する変数
    Color complementaryTextColor;

    // プレイヤーを格納
    public GameObject player;
    // 各ボタンの押下判定
    bool mup = false;
    bool mdown = false;
    bool mleft = false;
    bool mright = false;

    SpriteRenderer playerSpriteRenderer;

    // プレイヤーの画像8種類を格納する変数
    public Sprite front;
    public Sprite back;
    public Sprite left;
    public Sprite right;
    public Sprite front_nega;
    public Sprite back_nega;
    public Sprite left_nega;
    public Sprite right_nega;

    void Start()
    {
        playerSpriteRenderer = player.gameObject.GetComponent<SpriteRenderer>();

        // ボタン背景の初期色を取得
        firstColor = this.GetComponent<Image>().color;
        // ボタン背景の初期色の補色を取得
        complementaryColor = new Color(Mathf.Abs(firstColor.r - 1.0f), Mathf.Abs(firstColor.g - 1.0f), Mathf.Abs(firstColor.b - 1.0f));

        // ボタン文字の初期色を取得
        firstTextColor = this.GetComponentInChildren<TextMeshProUGUI>().color;
        // ボタン文字の初期色の補色を取得
        complementaryTextColor = new Color(Mathf.Abs(firstTextColor.r - 1.0f), Mathf.Abs(firstTextColor.g - 1.0f), Mathf.Abs(firstTextColor.b - 1.0f));
    }

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

        // 移動処理
        if(GameManager.phase == 1)
        {
            if (mup)
            {
                // 世界の状態によって見た目変更
                if (GameManager.worldState == 0)
                {
                    playerSpriteRenderer.sprite = back;
                }
                else if (GameManager.worldState == 1)
                {
                    playerSpriteRenderer.sprite = back_nega;
                }
                player.transform.Translate(0.0f, 0.005f, 0.0f);
            }
            else if (mdown)
            {
                // 世界の状態によって見た目変更
                if (GameManager.worldState == 0)
                {
                    playerSpriteRenderer.sprite = front;
                }
                else if (GameManager.worldState == 1)
                {
                    playerSpriteRenderer.sprite = front_nega;
                }
                player.transform.Translate(0.0f, -0.005f, 0.0f);
            }
            else if (mleft)
            {
                // 世界の状態によって見た目変更
                if (GameManager.worldState == 0)
                {
                    playerSpriteRenderer.sprite = left;
                }
                else if (GameManager.worldState == 1)
                {
                    playerSpriteRenderer.sprite = left_nega;
                }
                player.transform.Translate(-0.005f, 0.0f, 0.0f);
            }
            else if (mright)
            {
                // 世界の状態によって見た目変更
                if (GameManager.worldState == 0)
                {
                    playerSpriteRenderer.sprite = right;
                }
                else if (GameManager.worldState == 1)
                {
                    playerSpriteRenderer.sprite = right_nega;
                }
                player.transform.Translate(0.005f, 0.0f, 0.0f);
            }
        }   
    }

    public void uPushDown()
    {
        mup = true;
    }

    public void uPushUp()
    {
        mup = false;
    }

    public void dPushDown()
    {
        mdown = true;
    }

    public void dPushUp()
    {
        mdown = false;
    }

    public void rPushDown()
    {
        mright = true;
    }

    public void rPushUp()
    {
        mright = false;
    }

    public void lPushDown()
    {
        mleft = true;
    }

    public void lPushUp()
    {
        mleft = false;
    }
}
