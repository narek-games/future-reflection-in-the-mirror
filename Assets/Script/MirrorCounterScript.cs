using UnityEngine;

public class MirrorCounterScript : MonoBehaviour
{
    public StageMirrorCounter stageMirrorCounter;

    // 自身の向きを置ける上限を保存する変数
    public int maxMirror;

    private void Start()
    {
        // 自身がどの向きのカウンターかを判断して取得する
        if (this.gameObject.CompareTag("VMCounter"))
        {
            maxMirror = stageMirrorCounter.VMirrorCount;
        }
        else if (this.gameObject.CompareTag("HMCounter"))
        {
            maxMirror = stageMirrorCounter.HMirrorCount;
        }
        else if (this.gameObject.CompareTag("LDRUMCounter"))
        {
            maxMirror = stageMirrorCounter.LDRUMirrorCount;
        }
        else if (this.gameObject.CompareTag("LURDMCounter"))
        {
            maxMirror = stageMirrorCounter.LURDMirrorCount;
        }
    }

    private void Update()
    {
        // 設置上限になっていなければ水色、なっていれば灰色
        if(maxMirror > 0)
        {
            if(GameManager.worldState == 0)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 255, 255);
            }
            else if(GameManager.worldState == 1)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
            }
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = new Color32(128, 128, 128, 255);
        }
    }
}
