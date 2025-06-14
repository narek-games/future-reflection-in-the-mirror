﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage20Script : MonoBehaviour
{
    SpriteRenderer goalSpriteRenderer;
    GameManager gameManager;

    // ゴールの画像2種類を格納する変数
    public Sprite goal;
    public Sprite goal_nega;

    // EDのルート分岐に使用する変数(0->TrueEnd, 1->NormalEnd)
    int EDflag = 0;

    void Start()
    {
        // ステージ開始時の世界を0で固定
        GameManager.worldState = 0;

        goalSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (GameManager.worldState == 0)
        {
            goalSpriteRenderer.sprite = goal;
        }
        else if (GameManager.worldState == 1)
        {
            goalSpriteRenderer.sprite = goal_nega;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // タグが"Player"のオブジェクトと衝突したとき
        if (other.CompareTag("Player"))
        {
            // アイテムが保持されているとき
            if (GameManager.holdRanunculus == true)
            {
                // アイテムの取得を保存する
                GameManager.gotRanunculus[19] = true;
            }

            // アイテム保持一時的保存変数を初期化
            GameManager.holdRanunculus = false;

            // EDflagの初期化
            EDflag = 0;
            // アイテム保持状況に応じて分岐、エンディングに遷移
            for (int i = 0; i < GameManager.gotRanunculus.Length; i++)
            {
                // 1つでもアイテムを逃していればNormalEndに遷移
                if (GameManager.gotRanunculus[i] == false)
                {
                    EDflag = 1;
                }
            }

            if(EDflag == 0)
            {
                SceneManager.LoadScene("TrueEnd");
            }
            else if(EDflag == 1)
            {
                SceneManager.LoadScene("NormalEnd");
            }

            // phase初期化
            GameManager.phase = 0;
            // 世界初期化
            GameManager.worldState = 0;
        }
    }
}
