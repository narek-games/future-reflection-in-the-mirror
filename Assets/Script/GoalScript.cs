using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    public int scenenNum = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        string stageName = "stage" + scenenNum;
        // タグが"Player"のオブジェクトと衝突したとき
        if (other.CompareTag("Player"))
        {
            // 次のステージに切り替える
            SceneManager.LoadScene(stageName);
        }
    }
}
