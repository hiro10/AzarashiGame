using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    public float speed = 1f;
    public float startPosition;
    public float endPosition;

    /// <summary>
    /// �X�V����
    /// </summary>
    void Update()
    {
        //���t���[��x���W�������ړ�������
        transform.Translate(-1 * speed * Time.deltaTime, 0f, 0f);

        // �X�N���[�����ڕW�|�C���g�ɒB�������̃`�F�b�N
        if(transform.position.x<=endPosition)
        {
            ScrollEnd();
        }
    }

    private void ScrollEnd()
    {
        // �ʂ�߂���������������position�ݒ�
        float diff = transform.position.x - endPosition;
        Vector3 restartPosition = transform.position;
        restartPosition.x = startPosition + diff;
        transform.position = restartPosition;

        SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);
    }
}
