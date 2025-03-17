using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.UI;

public class MirrorScript : MonoBehaviour
{
    // 状態(0->未設置(灰色)、1->鏡)を示す変数
    public int mirrorState = 0;

    // 他オブジェクト上の変数を取得するために
    public GameManager gameManager;

    // 自身のタグを保存する変数
    string thisTag;

    // 自身に対応するタグを保存する変数
    string thisCounterTag;

    // 反転生成用のプレハブを取得
    GameObject PreVWall;
    GameObject PreHWall;

    // 反転生成されたオブジェクトを格納するList
    List<GameObject> generatedWalls = new List<GameObject>();

    private void Start()
    {
        // 自身のタグから対応するカウンターの向きを取得
        thisTag = this.gameObject.tag;

        if (thisTag.Equals("VMirror"))
        {
            thisCounterTag = "VMCounter";
        }
        else if (thisTag.Equals("HMirror"))
        {
            thisCounterTag = "HMCounter";
        }
        else if (thisTag.Equals("LDRUMirror"))
        {
            thisCounterTag = "LDRUMCounter";
        }
        else if (thisTag.Equals("LURDMirror"))
        {
            thisCounterTag = "LURDMCounter";
        }

        PreVWall = (GameObject)Resources.Load("VerticalWall");
        PreHWall = (GameObject)Resources.Load("HorizonWall");
    }

    public void OnTotched()
    {
        if(gameManager.phase == 0)
        {
            //鏡が未起動 && 対応するカウンターのmaxMirrorが1以上
            if (mirrorState == 0 && GameObject.FindGameObjectWithTag(thisCounterTag).GetComponent<MirrorCounterScript>().maxMirror > 0)
            {
                // 未起動->起動
                mirrorState = 1;

                // 自身の鏡の向きと対応するカウンターの数を変更
                GameObject.FindGameObjectWithTag(thisCounterTag).GetComponent<MirrorCounterScript>().maxMirror--;

                // 反転壁生成
                GameObject genVW = Instantiate(PreVWall, new Vector3(-4.0f, 1.0f, 0.0f), Quaternion.identity);
                // 生成した壁をリストへ追加
                generatedWalls.Add(genVW);
            }
            else if (mirrorState == 1)
            {
                // 起動->未起動
                mirrorState = 0;

                // 自身の鏡の向きと対応するカウンターの数を変更
                GameObject.FindGameObjectWithTag(thisCounterTag).GetComponent<MirrorCounterScript>().maxMirror++;

                // この鏡によって生成された反転壁を全て削除
                for(int i = 0; i < generatedWalls.Count; i++)
                {
                    Destroy(generatedWalls[i]);
                }
                //リスト自体を綺麗にする
                generatedWalls.Clear();
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
                    // 右から衝突した場合
                    other.transform.position = new Vector3(otherPos.x - (mirrorWidth + otherWidth), otherPos.y, otherPos.z);
                }
                else
                {
                    // 左から衝突した場合
                    other.transform.position = new Vector3(otherPos.x + (mirrorWidth + otherWidth), otherPos.y, otherPos.z);
                }
            }
            else if (this.gameObject.CompareTag("HMirror"))
            {
                if(thisPos.y < otherPos.y)
                {
                    // 上から衝突した場合
                    other.transform.position = new Vector3(otherPos.x, otherPos.y - (mirrorHeight + otherHeight), otherPos.z);
                }
                else
                {
                    // 下から衝突した場合
                    other.transform.position = new Vector3(otherPos.x, otherPos.y + (mirrorHeight + otherHeight), otherPos.z);
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
                this.GetComponent<SpriteRenderer>().color = new Color32(128, 128, 128, 128);
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
                this.GetComponent<SpriteRenderer>().color = new Color32(128, 128, 128, 128);
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