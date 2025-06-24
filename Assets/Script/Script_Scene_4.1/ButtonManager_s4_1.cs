using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonManager_s4_1 : MonoBehaviour
{
    private int impulseScale;
    public TextMeshProUGUI gainText;

    void Start()
    {
        // 初期読み込み。値が存在しなければ1を使用。
        if (!PlayerPrefs.HasKey("DateImpulseScale"))
        {
            PlayerPrefs.SetInt("DateImpulseScale", 1);
        }

        impulseScale = PlayerPrefs.GetInt("DateImpulseScale");
        UpdateGainText();
    }

    public void IncreaseGain()
    {
        if (impulseScale < 10)
        {
            impulseScale++;
            UpdateGainText();
        }
    }

    public void DecreaseGain()
    {
        if (impulseScale > 0)
        {
            impulseScale--;
            UpdateGainText();
        }
    }

    void UpdateGainText()
    {
        if (gainText != null)
        {
            gainText.text = $"×{impulseScale}";
        }
    }

    public void LoadScene5()
    {
        // シーン遷移前に保存
        PlayerPrefs.SetInt("DateImpulseScale", impulseScale);
        PlayerPrefs.Save();
        SceneManager.LoadScene("scene_5");
    }
}
