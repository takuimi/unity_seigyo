using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyManager : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    public GameObject goal;
    public Image energyBar;
    public Text pointText;
    public TextMeshProUGUI pointResultO;
    public TextMeshProUGUI pointResultC;
    public GameObject axis_displacement;
    public GameObject axis_speed;
    public GameObject axis_acceleration;
    public GameObject gameOverCanvas;
    public GameObject gameClearCanvas;
    public float TargetOfError = 1f;

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

    public float displacementDiff { get; private set; }

    private float speedAngle = 0f;
    private float accelerationAngle = 0f;

    private float RemainingEnergy = 1f;

    private float pointBuffer = 0f;
    private int point = 0;

    private bool hasTouched = false;
    private bool GameClaer = false;

    void Start()
    {
        if (player != null && target != null)
        {
            prevPlayerPos = player.transform.position;
            prevTargetPos = target.transform.position;
        }

        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false);
        }

        if (gameClearCanvas != null)
        {
            gameClearCanvas.SetActive(false);
        }
    }

    void Update()
    {
        if (player == null || target == null) return;

        float deltaTime = Time.deltaTime;
        if (deltaTime <= 0f) return;

        Vector3 currentPlayerPos = player.transform.position;
        Vector3 currentTargetPos = target.transform.position;

        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            hasTouched = true;
        }

        if (Vector3.Distance(player.transform.position, goal.transform.position) < 1.0f && !gameOverCanvas.activeSelf)
        {
            GameClaer = true;
        }

        if (hasTouched)
        {
            if (RemainingEnergy <= -1f && gameOverCanvas != null && !gameOverCanvas.activeSelf)
            {
                gameOverCanvas.SetActive(true);
                pointResultO.text = "Point: " + point.ToString();
            }
            else if (GameClaer)
            {
                if (gameClearCanvas != null && !gameClearCanvas.activeSelf)
                {
                    gameClearCanvas.SetActive(true);
                    pointResultC.text = "Point: " + point.ToString();
                }
            }
            else
            {
                Vector3 rawPlayerVel = (currentPlayerPos - prevPlayerPos) / deltaTime;
                Vector3 rawTargetVel = (currentTargetPos - prevTargetPos) / deltaTime;

                playerVelocity = pointSmoothingFactorL * playerVelocity + (1f - pointSmoothingFactorL) * rawPlayerVel;
                targetVelocity = pointSmoothingFactorL * targetVelocity + (1f - pointSmoothingFactorL) * rawTargetVel;

                Vector3 rawPlayerAcc = (playerVelocity - prevPlayerVelocity) / deltaTime;
                Vector3 rawTargetAcc = (targetVelocity - prevTargetVelocity) / deltaTime;

                playerAcceleration = pointSmoothingFactorL * playerAcceleration + (1f - pointSmoothingFactorL) * rawPlayerAcc;
                targetAcceleration = pointSmoothingFactorL * targetAcceleration + (1f - pointSmoothingFactorL) * rawTargetAcc;

                float playerSpeed = playerVelocity.magnitude;
                float targetSpeed = targetVelocity.magnitude;
                float accelerationDiff = playerAcceleration.magnitude - targetAcceleration.magnitude;

                // ★ displacementDiff を x座標の差に変更
                displacementDiff = target.transform.position.x - player.transform.position.x;

                float speedDiff = playerSpeed - targetSpeed;

                float clamped_displacementDiff = Mathf.Clamp(displacementDiff, -10f, 10f);
                float displacementAngle = Mathf.Lerp(-90f, 90f, (clamped_displacementDiff + 10f) / 20f);
                axis_displacement.transform.localEulerAngles = new Vector3(0f, 0f, displacementAngle);

                float clamped_speedDiff = Mathf.Clamp(speedDiff, -10f, 10f);
                float rawspeedAngle = Mathf.Lerp(-90f, 90f, (clamped_speedDiff + 10f) / 20f);
                speedAngle = pointSmoothingFactorM * speedAngle + (1f - pointSmoothingFactorM) * rawspeedAngle;
                axis_speed.transform.localEulerAngles = new Vector3(0f, 0f, speedAngle);

                float clamped_accelerationDiff = Mathf.Clamp(accelerationDiff, -10f, 10f);
                float rawaccelerationAngle = Mathf.Lerp(-90f, 90f, (clamped_accelerationDiff + 10f) / 20f);
                accelerationAngle = pointSmoothingFactorL * accelerationAngle + (1f - pointSmoothingFactorL) * rawaccelerationAngle;
                axis_acceleration.transform.localEulerAngles = new Vector3(0f, 0f, accelerationAngle);

                float DegreeOfError = Mathf.Abs(1f * displacementDiff + 0f * speedDiff + 0f * accelerationDiff);

                RemainingEnergy += (TargetOfError - DegreeOfError) * Time.deltaTime * 0.1f;
                RemainingEnergy = Mathf.Clamp(RemainingEnergy, -1f, 1f);

                if (energyBar != null)
                {
                    energyBar.fillAmount = RemainingEnergy;
                }

                float PointGain = RemainingEnergy * deltaTime * 100f;
                pointBuffer += PointGain;

                if (pointBuffer >= 1f)
                {
                    int gained = Mathf.FloorToInt(pointBuffer);
                    point += gained;
                    pointBuffer -= gained;
                }
            }
        }

        pointText.text = "Point: " + point.ToString();

        prevPlayerPos = currentPlayerPos;
        prevTargetPos = currentTargetPos;
        prevPlayerVelocity = playerVelocity;
        prevTargetVelocity = targetVelocity;
    }
}
