using UnityEngine;

public class TargetBall_s_0_2 : MonoBehaviour
{
    [Header("�X�e�b�v���͂̑傫���i�͂̑傫���j")]
    [Tooltip("���̗͂𖈃t���[��������")]
    public int stepScale = 1;

    private bool hasTouched = false;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �^�b�`���ꂽ��X�e�b�v���͂��J�n
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
