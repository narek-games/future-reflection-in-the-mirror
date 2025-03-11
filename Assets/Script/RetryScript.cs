using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryScript : MonoBehaviour
{
    public int stageStartWorld;
    private void Start()
    {
        // ステージ開始時点のworldStateを保存
        stageStartWorld = GameManager.worldState;
    }
    public void OnPushedButton()
    {  
        // 現在のシーンの再読み込み
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.worldState = stageStartWorld;
    }
}