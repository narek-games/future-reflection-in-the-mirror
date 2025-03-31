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

    // 反転生成のもとになるオブジェクトを格納するリスト
    List<GameObject> generateBaseWalls = new List<GameObject>();
    // 反転生成されたオブジェクトを格納するリスト
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
                // Wallタグのついたオブジェクトをそれぞれ取得、全て対応する配列へ
                GameObject[] allVWalls = GameObject.FindGameObjectsWithTag("VWall");
                GameObject[] allHWalls = GameObject.FindGameObjectsWithTag("HWall");

                // この鏡がVなら
                if (this.gameObject.CompareTag("VMirror"))
                {   
                    foreach (GameObject VWObj in allVWalls)
                    {
                        // この鏡とy座標が等しいVWallを反転生成元リストに追加
                        if ((int)this.transform.position.y == (int)VWObj.transform.position.y)
                        {
                            generateBaseWalls.Add(VWObj);
                        }
                    }

                    foreach (GameObject HWObj in allHWalls)
                    {
                        // この鏡とHWallのy座標の差を計算
                        int y_difference = (int)this.transform.position.y - (int)HWObj.transform.position.y;
                        // y座標の差が+-1ならそのHWallを反転生成元リストに追加
                        if(y_difference == 1 || y_difference == -1)
                        {
                            generateBaseWalls.Add(HWObj);
                        }
                    }

                    // 反転生成元リストを1つずつ取り出し、それぞれ対称の座標を計算して生成、反転生成後リストに追加
                    foreach (GameObject generateWall in generateBaseWalls)
                    {
                        // 反転生成するx座標を格納する変数
                        float generate_x = 0;

                        // 取り出したオブジェクトの座標を格納
                        Vector3 basePos = generateWall.transform.position;

                        // この鏡と取り出したオブジェクトのx座標の符号が同じなら
                        if((this.transform.position.x >= 0 && basePos.x >= 0) || (this.transform.position.x < 0 && basePos.x < 0))
                        {
                            // 絶対値を用いてx座標の差を計算
                            float thisBaseDif = Mathf.Abs(this.transform.position.x) - Mathf.Abs(basePos.x);
                            // この鏡と取り出したオブジェクトの位置関係によって生成座標xを特定
                            if(this.transform.position.x > basePos.x)
                            {
                                generate_x = this.transform.position.x + Mathf.Abs(thisBaseDif);
                            }
                            else
                            {
                                generate_x = this.transform.position.x - Mathf.Abs(thisBaseDif);
                            }
                        }
                        else    // この鏡と取り出したオブジェクトのx座標の符号が異なるなら
                        {
                            // この鏡と取り出したオブジェクトの位置関係によって生成座標xを特定
                            if (this.transform.position.x > basePos.x)
                            {
                                generate_x = this.transform.position.x + (this.transform.position.x - basePos.x);
                            }
                            else
                            {
                                generate_x = this.transform.position.x - (basePos.x - this.transform.position.x);
                            }
                        }

                        // 向きに合わせて反転壁を生成し、反転生成後リストに追加
                        if (generateWall.gameObject.CompareTag("VWall"))
                        {
                            GameObject genWall = Instantiate(PreVWall, new Vector3(generate_x, basePos.y, 0.0f), Quaternion.identity);
                            generatedWalls.Add(genWall);
                        }
                        else if (generateWall.gameObject.CompareTag("HWall"))
                        {
                            GameObject genWall = Instantiate(PreHWall, new Vector3(generate_x, basePos.y, 0.0f), Quaternion.identity);
                            generatedWalls.Add(genWall);
                        }
                    }

                    // 生成元リストをクリア
                    generateBaseWalls.Clear();

                }
                else if (this.gameObject.CompareTag("HMirror"))    // この鏡がHなら
                {
                    foreach (GameObject HWObj in allHWalls)
                    {
                        // この鏡とx座標が等しいHWallを反転生成元リストに追加
                        if ((int)this.transform.position.x == (int)HWObj.transform.position.x)
                        {
                            generateBaseWalls.Add(HWObj);
                        }
                    }

                    foreach (GameObject VWObj in allVWalls)
                    {
                        // この鏡とVWallのx座標の差を計算
                        int x_difference = (int)this.transform.position.x - (int)VWObj.transform.position.x;
                        // y座標の差が+-1ならそのVWallを反転生成元リストに追加
                        if (x_difference == 1 || x_difference == -1)
                        {
                            generateBaseWalls.Add(VWObj);
                        }
                    }

                    // 反転生成元リストを1つずつ取り出し、それぞれ対称の座標を計算して生成、反転生成後リストに追加
                    foreach (GameObject generateWall in generateBaseWalls)
                    {
                        // 反転生成するy座標を格納する変数
                        float generate_y = 0;

                        // 取り出したオブジェクトの座標を格納
                        Vector3 basePos = generateWall.transform.position;

                        // この鏡と取り出したオブジェクトのy座標の符号が同じなら
                        if ((this.transform.position.y >= 0 && basePos.y >= 0) || (this.transform.position.y < 0 && basePos.y < 0))
                        {
                            // 絶対値を用いてy座標の差を計算
                            float thisBaseDif = Mathf.Abs(this.transform.position.y) - Mathf.Abs(basePos.y);
                            // この鏡と取り出したオブジェクトの位置関係によって生成座標yを特定
                            if (this.transform.position.y > basePos.y)
                            {
                                generate_y = this.transform.position.y + Mathf.Abs(thisBaseDif);
                            }
                            else
                            {
                                generate_y = this.transform.position.y - Mathf.Abs(thisBaseDif);
                            }
                        }
                        else    // この鏡と取り出したオブジェクトのy座標の符号が異なるなら
                        {
                            // この鏡と取り出したオブジェクトの位置関係によって生成座標yを特定
                            if (this.transform.position.y > basePos.y)
                            {
                                generate_y = this.transform.position.y + (this.transform.position.y - basePos.y);
                            }
                            else
                            {
                                generate_y = this.transform.position.y - (basePos.y - this.transform.position.y);
                            }
                        }

                        // 向きに合わせて反転壁を生成し、反転生成後リストに追加
                        if (generateWall.gameObject.CompareTag("VWall"))
                        {
                            GameObject genWall = Instantiate(PreVWall, new Vector3(basePos.x, generate_y, 0.0f), Quaternion.identity);
                            generatedWalls.Add(genWall);
                        }
                        else if (generateWall.gameObject.CompareTag("HWall"))
                        {
                            GameObject genWall = Instantiate(PreHWall, new Vector3(basePos.x, generate_y, 0.0f), Quaternion.identity);
                            generatedWalls.Add(genWall);
                        }
                    }

                    // 生成元リストをクリア
                    generateBaseWalls.Clear();

                }
                else if (this.gameObject.CompareTag("LDRUMirror"))    // この鏡がLDRUなら
                {
                    foreach (GameObject HWObj in allHWalls)
                    {
                        // この鏡とHWallのy座標の差を計算
                        int y_difference = (int)this.transform.position.y - (int)HWObj.transform.position.y;
                        // この鏡とx座標が等しいか、y座標の差が+-1のHWallを反転生成元リストに追加
                        if ((int)this.transform.position.x == (int)HWObj.transform.position.x || y_difference == 1 || y_difference == -1)
                        {
                            generateBaseWalls.Add(HWObj);
                        }
                    }

                    foreach (GameObject VWObj in allVWalls)
                    {
                        // この鏡とVWallのx座標の差を計算
                        int x_difference = (int)this.transform.position.x - (int)VWObj.transform.position.x;
                        // この鏡とy座標が等しいか、x座標の差が+-1のVWallを反転生成元リストに追加
                        if ((int)this.transform.position.y == (int)VWObj.transform.position.y || x_difference == 1 || x_difference == -1)
                        {
                            generateBaseWalls.Add(VWObj);
                        }
                    }

                    //↑ここまで(生成元の抽出)完了

                    // 反転生成元リストを1つずつ取り出し、それぞれ対称の座標を計算して生成、反転生成後リストに追加
                    foreach (GameObject generateWall in generateBaseWalls)
                    {
                        // 反転生成するx座標を格納する変数
                        float generate_x = 0;
                        // 反転生成するy座標を格納する変数
                        float generate_y = 0;

                        // 取り出したオブジェクトの座標を格納
                        Vector3 basePos = generateWall.transform.position;

                        // この鏡と取り出したオブジェクトのx座標の符号が同じなら
                        if((this.transform.position.x >= 0 && basePos.x >= 0) || (this.transform.position.x < 0 && basePos.x < 0))
                        {
                            // 絶対値を用いてx座標の差を計算
                            float thisBaseDif = Mathf.Abs(this.transform.position.x) - Mathf.Abs(basePos.x);
                            // この鏡と取り出したオブジェクトの位置関係によって生成座標"y"を特定
                            if (this.transform.position.x > basePos.x)
                            {
                                generate_y = this.transform.position.y - Mathf.Abs(thisBaseDif);
                            }
                            else
                            {
                                generate_y = this.transform.position.y + Mathf.Abs(thisBaseDif);
                            }
                        }
                        else    // この鏡と取り出したオブジェクトのx座標の符号が異なるなら
                        {
                            // この鏡と取り出したオブジェクトの位置関係によって生成座標"y"を特定
                            if(this.transform.position.x > basePos.x)
                            {
                                generate_y = this.transform.position.y - (this.transform.position.x - basePos.x);
                            }
                            else
                            {
                                generate_y = this.transform.position.y + (basePos.x - this.transform.position.x);
                            }
                        }

                        // この鏡と取り出したオブジェクトのy座標の符号が同じなら
                        if ((this.transform.position.y >= 0 && basePos.y >= 0) || (this.transform.position.y < 0 && basePos.y < 0))
                        {
                            // 絶対値を用いてy座標の差を計算
                            float thisBaseDif = Mathf.Abs(this.transform.position.y) - Mathf.Abs(basePos.y);
                            // この鏡と取り出したオブジェクトの位置関係によって生成座標"x"を特定
                            if (this.transform.position.y > basePos.y)
                            {
                                generate_x = this.transform.position.x - Mathf.Abs(thisBaseDif);
                            }
                            else
                            {
                                generate_x = this.transform.position.x + Mathf.Abs(thisBaseDif);
                            }
                        }
                        else    // この鏡と取り出したオブジェクトのy座標の符号が異なるなら
                        {
                            // この鏡と取り出したオブジェクトの位置関係によって生成座標"x"を特定
                            if (this.transform.position.y > basePos.y)
                            {
                                generate_x = this.transform.position.x - (this.transform.position.y - basePos.y);
                            }
                            else
                            {
                                generate_x = this.transform.position.x + (basePos.y - this.transform.position.y);
                            }
                        }

                        // 向きに合わせて反転壁を生成し、反転生成後リストに追加
                        if (generateWall.gameObject.CompareTag("VWall"))
                        {
                            GameObject genWall = Instantiate(PreHWall, new Vector3(generate_x, generate_y, 0.0f), Quaternion.identity);
                            generatedWalls.Add(genWall);
                        }
                        else if (generateWall.gameObject.CompareTag("HWall"))
                        {
                            GameObject genWall = Instantiate(PreVWall, new Vector3(generate_x, generate_y, 0.0f), Quaternion.identity);
                            generatedWalls.Add(genWall);
                        }
                    }

                    // 生成元リストをクリア
                    generateBaseWalls.Clear();

                }
                else if (this.gameObject.CompareTag("LURDMirror"))    // この鏡がLURDなら
                {
                    foreach (GameObject HWObj in allHWalls)
                    {
                        // この鏡とHWallのy座標の差を計算
                        int y_difference = (int)this.transform.position.y - (int)HWObj.transform.position.y;
                        // この鏡とx座標が等しいか、y座標の差が+-1のHWallを反転生成元リストに追加
                        if ((int)this.transform.position.x == (int)HWObj.transform.position.x || y_difference == 1 || y_difference == -1)
                        {
                            generateBaseWalls.Add(HWObj);
                        }
                    }

                    foreach (GameObject VWObj in allVWalls)
                    {
                        // この鏡とVWallのx座標の差を計算
                        int x_difference = (int)this.transform.position.x - (int)VWObj.transform.position.x;
                        // この鏡とy座標が等しいか、x座標の差が+-1のVWallを反転生成元リストに追加
                        if ((int)this.transform.position.y == (int)VWObj.transform.position.y || x_difference == 1 || x_difference == -1)
                        {
                            generateBaseWalls.Add(VWObj);
                        }
                    }

                    //↑ここまで(生成元の抽出)完了

                    // 反転生成元リストを1つずつ取り出し、それぞれ対称の座標を計算して生成、反転生成後リストに追加
                    foreach (GameObject generateWall in generateBaseWalls)
                    {
                        // 反転生成するx座標を格納する変数
                        float generate_x = 0;
                        // 反転生成するy座標を格納する変数
                        float generate_y = 0;

                        // 取り出したオブジェクトの座標を格納
                        Vector3 basePos = generateWall.transform.position;

                        // この鏡と取り出したオブジェクトのx座標の符号が同じなら
                        if ((this.transform.position.x >= 0 && basePos.x >= 0) || (this.transform.position.x < 0 && basePos.x < 0))
                        {
                            // 絶対値を用いてx座標の差を計算
                            float thisBaseDif = Mathf.Abs(this.transform.position.x) - Mathf.Abs(basePos.x);
                            // この鏡と取り出したオブジェクトの位置関係によって生成座標"y"を特定
                            if (this.transform.position.x > basePos.x)
                            {
                                generate_y = this.transform.position.y + Mathf.Abs(thisBaseDif);
                            }
                            else
                            {
                                generate_y = this.transform.position.y - Mathf.Abs(thisBaseDif);
                            }
                        }
                        else    // この鏡と取り出したオブジェクトのx座標の符号が異なるなら
                        {
                            // この鏡と取り出したオブジェクトの位置関係によって生成座標"y"を特定
                            if (this.transform.position.x > basePos.x)
                            {
                                generate_y = this.transform.position.y + (this.transform.position.x - basePos.x);
                            }
                            else
                            {
                                generate_y = this.transform.position.y - (basePos.x - this.transform.position.x);
                            }
                        }

                        // この鏡と取り出したオブジェクトのy座標の符号が同じなら
                        if ((this.transform.position.y >= 0 && basePos.y >= 0) || (this.transform.position.y < 0 && basePos.y < 0))
                        {
                            // 絶対値を用いてy座標の差を計算
                            float thisBaseDif = Mathf.Abs(this.transform.position.y) - Mathf.Abs(basePos.y);
                            // この鏡と取り出したオブジェクトの位置関係によって生成座標"x"を特定
                            if (this.transform.position.y > basePos.y)
                            {
                                generate_x = this.transform.position.x + Mathf.Abs(thisBaseDif);
                            }
                            else
                            {
                                generate_x = this.transform.position.x - Mathf.Abs(thisBaseDif);
                            }
                        }
                        else    // この鏡と取り出したオブジェクトのy座標の符号が異なるなら
                        {
                            // この鏡と取り出したオブジェクトの位置関係によって生成座標"x"を特定
                            if (this.transform.position.y > basePos.y)
                            {
                                generate_x = this.transform.position.x + (this.transform.position.y - basePos.y);
                            }
                            else
                            {
                                generate_x = this.transform.position.x - (basePos.y - this.transform.position.y);
                            }
                        }

                        // 向きに合わせて反転壁を生成し、反転生成後リストに追加
                        if (generateWall.gameObject.CompareTag("VWall"))
                        {
                            GameObject genWall = Instantiate(PreHWall, new Vector3(generate_x, generate_y, 0.0f), Quaternion.identity);
                            generatedWalls.Add(genWall);
                        }
                        else if (generateWall.gameObject.CompareTag("HWall"))
                        {
                            GameObject genWall = Instantiate(PreVWall, new Vector3(generate_x, generate_y, 0.0f), Quaternion.identity);
                            generatedWalls.Add(genWall);
                        }
                    }

                    // 生成元リストをクリア
                    generateBaseWalls.Clear();

                }
            }
            /* phase0で何度も切り替えが可能にするなら
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
            }*/
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // タグが"Player"のオブジェクトと衝突したとき
        if (other.gameObject.CompareTag("Player") && mirrorState == 1)
        {
            
            // どの方向から衝突したかを検知
            // 衝突したオブジェクトの座標を取得
            Vector3 otherPos = other.transform.position;
            // 鏡自身の座標を取得
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
                // 縦向きの鏡に上下から触れてしまうのを防ぐ
                if(!(thisPos.y + 1 < otherPos.y) && !(thisPos.y - 1 > otherPos.y))
                {
                    if (thisPos.x < otherPos.x)
                    {
                        // 右から衝突した場合
                        other.transform.position = new Vector3(otherPos.x - (mirrorWidth + otherWidth), otherPos.y, otherPos.z);
                    }
                    else
                    {
                        // 左から衝突した場合
                        other.transform.position = new Vector3(otherPos.x + (mirrorWidth + otherWidth), otherPos.y, otherPos.z);
                    }

                    // 世界の反転
                    if (GameManager.worldState == 0)
                    {
                        GameManager.worldState = 1;
                    }
                    else if (GameManager.worldState == 1)
                    {
                        GameManager.worldState = 0;
                    }
                }
                
            }
            else if (this.gameObject.CompareTag("HMirror"))
            {
                // 横向きの鏡に左右から触れてしまうのを防ぐ
                if(!(thisPos.x + 1 < otherPos.x) && !(thisPos.x - 1 > otherPos.x))
                {
                    if (thisPos.y < otherPos.y)
                    {
                        // 上から衝突した場合
                        other.transform.position = new Vector3(otherPos.x, otherPos.y - (mirrorHeight + otherHeight), otherPos.z);
                    }
                    else
                    {
                        // 下から衝突した場合
                        other.transform.position = new Vector3(otherPos.x, otherPos.y + (mirrorHeight + otherHeight), otherPos.z);
                    }

                    // 世界の反転
                    if (GameManager.worldState == 0)
                    {
                        GameManager.worldState = 1;
                    }
                    else if (GameManager.worldState == 1)
                    {
                        GameManager.worldState = 0;
                    }
                }
            }
            else if (this.gameObject.CompareTag("LDRUMirror"))
            {
                // 鏡のx切片を求める
                float x_section = thisPos.y - thisPos.x;
                // 鏡のx切片よりプレイヤーのx切片の方が小さければ(右下判定)
                if(x_section > otherPos.y - otherPos.x)
                {
                    // 右下から衝突した場合
                    other.transform.position = new Vector3(thisPos.x - 0.1f, thisPos.y + 0.1f);
                }
                else
                {
                    // 左上から衝突した場合
                    other.transform.position = new Vector3(thisPos.x + 0.1f, thisPos.y - 0.1f);
                }

                // 世界の反転
                if (GameManager.worldState == 0)
                {
                    GameManager.worldState = 1;
                }
                else if (GameManager.worldState == 1)
                {
                    GameManager.worldState = 0;
                }
            }
            else if (this.gameObject.CompareTag("LURDMirror"))
            {
                // 鏡のx切片を求める
                float x_section = thisPos.y + thisPos.x;
                // 鏡のx切片よりプレイヤーのx切片の方が小さければ(左下判定)
                if (x_section > otherPos.y + otherPos.x)
                {
                    // 左下から衝突した場合
                    other.transform.position = new Vector3(thisPos.x + 0.1f, thisPos.y + 0.1f);
                }
                else
                {
                    // 右上から衝突した場合
                    other.transform.position = new Vector3(thisPos.x - 0.1f, thisPos.y - 0.1f);
                }

                // 世界の反転
                if (GameManager.worldState == 0)
                {
                    GameManager.worldState = 1;
                }
                else if (GameManager.worldState == 1)
                {
                    GameManager.worldState = 0;
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