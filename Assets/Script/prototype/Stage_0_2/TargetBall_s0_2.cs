using UnityEngine;

public class TargetBall_s_0_2 : MonoBehaviour
{
    [Header("ステップ入力の大きさ（力の大きさ）")]
    [Tooltip("一定の力を毎フレーム加える")]
    public int stepScale = 1;

    private bool hasTouched = false;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // タッチされたらステップ入力を開始
        if (!hasTouched && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            hasTouched = true;
}
    }

    void FixedUpdate()
    {
        if (hasTouched)
        {
            rb.AddForce(new Vector2(stepScale, 0f), ForceMode2D.Force);
        }
    }
}
