using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonManager_M_0_5 : MonoBehaviour
{
    private int Kp, Ki;
    public TextMeshProUGUI gainText_K_p;
    public TextMeshProUGUI gainText_K_i;

    void Start()
    {
        // �����l���ۑ�����Ă��Ȃ��ꍇ��1�ɐݒ�
        if (!PlayerPrefs.HasKey("DateK_p")) PlayerPrefs.SetInt("DateK_p", 1);
        if (!PlayerPrefs.HasKey("DateK_i")) PlayerPrefs.SetInt("DateK_i", 1);

        // �ۑ����ꂽ�l��ǂݍ���
        Kp = PlayerPrefs.GetInt("DateK_p");
        Ki = PlayerPrefs.GetInt("DateK_i");

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

    // Ki�̑���
    public void IncreaseGainKi()
    {
        if (Ki < 10)
        {
            Ki++;
            UpdateGainText();
        }
    }

    public void DecreaseGainKi()
    {
        if (Ki > 0)
        {
            Ki--;
            UpdateGainText();
        }
    }

    // UI�e�L�X�g�ɃQ�C���𔽉f
    void UpdateGainText()
    {
        if (gainText_K_p != null && gainText_K_i != null)
        {
            gainText_K_p.text = $"�~{Kp}";
            gainText_K_i.text = $"�~{Ki}";
        }
    }

    // �V�[���J�ڎ��ɐݒ�l��ۑ�
    public void LoadStage_0_5()
    {
        PlayerPrefs.SetInt("DateK_p", Kp);
        PlayerPrefs.SetInt("DateK_i", Ki);
        PlayerPrefs.Save(); // �����I�ɕۑ�

        SceneManager.LoadScene("Stage_0_5");
    }
}