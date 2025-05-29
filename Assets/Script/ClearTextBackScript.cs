using UnityEngine;

public class ClearTextBackScript : MonoBehaviour
{
    float fadeDuration = 1.0f; // 透明化にかかる時間（秒）

    private float currentFadeTime;

    // 初期色(白)を保存する変数
    Color clearTextBackFirstColor;
    // 初期色の補色(黒)を保存する変数
    Color clearTextBackComColor;

    void Start()
    {
        // 初期色を取得
        clearTextBackFirstColor = gameObject.GetComponent<SpriteRenderer>().color;
        // 初期色の補色を取得
        clearTextBackComColor = new Color(Mathf.Abs(clearTextBackFirstColor.r - 1.0f), Mathf.Abs(clearTextBackFirstColor.g - 1.0f), Mathf.Abs(clearTextBackFirstColor.b - 1.0f));
    }

    void Update()
    {
        if(GameManager.phase == 2)
        {
            Debug.Log(currentFadeTime);
            if (currentFadeTime < fadeDuration)
            {
                
                // 現在のAlpha値を計算
                float alphaValue = 0 + (currentFadeTime / fadeDuration);
                if (GameManager.worldState == 0)
                {
                    // オブジェクトの色を更新
                    this.GetComponent<SpriteRenderer>().color = new Color(clearTextBackFirstColor.r, clearTextBackFirstColor.g, clearTextBackFirstColor.b, alphaValue);
                }
                else if (GameManager.worldState == 1)
                {
                    // オブジェクトの色を更新
                    this.GetComponent<SpriteRenderer>().color = new Color(clearTextBackComColor.r, clearTextBackComColor.g, clearTextBackComColor.b, alphaValue);
                }
                // 時間を更新
                currentFadeTime += Time.deltaTime;
                Debug.Log(currentFadeTime);
            }
        }
    }
}
