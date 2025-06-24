using UnityEngine;

public class BodyManager : MonoBehaviour
{
    [Header("初期位置に戻るための設定")]
    public float springStrength = 5f; // 復元力の強さ
    public float damping = 2f;        // 減衰力（揺れの収束）

    [Header("インパルス振動の設定")]
    public float impulseStrength = 1f;       // 振動の強さ（速度に応じてスケーリング）
    public float impulseInterval = 0.1f;     // インパルス発生の間隔

    [Header("速度入力")]
    public float playerVelocity = 0f;        // プレイヤーの速度（外部スクリプトから更新される）

    private Rigidbody rb;
    private Vector3 initialPosition;
    private float impulseTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        ApplySpringForce();
        ApplyRandomImpulse();
    }

    // 初期位置に戻すバネのような力
    void ApplySpringForce()
    {
        Vector3 displacement = initialPosition - transform.position;
        Vector3 springForce = displacement * springStrength;
        Vector3 dampingForce = -rb.linearVelocity * damping;

        rb.AddForce(springForce + dampingForce, ForceMode.Acceleration);
    }

    // ランダムなインパルスを速度に応じて発生させる
    void ApplyRandomImpulse()
    {
        impulseTimer += Time.fixedDeltaTime;
        if (impulseTimer >= impulseInterval)
        {
            impulseTimer = 0f;

            // プレイヤーの速度が速いほどインパルスも強くなる
            float scaledImpulse = playerVelocity * impulseStrength;

            // ランダムな方向にインパルスを加える（XZ平面のみの場合はY=0に）
            Vector3 randomDir = Random.onUnitSphere;
            randomDir.y = 0f;
            randomDir.Normalize();

            Vector3 impulse = randomDir * scaledImpulse;
            rb.AddForce(impulse, ForceMode.Impulse);
        }
    }
}
