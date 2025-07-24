using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonManager_M_0_2 : MonoBehaviour
{
    private int stepScale;
    public TextMeshProUGUI gainText;

    void Start()
    {
        // 初期読み込み。値が存在しなければ1を使用。
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
            gainText.text = $"×{stepScale}";
        }
    }

    public void LoadStage_0_2()
    {
        // シーン遷移前に保存
        PlayerPrefs.SetInt("DateStepScale", stepScale);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Stage_0_2");
    }
}
