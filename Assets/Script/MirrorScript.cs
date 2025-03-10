using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MirrorScript : MonoBehaviour
{
    public GameObject[] flipObjects;
    public GameObject[] flipVMirror;
    public GameObject player;
    // 状態(0->未設置(灰色)、1->鏡)を示す変数
    public int mirrorState = 0;

    public void OnTotched()
    {
        Debug.Log("タッチ検知");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // タグが"Player"のオブジェクトと衝突したとき
        if (other.CompareTag("Player") && mirrorState == 1)
        {
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

            // "VMirror"タグを持つオブジェクトを同じ配列に入れる
            flipVMirror = GameObject.FindGameObjectsWithTag("VMirror");

            // 配列から1つずつ順番に取り出し色相を反転
            foreach (GameObject flipObj in flipVMirror)
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

        }
    }
}