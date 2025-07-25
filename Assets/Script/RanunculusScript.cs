﻿using UnityEngine;

public class RanunculusScript : MonoBehaviour
{
    SpriteRenderer ranunculusSpriteRenderer;
    GameManager gameManager;

    // ラナンキュラスの画像2種類を格納する変数
    public Sprite ranunculus;
    public Sprite ranunculus_nega;

    // ラナンキュラス取得時に流すSEを格納する変数
    public AudioClip ranunculusSE;

    void Start()
    {
        ranunculusSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (GameManager.worldState == 0)
        {
            ranunculusSpriteRenderer.sprite = ranunculus;
        }
        else if (GameManager.worldState == 1)
        {
            ranunculusSpriteRenderer.sprite = ranunculus_nega;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // タグが"Player"のオブジェクトと衝突したとき
        if (other.CompareTag("Player"))
        {
            // SEを流す
            GameObject.FindObjectOfType<AudioSource>().PlayOneShot(ranunculusSE);

            // アイテムを保持したことを一時的に保存
            GameManager.holdRanunculus = true;

            // 自身を消す
            this.gameObject.SetActive(false);
        }
    }
}
