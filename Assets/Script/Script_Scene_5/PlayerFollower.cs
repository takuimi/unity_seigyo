using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public GameObject ball;       // BallオブジェクトをInspectorで指定
    [Tooltip("Ballからy軸上のオフセット量")]
    public float yOffset_player = 33f;   // Ballの真上に表示するオフセット量

    void Update()
    {
        if (ball != null)
        {
            Vector3 ballPos = ball.transform.position;
            transform.position = new Vector3(ballPos.x, ballPos.y + yOffset_player, 0f); // z = 0に固定
        }
    }
}
