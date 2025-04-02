using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    SpriteRenderer goalSpriteRenderer;
    GameManager gameManager;

    // ゴールの画像2種類を格納する変数
    public Sprite goal;
    public Sprite goal_nega;

    // 次のステージを入れる
    public int nextSceneNum = 0;

    private void Start()
    {
        goalSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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
        string stageName = "stage" + nextSceneNum;
        // タグが"Player"のオブジェクトと衝突したとき
        if (other.CompareTag("Player"))
        {
            // 次のステージに切り替える
            SceneManager.LoadScene(stageName);
            // phase初期化
            gameManager.phase = 0;
        }
    }
}
