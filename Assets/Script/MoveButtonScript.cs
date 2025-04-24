using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Recorder.OutputPath;

public class MoveButtonScript : MonoBehaviour
{
    // �{�^���w�i�̏����F��ۑ�����ϐ�
    Color firstColor;
    // �{�^���w�i�̏����F�̕�F��ۑ�����ϐ�
    Color complementaryColor;

    // �{�^�������̏����F��ۑ�����ϐ�
    Color firstTextColor;
    // �{�^�������̏����F�̕�F��ۑ�����ϐ�
    Color complementaryTextColor;

    // �v���C���[���i�[
    public GameObject player;
    // �e�{�^���̉�������
    bool mup = false;
    bool mdown = false;
    bool mleft = false;
    bool mright = false;

    SpriteRenderer playerSpriteRenderer;

    // �v���C���[�̉摜8��ނ��i�[����ϐ�
    public Sprite front;
    public Sprite back;
    public Sprite left;
    public Sprite right;
    public Sprite front_nega;
    public Sprite back_nega;
    public Sprite left_nega;
    public Sprite right_nega;

    void Start()
    {
        playerSpriteRenderer = player.gameObject.GetComponent<SpriteRenderer>();

        // �{�^���w�i�̏����F���擾
        firstColor = this.GetComponent<Image>().color;
        // �{�^���w�i�̏����F�̕�F���擾
        complementaryColor = new Color(Mathf.Abs(firstColor.r - 1.0f), Mathf.Abs(firstColor.g - 1.0f), Mathf.Abs(firstColor.b - 1.0f));

        // �{�^�������̏����F���擾
        firstTextColor = this.GetComponentInChildren<TextMeshProUGUI>().color;
        // �{�^�������̏����F�̕�F���擾
        complementaryTextColor = new Color(Mathf.Abs(firstTextColor.r - 1.0f), Mathf.Abs(firstTextColor.g - 1.0f), Mathf.Abs(firstTextColor.b - 1.0f));
    }

    void Update()
    {
        if (GameManager.worldState == 0)
        {
            this.GetComponent<Image>().color = firstColor;
            this.GetComponentInChildren<TextMeshProUGUI>().color = firstTextColor;
        }
        else if (GameManager.worldState == 1)
        {
            this.GetComponent<Image>().color = complementaryColor;
            this.GetComponentInChildren<TextMeshProUGUI>().color = complementaryTextColor;
        }

        // �ړ�����
        if(GameManager.phase == 1)
        {
            if (mup)
            {
                // ���E�̏�Ԃɂ���Č����ڕύX
                if (GameManager.worldState == 0)
                {
                    playerSpriteRenderer.sprite = back;
                }
                else if (GameManager.worldState == 1)
                {
                    playerSpriteRenderer.sprite = back_nega;
                }
                player.transform.Translate(0.0f, 0.005f, 0.0f);
            }
            else if (mdown)
            {
                // ���E�̏�Ԃɂ���Č����ڕύX
                if (GameManager.worldState == 0)
                {
                    playerSpriteRenderer.sprite = front;
                }
                else if (GameManager.worldState == 1)
                {
                    playerSpriteRenderer.sprite = front_nega;
                }
                player.transform.Translate(0.0f, -0.005f, 0.0f);
            }
            else if (mleft)
            {
                // ���E�̏�Ԃɂ���Č����ڕύX
                if (GameManager.worldState == 0)
                {
                    playerSpriteRenderer.sprite = left;
                }
                else if (GameManager.worldState == 1)
                {
                    playerSpriteRenderer.sprite = left_nega;
                }
                player.transform.Translate(-0.005f, 0.0f, 0.0f);
            }
            else if (mright)
            {
                // ���E�̏�Ԃɂ���Č����ڕύX
                if (GameManager.worldState == 0)
                {
                    playerSpriteRenderer.sprite = right;
                }
                else if (GameManager.worldState == 1)
                {
                    playerSpriteRenderer.sprite = right_nega;
                }
                player.transform.Translate(0.005f, 0.0f, 0.0f);
            }
        }   
    }

    public void uPushDown()
    {
        mup = true;
    }

    public void uPushUp()
    {
        mup = false;
    }

    public void dPushDown()
    {
        mdown = true;
    }

    public void dPushUp()
    {
        mdown = false;
    }

    public void rPushDown()
    {
        mright = true;
    }

    public void rPushUp()
    {
        mright = false;
    }

    public void lPushDown()
    {
        mleft = true;
    }

    public void lPushUp()
    {
        mleft = false;
    }
}
