using UnityEngine;
using TMPro;

public class PlayerController_Stage_0_2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private int stepScale;
    private bool hasTouched = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stepScale = PlayerPrefs.GetInt("DateStepScale", 1);
        Debug.Log("読み込んだステップゲイン: " + stepScale);
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
