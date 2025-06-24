using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraManager : MonoBehaviour
{
    public float leftLimit = 0.0f;    // ���X�N���[�����~�b�g
    public float rightLimit = 0.0f;   // �E�X�N���[�����~�b�g
    public float topLimit = 0.0f;     // ��X�N���[�����~�b�g
    public float bottomLimit = 0.0f;  // ���X�N���[�����~�b�g

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // �v���C���[��T��
        if (player != null)
        {
            // �J�����̍X�V���W
            float x = player.transform.position.x;
            float y = player.transform.position.y;
            float z = transform.position.z;

            // ������������
            // ���[�Ɉړ�������t����
            if (x < leftLimit)
            {
                x = leftLimit;
            }
            else if (x > rightLimit)
            {
                x = rightLimit;
            }

            // �c����������
            // �㉺�Ɉړ�������t����
            if (y < bottomLimit)
            {
                y = bottomLimit;
            }
            else if (y > topLimit)
            {
                y = topLimit;
            }

            // �J�����ʒu�� Vector3 �����
            Vector3 v3 = new Vector3(x, y, z);
            transform.position = v3;
        }
    }
}
