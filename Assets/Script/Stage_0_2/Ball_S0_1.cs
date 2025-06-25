using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private int impulseScale;
    private bool hasMoved = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        impulseScale = PlayerPrefs.GetInt("DateImpulseScale", 1);
        Debug.Log("読み込んだゲイン: " + impulseScale);
    }

    void Update()
    {
        // 画面タッチまたはクリックを検出（PC / スマホ両対応）
        if (!hasMoved && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            Vector2 F_player_impulse = new Vector2(1f * impulseScale, 0f);
            rb.AddForce(F_player_impulse, ForceMode2D.Impulse);
            hasMoved = true;
        }
    }
}