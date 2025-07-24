using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonManager_M_0_3 : MonoBehaviour
{
    private int rampGain;
    public TextMeshProUGUI gainText;

    void Start()
    {
        // 初期読み込み。値が存在しなければ1を使用。
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
            gainText.text = $"×{rampGain}";
        }
    }

    public void LoadStage_0_3()
    {
        // シーン遷移前に保存
        PlayerPrefs.SetInt("DateRampGain", rampGain);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Stage_0_3");
    }
}

