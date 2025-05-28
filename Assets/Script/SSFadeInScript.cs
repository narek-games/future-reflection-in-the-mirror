using UnityEngine;

public class SSFadeInScript : MonoBehaviour
{
    float fadeDuration = 1.0f; // 透明化にかかる時間（秒）

    private float currentFadeTime;

    // 初期色(白)を保存する変数
    Color fadeInFirstColor;
    // 初期色の補色(黒)を保存する変数
    Color fadeInComColor;

    void Start()
    {
        // 初期色を取得
        fadeInFirstColor = gameObject.GetComponent<SpriteRenderer>().color;
        // 初期色の補色を取得
        fadeInComColor = new Color(Mathf.Abs(fadeInFirstColor.r - 1.0f), Mathf.Abs(fadeInFirstColor.g - 1.0f), Mathf.Abs(fadeInFirstColor.b - 1.0f));
    }

    void Update()
    {
        if (currentFadeTime < fadeDuration)
        {
            // 現在のAlpha値を計算
            float alphaValue = 1 - (currentFadeTime / fadeDuration);
            if(GameManager.worldState == 0)
            {
                // オブジェクトの色を更新
                this.GetComponent<SpriteRenderer>().color = new Color(fadeInFirstColor.r, fadeInFirstColor.g, fadeInFirstColor.b, alphaValue);
            }
            else if(GameManager.worldState == 1)
            {
                // オブジェクトの色を更新
                this.GetComponent<SpriteRenderer>().color = new Color(fadeInComColor.r, fadeInComColor.g, fadeInComColor.b, alphaValue);
            }
            // 時間を更新
            currentFadeTime += Time.deltaTime;
        }
    }
}
