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
        // 初期値が保存されていない場合は1に設定
        if (!PlayerPrefs.HasKey("DateK_p")) PlayerPrefs.SetInt("DateK_p", 1);
        if (!PlayerPrefs.HasKey("DateK_i")) PlayerPrefs.SetInt("DateK_i", 1);

        // 保存された値を読み込む
        Kp = PlayerPrefs.GetInt("DateK_p");
        Ki = PlayerPrefs.GetInt("DateK_i");

        UpdateGainText();
    }

    // Kpの増減
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

    // Kiの増減
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

    // UIテキストにゲインを反映
    void UpdateGainText()
    {
        if (gainText_K_p != null && gainText_K_i != null)
        {
            gainText_K_p.text = $"×{Kp}";
            gainText_K_i.text = $"×{Ki}";
        }
    }

    // シーン遷移時に設定値を保存
    public void LoadStage_0_5()
    {
        PlayerPrefs.SetInt("DateK_p", Kp);
        PlayerPrefs.SetInt("DateK_i", Ki);
        PlayerPrefs.Save(); // 明示的に保存

        SceneManager.LoadScene("Stage_0_5");
    }
}