using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem.XR.Haptics;

public class MirrorScript : MonoBehaviour
{
    // オブジェクトをまとめる配列
    public GameObject[] flipObjects;

    // プレイヤーをいれる変数
    public GameObject player;
    // 状態(0->未設置(灰色)、1->鏡)を示す変数
    public int mirrorState = 0;

    // GameManager上の変数を取得するために
    public GameManager gameManager;

    public void OnTotched()
    {
        if(gameManager.phase == 0)
        {
            if (mirrorState == 0)
            {
                // 未起動->起動
                mirrorState = 1;
            }
            else if (mirrorState == 1)
            {
                // 起動->未起動
                mirrorState = 0;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // タグが"Player"のオブジェクトと衝突したとき
        if (other.gameObject.CompareTag("Player") && mirrorState == 1)
        {
            // 世界の反転
            if (GameManager.worldState == 0)
            {
                GameManager.worldState = 1;
            }
            else if (GameManager.worldState == 1)
            {
                GameManager.worldState = 0;
            }

            // "Objects"タグを持つオブジェクトを同じ配列に入れる
            flipObjects = GameObject.FindGameObjectsWithTag("Objects");

            // 配列から1つずつ順番に取り出し色相を反転
            foreach(GameObject flipObj in flipObjects)
            {
                Color tmpColor = flipObj.GetComponent<SpriteRenderer>().color;
                tmpColor.r = Mathf.Abs(tmpColor.r - 1.0f);
                tmpColor.g = Mathf.Abs(tmpColor.g - 1.0f);
                tmpColor.b = Mathf.Abs(tmpColor.b - 1.0f);
                flipObj.GetComponent<SpriteRenderer>().color = tmpColor;
            }

            // プレイヤーの色相を反転
            Color plaColor = player.GetComponent<SpriteRenderer>().color;
            plaColor.r = Mathf.Abs(plaColor.r - 1.0f);
            plaColor.g = Mathf.Abs(plaColor.g - 1.0f);
            plaColor.b = Mathf.Abs(plaColor.b - 1.0f);
            player.GetComponent<SpriteRenderer>().color = plaColor;

            // どの方向から衝突したかを検知
            // 衝突したオブジェクトの座標を取得
            Vector3 otherPos = other.transform.position;
            // 自身の座標を取得
            Vector3 thisPos = this.transform.position;
            // 鏡自身のサイズを取得
            float mirrorWidth = this.GetComponent<SpriteRenderer>().bounds.size.x;
            float mirrorHeight = this.GetComponent <SpriteRenderer>().bounds.size.y;
            // 衝突するplayerのサイズを取得
            float otherWidth = other.gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
            float otherHeight = other.gameObject.GetComponent <SpriteRenderer>().bounds.size.y;
            
            // 鏡の向きによって処理を変化
            if(this.gameObject.CompareTag("VMirror"))
            {
                if(thisPos.x < otherPos.x)
                {
                    other.transform.position = new Vector3(otherPos.x - (mirrorWidth + otherWidth), otherPos.y, otherPos.z);
                }
                else
                {
                    other.transform.position = new Vector3(otherPos.x + (mirrorWidth + otherWidth), otherPos.y, otherPos.z);
                }
            }
        }
    }

    public void Update()
    {
        // worldStateとmirrorStateの状態の組み合わせによる色変更
        if (GameManager.worldState == 0)
        {
            if (mirrorState == 0)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(128, 128, 128, 255);
            }
            else if (mirrorState == 1)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 255, 255);
            }
        }
        else if (GameManager.worldState == 1)
        {
            if (mirrorState == 0)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(128, 128, 128, 255);
            }
            else if (mirrorState == 1)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
            }
        }

        // mirrorStateの状態によるisTriggerの変更
        if(mirrorState == 0)
        {
            // 未起動ならすり抜ける(isTrigger = true)
            this.GetComponent<PolygonCollider2D>().isTrigger = true;
        }
        else if(mirrorState == 1)
        {
            // 起動なら衝突する
            this.GetComponent<PolygonCollider2D>().isTrigger = false;
        }
    }
}