using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class GoalScript : MonoBehaviour
{
    SpriteRenderer goalSpriteRenderer;
    GameManager gameManager;

    // ゴールの画像2種類を格納する変数
    public Sprite goal;
    public Sprite goal_nega;

    // 次のステージを入れる
    public int nextSceneNum = 0;
    // 現在のステージを入れる
    private int currentSceneNum = 0;
    
    string stageName;

    // 以下クリア文字表示に関する変数
    // クリア文字背景オブジェクトのSpriteRendererを格納する変数
    SpriteRenderer clearTextBackSpriteRenderer;
    // 初期色(黒)を保存する変数
    Color clearTextBackFirstColor;
    // 初期色の補色(白)を保存する変数
    Color clearTextBackComColor;

    // クリア文字を格納する変数
    TextMeshProUGUI clearText;
    // 初期色(白)を保存する変数
    Color clearTextFirstColor;
    // 初期色の補色(黒)を保存する変数
    Color clearTextComColor;


    private void Start()
    {
        goalSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        // 現在のステージ数を数字で取得
        string sceneName = SceneManager.GetActiveScene().name;
        for (int i = 0; i < GameManager.stageNumArray.Length; i++)
        {
            if (sceneName.Equals("Stage" + GameManager.stageNumArray[i]))
            {
                currentSceneNum = i;
            }
        }

        // クリア文字背景オブジェクトを取得し変数に格納
        clearTextBackSpriteRenderer = GameObject.FindGameObjectWithTag("ClearTextBack").GetComponent<SpriteRenderer>();
        // 初期色を取得
        clearTextBackFirstColor = clearTextBackSpriteRenderer.color;
        // 初期色の補色を取得
        clearTextBackComColor = new Color(Mathf.Abs(clearTextBackFirstColor.r - 1.0f), Mathf.Abs(clearTextBackFirstColor.g - 1.0f), Mathf.Abs(clearTextBackFirstColor.b - 1.0f));

        // クリア文字を取得し変数に格納
        clearText = GameObject.FindGameObjectWithTag("ClearText").GetComponent<TextMeshProUGUI>();
        // 初期色を取得
        clearTextFirstColor = clearText.color;
        // 初期色の補色を取得
        clearTextComColor = new Color(Mathf.Abs(clearTextFirstColor.r - 1.0f), Mathf.Abs(clearTextFirstColor.g - 1.0f), Mathf.Abs(clearTextFirstColor.b - 1.0f));

    }

    private void Update()
    {
        if(GameManager.worldState == 0)
        {
            goalSpriteRenderer.sprite = goal;
        }
        else if(GameManager.worldState == 1)
        {
            goalSpriteRenderer.sprite = goal_nega;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        stageName = "stage" + nextSceneNum;
        // タグが"Player"のオブジェクトと衝突したとき
        if (other.CompareTag("Player"))
        {
            // アイテムが保持されているとき
            if(GameManager.holdRanunculus == true)
            {
                // アイテムの取得を保存する(配列番号は0～19のため-1で調整)
                GameManager.gotRanunculus[currentSceneNum - 1] = true;
            }

            // 次のステージをStageSelectで解放する
            GameManager.unlookedStage[currentSceneNum] = true;

            // アイテム保持一時的保存変数を初期化
            GameManager.holdRanunculus = false;

            // 操作不能phaseへ
            GameManager.phase = 2;

            // コルーチンで指定秒操作不能
            StartCoroutine("StageTransition");

            // クリア演出フェードインスタート
            StartCoroutine("FadeInClearTextBack");
            StartCoroutine("FadeInClearText");
        }
    }

    IEnumerator StageTransition()
    {
        //3秒停止
        yield return new WaitForSeconds(3);
        // 次のステージに切り替える
        SceneManager.LoadScene(stageName);
        // phase初期化
        GameManager.phase = 0;
    }

    IEnumerator FadeInClearText()
    {
        float fadeDuration = 1.0f;
        float currentFadeTime = 0.0f;

        

        while (currentFadeTime < fadeDuration)
        {
            // 現在のAlpha値を計算
            float alphaValue = 0 + (currentFadeTime / fadeDuration);
            if (GameManager.worldState == 0)
            {
                // オブジェクトの色を更新
                clearText.color = new Color(clearTextFirstColor.r, clearTextFirstColor.g, clearTextFirstColor.b, alphaValue);
            }
            else if (GameManager.worldState == 1)
            {
                // オブジェクトの色を更新
                clearText.color = new Color(clearTextComColor.r, clearTextComColor.g, clearTextComColor.b, alphaValue);
            }
            yield return null;
            currentFadeTime += Time.deltaTime;
        }

        //1秒停止
        yield return new WaitForSeconds(1);

        // フェードアウトコルーチンの起動
        StartCoroutine("FadeOutClearText");
    }

    IEnumerator FadeOutClearText()
    {
        float fadeDuration = 1.0f;
        float currentFadeTime = 0.0f;

        while (currentFadeTime < fadeDuration)
        {
            // 現在のAlpha値を計算
            float alphaValue = 1 - (currentFadeTime / fadeDuration);
            if (GameManager.worldState == 0)
            {
                // オブジェクトの色を更新
                clearText.color = new Color(clearTextFirstColor.r, clearTextFirstColor.g, clearTextFirstColor.b, alphaValue);
            }
            else if (GameManager.worldState == 1)
            {
                // オブジェクトの色を更新
                clearText.color = new Color(clearTextComColor.r, clearTextComColor.g, clearTextComColor.b, alphaValue);
            }
            yield return null;
            currentFadeTime += Time.deltaTime;
        }
    }

    IEnumerator FadeInClearTextBack()
    {
        float fadeDuration = 1.0f;
        float currentFadeTime = 0.0f;

        while(currentFadeTime < fadeDuration)
        {
            // 現在のAlpha値を計算
            float alphaValue = 0 + (currentFadeTime / fadeDuration);
            if (GameManager.worldState == 0)
            {
                // オブジェクトの色を更新
                clearTextBackSpriteRenderer.color = new Color(clearTextBackFirstColor.r, clearTextBackFirstColor.g, clearTextBackFirstColor.b, alphaValue);
            }
            else if (GameManager.worldState == 1)
            {
                // オブジェクトの色を更新
                clearTextBackSpriteRenderer.color = new Color(clearTextBackComColor.r, clearTextBackComColor.g, clearTextBackComColor.b, alphaValue);
            }
            yield return null;
            currentFadeTime += Time.deltaTime;
        }

        //1秒停止
        yield return new WaitForSeconds(1);

        // フェードアウトコルーチンの起動
        StartCoroutine("FadeOutClearTextBack");
    }

    IEnumerator FadeOutClearTextBack()
    {
        float fadeDuration = 1.0f;
        float currentFadeTime = 0.0f;

        while (currentFadeTime < fadeDuration)
        {
            // 現在のAlpha値を計算
            float alphaValue = 1 - (currentFadeTime / fadeDuration);
            if (GameManager.worldState == 0)
            {
                // オブジェクトの色を更新
                clearTextBackSpriteRenderer.color = new Color(clearTextBackFirstColor.r, clearTextBackFirstColor.g, clearTextBackFirstColor.b, alphaValue);
            }
            else if (GameManager.worldState == 1)
            {
                // オブジェクトの色を更新
                clearTextBackSpriteRenderer.color = new Color(clearTextBackComColor.r, clearTextBackComColor.g, clearTextBackComColor.b, alphaValue);
            }
            yield return null;
            currentFadeTime += Time.deltaTime;
        }
    }
}
