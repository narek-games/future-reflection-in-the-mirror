using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class TrueEndScript : MonoBehaviour
{
    GameObject TEPlayer;
    GameObject TRPlayer;
    GameObject Mirror;
    public GameObject Ranunculus;
    public GameObject BackToTitleButton;

    // �\�������֘A
    public GameObject gameClear;
    public GameObject comment;

    // �v���C���[�ړ��J�n�t���O
    bool TEPlayerTrans = false;

    // �N���A��ʕ\���t���O
    bool clear = false;

    void Start()
    {
        TEPlayer = GameObject.Find("TrueEndPlayer");
        TRPlayer = GameObject.Find("TrueReflectionPlayer");
        Mirror = GameObject.Find("EndMirror");
        StartCoroutine("TrueEndEvent");
    }

    void Update()
    {
        if (TEPlayerTrans == true && clear != true)
        {
            TEPlayer.transform.Translate(0.005f, 0.0f, 0.0f);
            TRPlayer.transform.Translate(-0.005f, 0.0f, 0.0f);
        }

        if (clear == true)
        {
            TEPlayer.SetActive(false);
            TRPlayer.SetActive(false);
            BackToTitleButton.SetActive(true);
            gameClear.SetActive(true);
            comment.SetActive(true);
            Mirror.SetActive(false);
            Ranunculus.SetActive(true);
        }
    }

    IEnumerator TrueEndEvent()
    {
        //2�b��~
        yield return new WaitForSeconds(2);
        TEPlayerTrans = true;
        yield return new WaitForSeconds(1.9f);
        clear = true;
    }
}
