using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    public GameObject targetBall;  // TargetBallオブジェクトをInspectorで指定
    [Tooltip("TargetBallからy軸上のオフセット量")]
    public float yOffset_target = 33f;   // TargetBallの真上に表示するオフセット量

    void Update()
    {
        if (targetBall != null)
        {
            Vector3 targetPos = targetBall.transform.position;
            transform.position = new Vector3(targetPos.x, targetPos.y + yOffset_target, 0f); // z = 0
        }
    }
}
