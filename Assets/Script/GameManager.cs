using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 現在のステージ数を検索するために必要な配列(ステージを作った数だけここに追加)(0は配列番号と合わせるため)
    private int[] stageNumArray = new int[] { 0, 1, 2 };

    // 現在のステージ数を入れる変数
    public int stageNum;

    // ステージ数を表示するText型の変数
    public TextMeshProUGUI stageNumText;

    // 世界が通常->0か、反転->1かを判断するための変数
    public static int worldState = 0;

    // 現在のフェーズが鏡設置フェーズ->0か、移動フェーズ->1かを判断するための変数
    public int phase = 0;

    void Start()
    {
        
    }

    void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        for(int i = 0; i < stageNumArray.Length; i++)
        {
            if(sceneName.Equals("Stage" + stageNumArray[i]))
            {
                stageNum = i;
            }
        }

        stageNumText.text = "stage " + stageNum.ToString();
    }

    //関数---------------------------------------

}
