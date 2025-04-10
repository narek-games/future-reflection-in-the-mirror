using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 現在のステージ数を検索するために必要な配列(ステージを作った数だけここに追加)(0は配列番号と合わせるため)
    public static int[] stageNumArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

    // 世界が通常->0か、反転->1かを判断するための変数
    public static int worldState = 0;

    // 現在のフェーズが鏡設置フェーズ->0か、移動フェーズ->1かを判断するための変数
    public static int phase = 0;

    // アイテムを取得したことを一時的に保存する変数
    public static bool holdRanunculus = false;

    // アイテム取得状況配列(1～20ステージ分)
    public static bool[] gotRanunculus = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

    // 挑戦可能ステージ配列(1～20ステージ分)
    public static bool[] unlookedStage = new bool[] { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

    void Update()
    {

    }

    //関数---------------------------------------

}
