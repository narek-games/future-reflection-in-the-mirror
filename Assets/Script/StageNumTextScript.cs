using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageNumTextScript : MonoBehaviour
{
    // 現在のステージ数を入れる変数
    public int stageNum;

    // ステージ数を表示するText型の変数
    public TextMeshProUGUI stageNumText;

    void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        for (int i = 0; i < GameManager.stageNumArray.Length; i++)
        {
            if (sceneName.Equals("Stage" + GameManager.stageNumArray[i]))
            {
                stageNum = i;
            }
        }

        stageNumText.text = "stage " + stageNum.ToString();
    }
}
