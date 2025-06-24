using UnityEngine;
using TMPro;

public class TargetController : MonoBehaviour
{
    [Header("インパルスの積分値（=速度変化）")]
    [Tooltip("インパルスの強さを整数で指定（1以上）")]
    public int impulseScale = 1;
    private bool hasMoved = false;

    public TextMeshProUGUI velocityText;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hasMoved && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            // impulseScaleに応じたインパルス入力を作成
            Vector2 F_target_impulse = new Vector2(1f * impulseScale, 0f); // 1N·s × 倍率
            // 単位インパルス（ForceMode2D.Impulseで一瞬の加速）
            rb.AddForce(F_target_impulse, ForceMode2D.Impulse);
            hasMoved = true;
        }
    }
}
