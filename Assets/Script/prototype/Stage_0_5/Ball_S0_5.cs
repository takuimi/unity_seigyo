using UnityEngine;

public class PlayerController_Stage_0_5 : MonoBehaviour
{
    private Rigidbody2D rb;
    private int Kp, Ki, Kd;
    private float integral = 0f;
    private float previousError = 0f;

    private Transform targetTransform; // TargetオブジェクトのTransform
    private Transform playerTransform;
    private bool isPIDActive = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Targetオブジェクトを名前で検索してTransform取得
        GameObject targetObject = GameObject.Find("Target");
        GameObject playerObject = GameObject.Find("Player");
        if (targetObject != null && playerObject != null)
        {
            targetTransform = targetObject.transform;
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogError("TargetまたはPlayerオブジェクトが見つかりません。");
        }

        // PIDゲインの取得（なければデフォルト値）
        Kp = PlayerPrefs.GetInt("DateK_p", 1);
        Ki = PlayerPrefs.GetInt("DateK_i", 0);
        Kd = PlayerPrefs.GetInt("DateK_d", 0);

        Debug.Log($"PIDゲイン: Kp={Kp}, Ki={Ki}, Kd={Kd}");
    }

    void Update()
    {
        if (!isPIDActive && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            isPIDActive = true;
        }

        if (isPIDActive && targetTransform != null)
        {
            ApplyPIDControl();
        }
    }

    void ApplyPIDControl()
    {
        float error = targetTransform.position.x - playerTransform.position.x;
        float deltaTime = Time.deltaTime;

        integral += error * deltaTime;
        float derivative = (error - previousError) / deltaTime;

        float output = Kp * error + Ki * integral;

        rb.AddForce(new Vector2(output, 0f), ForceMode2D.Force);

        previousError = error;
    }
}