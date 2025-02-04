using UnityEngine;
using System.Collections;

public class ObjectDrag : MonoBehaviour
{
    public void OnMouseDrag()
    {
        // �}�E�X�J�[�\���y�уI�u�W�F�N�g�̃X�N���[�����W���擾
        Vector3 objectScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);

        // �X�N���[�����W�����[���h���W�ɕϊ�
        Vector3 objectworldPoint = Camera.main.ScreenToWorldPoint(objectScreenPoint);

        // �I�u�W�F�N�g�̍��W��ύX����
        transform.position = objectworldPoint;
    }
}
