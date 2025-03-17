using UnityEngine;

public class MirrorCounterScript : MonoBehaviour
{
    public StageMirrorCounter stageMirrorCounter;

    // ���g�̌�����u��������ۑ�����ϐ�
    public int maxMirror;

    private void Start()
    {
        // ���g���ǂ̌����̃J�E���^�[���𔻒f���Ď擾����
        if (this.gameObject.CompareTag("VMCounter"))
        {
            maxMirror = stageMirrorCounter.VMirrorCount;
        }
        else if (this.gameObject.CompareTag("HMCounter"))
        {
            maxMirror = stageMirrorCounter.HMirrorCount;
        }
        else if (this.gameObject.CompareTag("LDRUMCounter"))
        {
            maxMirror = stageMirrorCounter.LDRUMirrorCount;
        }
        else if (this.gameObject.CompareTag("LURDMCounter"))
        {
            maxMirror = stageMirrorCounter.LURDMirrorCount;
        }
    }

    private void Update()
    {
        // �ݒu����ɂȂ��Ă��Ȃ���ΐ��F�A�Ȃ��Ă���ΊD�F
        if(maxMirror > 0)
        {
            if(GameManager.worldState == 0)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 255, 255);
            }
            else if(GameManager.worldState == 1)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
            }
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = new Color32(128, 128, 128, 255);
        }
    }
}
