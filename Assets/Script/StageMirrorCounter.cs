using UnityEngine;

public class StageMirrorCounter : MonoBehaviour
{
    /*
    ステージごとにこのスクリプトがアタッチされているオブジェクトの
    変数を指定してそのステージの鏡の設置上限を設定する
    */

    // 縦の鏡の設置上限
    public int VMirrorCount;
    // 横の鏡の設置上限
    public int HMirrorCount;
    // 左下から右上の斜め鏡の設置上限
    public int LDRUMirrorCount;
    // 左上から右下の斜め鏡の設置上限
    public int LURDMirrorCount;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
