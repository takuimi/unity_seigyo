using UnityEngine;

public class TargetBall_s_0_3 : MonoBehaviour
{
    [Header("ƒ‰ƒ“ƒv“ü—Í‚Ì‘å‚«‚³i—Í‚ÌŒX‚«j")]
    public int rampGain = 1;

    private bool hasTouched = false;
    private float timeSinceStart = 0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
