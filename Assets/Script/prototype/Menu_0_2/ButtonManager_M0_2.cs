using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonManager_M_0_2 : MonoBehaviour
{
    private int stepScale;
    public TextMeshProUGUI gainText;

    void Start()
    {
        // �����ǂݍ��݁B�l�����݂��Ȃ����1���g�p�B
        if (!PlayerPrefs.HasKey("DateStepScale"))
        {
            PlayerPrefs.SetInt("DateStepScale", 1);
        }

        stepScale = PlayerPrefs.GetInt("DateStepScale");
        UpdateGainText();
    }

    public void IncreaseGain()
    {
        if (stepScale < 10)
        {
            stepScale++;
            UpdateGainText();
        }
    }

    public void DecreaseGain()
    {
        if (stepScale > 0)
        {
            stepScale--;
            UpdateGainText();
        }
    }

    void UpdateGainText()
    {
        if (gainText != null)
        {
            gainText.text = $"�~{stepScale}";
        }
    }

    public void LoadStage_0_2()
    {
        // �V�[���J�ڑO�ɕۑ�
        PlayerPrefs.SetInt("DateStepScale", stepScale);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Stage_0_2");
    }
}
