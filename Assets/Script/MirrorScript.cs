using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MirrorScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // タグが"Player"のオブジェクトと衝突したとき
        if (other.CompareTag("Player"))
        {
            // 色相を反転(現状自身(鏡)の色を取得している(thisの部分を変更する))
            Color tmpColor = this.GetComponent<SpriteRenderer>().color;
            tmpColor.r = Mathf.Abs(tmpColor.r - 1.0f);
            tmpColor.g = Mathf.Abs(tmpColor.g - 1.0f);
            tmpColor.b = Mathf.Abs(tmpColor.b - 1.0f);
            this.GetComponent<SpriteRenderer>().color = tmpColor;

            /*
            foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
            {
                if (obj.activeInHierarchy)
                {
                    Color tmpColor = obj.GetComponent<Color>();
                    tmpColor.r = 1.0f - tmpColor.r;
                    tmpColor.g = 1.0f - tmpColor.g;
                    tmpColor.b = 1.0f - tmpColor.b;
                    obj.GetComponent<Renderer>().material.color = tmpColor;
                }
            }*/
        }
    }
}