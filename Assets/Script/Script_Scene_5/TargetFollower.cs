using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    public GameObject targetBall;  // TargetBall�I�u�W�F�N�g��Inspector�Ŏw��
    [Tooltip("TargetBall����y����̃I�t�Z�b�g��")]
    public float yOffset_target = 33f;   // TargetBall�̐^��ɕ\������I�t�Z�b�g��

    void Update()
    {
        if (targetBall != null)
        {
            Vector3 targetPos = targetBall.transform.position;
            transform.position = new Vector3(targetPos.x, targetPos.y + yOffset_target, 0f); // z = 0
        }
    }
}
