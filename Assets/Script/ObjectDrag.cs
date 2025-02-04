using UnityEngine;
using System.Collections;

public class ObjectDrag : MonoBehaviour
{
    public void OnMouseDrag()
    {
        // マウスカーソル及びオブジェクトのスクリーン座標を取得
        Vector3 objectScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);

        // スクリーン座標をワールド座標に変換
        Vector3 objectworldPoint = Camera.main.ScreenToWorldPoint(objectScreenPoint);

        // オブジェクトの座標を変更する
        transform.position = objectworldPoint;
    }
}
