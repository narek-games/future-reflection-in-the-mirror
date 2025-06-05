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

    // �\�������֘A
    public GameObject gameClear;
    public GameObject comment;
    public GameObject comment2;

    // �v���C���[�ړ��J�n�t���O
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
        //2�b��~
        yield return new WaitForSeconds(2);
        NEPlayerTrans = true;
    }
}
