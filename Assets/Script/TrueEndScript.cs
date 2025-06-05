using UnityEngine;
using System.Collections;

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
    public bool clear = false;

    void Start()
    {
        TEPlayer = GameObject.Find("TrueEndPlayer");
        TRPlayer = GameObject.Find("TrueReflectionPlayer");
        Mirror = GameObject.Find("TrueEndMirror");
        StartCoroutine("TrueEndEvent");
    }

    void Update()
    {
        if (TEPlayerTrans == true && clear != true)
        {
            TEPlayer.transform.Translate(0.05f, 0.0f, 0.0f);
            TRPlayer.transform.Translate(-0.05f, 0.0f, 0.0f);
        }

        if (clear == true)
        {
            GameManager.worldState = 0;
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
    }
}
