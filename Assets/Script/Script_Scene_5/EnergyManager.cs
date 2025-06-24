using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    public Image energyBar;
    public Text pointText;
    public GameObject axis_displacement;
    public GameObject axis_speed;
    public GameObject axis_acceleration;
    public float maxLosePoint = 100f;

    [Range(0.1f, 1f)]
    public float pointSmoothingFactorS = 0.1f; // α
    [Range(0.1f, 1f)]
    public float pointSmoothingFactorM = 0.1f; // α
    [Range(0.1f, 1f)]
    public float pointSmoothingFactorL = 0.1f; // α

    private Vector3 prevPlayerPos;
    private Vector3 prevTargetPos;

    public Vector3 playerVelocity = Vector3.zero;
    private Vector3 targetVelocity = Vector3.zero;

    private Vector3 prevPlayerVelocity = Vector3.zero;
    private Vector3 prevTargetVelocity = Vector3.zero;

    private Vector3 playerAcceleration = Vector3.zero;
    private Vector3 targetAcceleration = Vector3.zero;

    private float playerDisplacement = 0f;
    private float targetDisplacement = 0f;

    private float speedAngle = 0f;
    private float accelerationAngle = 0f;

    private float losePoint = 0f;
    private float rawRemainingEnergy = 1f;
    private float filteredRemainingEnergy = 1f;

    private float pointBuffer = 0f;
    private int point = 0;

    private bool hasTouched = false;

    void Start()
    {
        if (player != null && target != null)
        {
            prevPlayerPos = player.transform.position;
            prevTargetPos = target.transform.position;
        }
    }

    void Update()
    {
        if (player == null || target == null) return;

        float deltaTime = Time.deltaTime;
        if (deltaTime <= 0f) return;

        Vector3 currentPlayerPos = player.transform.position;
        Vector3 currentTargetPos = target.transform.position;

        // 疑似微分で速度計算（ローパスフィルター付き）
        Vector3 rawPlayerVel = (currentPlayerPos - prevPlayerPos) / deltaTime;
        Vector3 rawTargetVel = (currentTargetPos - prevTargetPos) / deltaTime;

        playerVelocity = pointSmoothingFactorL * playerVelocity + (1f - pointSmoothingFactorL) * rawPlayerVel;
        targetVelocity = pointSmoothingFactorL * targetVelocity + (1f - pointSmoothingFactorL) * rawTargetVel;

        // 疑似微分で加速度計算（ローパスフィルター付き）
        Vector3 rawPlayerAcc = (playerVelocity - prevPlayerVelocity) / deltaTime;
        Vector3 rawTargetAcc = (targetVelocity - prevTargetVelocity) / deltaTime;

        playerAcceleration = pointSmoothingFactorL * playerAcceleration + (1f - pointSmoothingFactorL) * rawPlayerAcc;
        targetAcceleration = pointSmoothingFactorL * targetAcceleration + (1f - pointSmoothingFactorL) * rawTargetAcc;

        // 累積変位
        playerDisplacement += Vector3.Distance(currentPlayerPos, prevPlayerPos);
        targetDisplacement += Vector3.Distance(currentTargetPos, prevTargetPos);

        float playerSpeed = playerVelocity.magnitude;
        float targetSpeed = targetVelocity.magnitude;
        float accelerationDiff = playerAcceleration.magnitude - targetAcceleration.magnitude;

        float displacementDiff = playerDisplacement - targetDisplacement;
        float speedDiff = playerSpeed - targetSpeed;


        //axis_displacementを回転する際の範囲を制限する(UIの距離メータの制御)
        float clamped_displacementDiff = Mathf.Clamp(displacementDiff, -10f, 10f);
        //-10 → -90°, 0 → 0°, 10 → 90° にマッピング
        float displacementAngle = Mathf.Lerp(-90f, 90f, (clamped_displacementDiff + 10f) / 20f);
        //Z軸回転
        axis_displacement.transform.localEulerAngles = new Vector3(0f, 0f, displacementAngle);

        //axis_speedを回転する際の範囲を制限する(UIの距離メータの制御)
        float clamped_speedDiff = Mathf.Clamp(speedDiff, -10f, 10f);
        //-10 → -90°, 0 → 0°, 10 → 90° にマッピング
        float rawspeedAngle = Mathf.Lerp(-90f, 90f, (clamped_speedDiff + 10f) / 20f);
        //スムージング
        speedAngle = pointSmoothingFactorM * speedAngle + (1f - pointSmoothingFactorM) * rawspeedAngle;
        //Z軸回転
        axis_speed.transform.localEulerAngles = new Vector3(0f, 0f, speedAngle);

        //axis_accelerationを回転する際の範囲を制限する(UIの距離メータの制御)
        float clamped_accelerationDiff = Mathf.Clamp(accelerationDiff, -10f, 10f);
        //-10 → -90°, 0 → 0°, 10 → 90° にマッピング
        float rawaccelerationAngle = Mathf.Lerp(-90f, 90f, (clamped_accelerationDiff + 10f) / 20f);
        //スムージング
        accelerationAngle = pointSmoothingFactorL * accelerationAngle + (1f - pointSmoothingFactorL) * rawaccelerationAngle;
        //Z軸回転
        axis_acceleration.transform.localEulerAngles = new Vector3(0f, 0f, accelerationAngle);

       // 画面タッチまたはクリックを検出（PC / スマホ両対応）
       if ((Input.GetMouseButtonDown(0) || Input.touchCount > 0))
       {
             hasTouched = true;
        }
        if (hasTouched)
        {
            // エネルギー減少ポイント
            losePoint = Mathf.Abs(1f * displacementDiff + 0.5f * speedDiff + 0.1f * accelerationDiff);

            // エネルギー残量（生値）
            rawRemainingEnergy = Mathf.Clamp01(1f - (losePoint / maxLosePoint));

            // エネルギーバー更新
            if (energyBar != null)
            {
                // 追加：スムージング
                filteredRemainingEnergy = pointSmoothingFactorM * filteredRemainingEnergy + (1f - pointSmoothingFactorM) * rawRemainingEnergy;

                // 使用：こちらを使う
                energyBar.fillAmount = filteredRemainingEnergy;
            }

            // ポイント加算処理
            float PointGain = rawRemainingEnergy * deltaTime * 10f;
            pointBuffer += PointGain;

            if (pointBuffer >= 1f)
            {
                int gained = Mathf.FloorToInt(pointBuffer);
                point += gained;
                pointBuffer -= gained;
            }
        }
        
     

        pointText.text = "Point: " + point.ToString();

        // 前回の値更新
        prevPlayerPos = currentPlayerPos;
        prevTargetPos = currentTargetPos;
        prevPlayerVelocity = playerVelocity;
        prevTargetVelocity = targetVelocity;
    }
}