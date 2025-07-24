using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonManager_M_0_3 : MonoBehaviour
{
    private int rampGain;
    public TextMeshProUGUI gainText;

    void Start()
    {
        // �����ǂݍ��݁B�l�����݂��Ȃ����1���g�p�B
        if (!PlayerPrefs.HasKey("DateRampGain"))
        {
            PlayerPrefs.SetInt("DateRampGain", 1);
        }

        rampGain = PlayerPrefs.GetInt("DateRampGain");
        UpdateGainText();
    }

    public void IncreaseGain()
    {
        if (rampGain < 10)
        {
            rampGain++;
            UpdateGainText();
        }
    }

    public void DecreaseGain()
    {
        if (rampGain > 0)
        {
            rampGain--;
            UpdateGainText();
        }
    }

    void UpdateGainText()
    {
        if (gainText != null)
        {
            gainText.text = $"�~{rampGain}";
        }
    }

    public void LoadStage_0_3()
    {
        // �V�[���J�ڑO�ɕۑ�
        PlayerPrefs.SetInt("DateRampGain", rampGain);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Stage_0_3");
    }
}

