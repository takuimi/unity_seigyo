using UnityEngine;

public class PlayerController_Stage_0_3 : MonoBehaviour
{
    private Rigidbody2D rb;
    private int rampGain;
    private bool hasTouched = false;
    private float timeSinceStart = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rampGain = PlayerPrefs.GetInt("DateRampGain", 1);
        Debug.Log("読み込んだランプゲイン: " + rampGain);
    }

    void Update()
    {
        if (!hasTouched && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            hasTouched = true;
            timeSinceStart = 0f;
        }
    }

    void FixedUpdate()
    {
        if (hasTouched)
        {
            timeSinceStart += Time.fixedDeltaTime;
            float force_ramp = rampGain * timeSinceStart;
            rb.AddForce(new Vector2(force_ramp, 0f), ForceMode2D.Force);
        }
    }
}
