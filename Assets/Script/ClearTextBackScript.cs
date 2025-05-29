using UnityEngine;

public class ClearTextBackScript : MonoBehaviour
{
    float fadeDuration = 1.0f; // �������ɂ����鎞�ԁi�b�j

    private float currentFadeTime;

    // �����F(��)��ۑ�����ϐ�
    Color clearTextBackFirstColor;
    // �����F�̕�F(��)��ۑ�����ϐ�
    Color clearTextBackComColor;

    void Start()
    {
        // �����F���擾
        clearTextBackFirstColor = gameObject.GetComponent<SpriteRenderer>().color;
        // �����F�̕�F���擾
        clearTextBackComColor = new Color(Mathf.Abs(clearTextBackFirstColor.r - 1.0f), Mathf.Abs(clearTextBackFirstColor.g - 1.0f), Mathf.Abs(clearTextBackFirstColor.b - 1.0f));
    }

    void Update()
    {
        if(GameManager.phase == 2)
        {
            Debug.Log(currentFadeTime);
            if (currentFadeTime < fadeDuration)
            {
                
                // ���݂�Alpha�l���v�Z
                float alphaValue = 0 + (currentFadeTime / fadeDuration);
                if (GameManager.worldState == 0)
                {
                    // �I�u�W�F�N�g�̐F���X�V
                    this.GetComponent<SpriteRenderer>().color = new Color(clearTextBackFirstColor.r, clearTextBackFirstColor.g, clearTextBackFirstColor.b, alphaValue);
                }
                else if (GameManager.worldState == 1)
                {
                    // �I�u�W�F�N�g�̐F���X�V
                    this.GetComponent<SpriteRenderer>().color = new Color(clearTextBackComColor.r, clearTextBackComColor.g, clearTextBackComColor.b, alphaValue);
                }
                // ���Ԃ��X�V
                currentFadeTime += Time.deltaTime;
                Debug.Log(currentFadeTime);
            }
        }
    }
}
