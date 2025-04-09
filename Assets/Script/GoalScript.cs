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
    // 現在のステージを入れる
    private int currentSceneNum = 0;

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
            // アイテムが保持されているとき
            if(GameManager.holdRanunculus == true)
            {
                // アイテムの取得を保存する(配列番号は0～19のため-1で調整)
                GameManager.gotRanunculus[currentSceneNum - 1] = true;
            }

            // アイテム保持一時的保存変数を初期化
            GameManager.holdRanunculus = false;
            // 次のステージに切り替える
            SceneManager.LoadScene(stageName);
            // phase初期化
            GameManager.phase = 0;
        }
    }
}
