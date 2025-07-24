using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonManager_M_0_4 : MonoBehaviour
{
    private int Kp;
    public TextMeshProUGUI gainText_K_p;

    void Start()
    {
        // �����l���ۑ�����Ă��Ȃ��ꍇ��1�ɐݒ�
        if (!PlayerPrefs.HasKey("DateK_p")) PlayerPrefs.SetInt("DateK_p", 1);

        // �ۑ����ꂽ�l��ǂݍ���
        Kp = PlayerPrefs.GetInt("DateK_p");

        UpdateGainText();
    }

    // Kp�̑���
    public void IncreaseGainKp()
    {
        if (Kp < 10)
        {
            Kp++;
            UpdateGainText();
        }
    }

    public void DecreaseGainKp()
    {
        if (Kp > 0)
        {
            Kp--;
            UpdateGainText();
        }
    }

    // UI�e�L�X�g�ɃQ�C���𔽉f
    void UpdateGainText()
    {
        if (gainText_K_p != null)
        {
            gainText_K_p.text = $"�~{Kp}";
        }
    }

    // �V�[���J�ڎ��ɐݒ�l��ۑ�
    public void LoadStage_0_4()
    {
        PlayerPrefs.SetInt("DateK_p", Kp);
        PlayerPrefs.Save(); // �����I�ɕۑ�

        SceneManager.LoadScene("Stage_0_4");
    }
}