using UnityEngine;
using UnityEngine.SceneManagement;

public class crossScript : MonoBehaviour
{
    SpriteRenderer crossSpriteRenderer;
    GameManager gameManager;

    // Xの画像2種類を格納する変数
    public Sprite cross;
    public Sprite cross_nega;

    public int stageStartWorld;

    private void Start()
    {
        // ステージ開始時点のworldStateを保存
        stageStartWorld = GameManager.worldState;
        // このオブジェクトのスプライトを取得
        crossSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (GameManager.worldState == 0)
        {
            crossSpriteRenderer.sprite = cross;
        }
        else if (GameManager.worldState == 1)
        {
            crossSpriteRenderer.sprite = cross_nega;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // タグが"Player"のオブジェクトと衝突したとき
        if (other.CompareTag("Player"))
        {
            // 現在のシーンの再読み込み
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameManager.worldState = stageStartWorld;
            // phase初期化
            gameManager.phase = 0;
        }
    }
}
