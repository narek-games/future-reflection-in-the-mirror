using UnityEngine;

public class SSFadeInScript : MonoBehaviour
{
    float fadeDuration = 1.0f; // �������ɂ����鎞�ԁi�b�j

    private float currentFadeTime;

    // �����F(��)��ۑ�����ϐ�
    Color fadeInFirstColor;
    // �����F�̕�F(��)��ۑ�����ϐ�
    Color fadeInComColor;

    void Start()
    {
        // �����F���擾
        fadeInFirstColor = gameObject.GetComponent<SpriteRenderer>().color;
        // �����F�̕�F���擾
        fadeInComColor = new Color(Mathf.Abs(fadeInFirstColor.r - 1.0f), Mathf.Abs(fadeInFirstColor.g - 1.0f), Mathf.Abs(fadeInFirstColor.b - 1.0f));
    }

    void Update()
    {
        if (currentFadeTime < fadeDuration)
        {
            // ���݂�Alpha�l���v�Z
            float alphaValue = 1 - (currentFadeTime / fadeDuration);
            if(GameManager.worldState == 0)
            {
                // �I�u�W�F�N�g�̐F���X�V
                this.GetComponent<SpriteRenderer>().color = new Color(fadeInFirstColor.r, fadeInFirstColor.g, fadeInFirstColor.b, alphaValue);
            }
            else if(GameManager.worldState == 1)
            {
                // �I�u�W�F�N�g�̐F���X�V
                this.GetComponent<SpriteRenderer>().color = new Color(fadeInComColor.r, fadeInComColor.g, fadeInComColor.b, alphaValue);
            }
            // ���Ԃ��X�V
            currentFadeTime += Time.deltaTime;
        }
    }
}
