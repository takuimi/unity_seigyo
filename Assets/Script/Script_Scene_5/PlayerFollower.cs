using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public GameObject ball;       // Ball�I�u�W�F�N�g��Inspector�Ŏw��
    [Tooltip("Ball����y����̃I�t�Z�b�g��")]
    public float yOffset_player = 33f;   // Ball�̐^��ɕ\������I�t�Z�b�g��

    void Update()
    {
        if (ball != null)
        {
            Vector3 ballPos = ball.transform.position;
            transform.position = new Vector3(ballPos.x, ballPos.y + yOffset_player, 0f); // z = 0�ɌŒ�
        }
    }
}
