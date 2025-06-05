using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class NormalEndScript : MonoBehaviour
{
    GameObject NEPlayer;
    GameObject NRPlayer;
    public GameObject BackToTitleButton;
    
    SpriteRenderer NEPlayerSpriteRenderer;
    public Sprite nega;

    // 表示文字関連
    public GameObject gameClear;
    public GameObject comment;
    public GameObject comment2;

    // プレイヤー移動開始フラグ
    bool NEPlayerTrans = false;

    void Start()
    {
        NEPlayer = GameObject.Find("NormalEndPlayer");
        NEPlayerSpriteRenderer = NEPlayer.GetComponent<SpriteRenderer>();
        NRPlayer = GameObject.Find("NormalReflectionPlayer");
        StartCoroutine("NormalEndEvent");
    }

    void Update()
    {
        if(NEPlayerTrans == true && GameManager.worldState == 0)
        {
            NEPlayer.transform.Translate(0.005f, 0.0f, 0.0f);
        }

        if(GameManager.worldState == 1)
        {
            NEPlayerSpriteRenderer.sprite = nega;
            NRPlayer.SetActive(false);
            BackToTitleButton.SetActive(true);
            gameClear.SetActive(true);
            comment.SetActive(true);
            comment2.SetActive(true);
        }
    }

    IEnumerator NormalEndEvent()
    {
        //2秒停止
        yield return new WaitForSeconds(2);
        NEPlayerTrans = true;
    }
}
