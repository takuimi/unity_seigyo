using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonManager_M_0_6 : MonoBehaviour
{
    private int Kp, Ki, Kd;
    public TextMeshProUGUI gainText_K_p;
    public TextMeshProUGUI gainText_K_i;
    public TextMeshProUGUI gainText_K_d;

    void Start()
    {
        // 初期値が保存されていない場合は1に設定
        if (!PlayerPrefs.HasKey("DateK_p")) PlayerPrefs.SetInt("DateK_p", 1);
        if (!PlayerPrefs.HasKey("DateK_i")) PlayerPrefs.SetInt("DateK_i", 1);
        if (!PlayerPrefs.HasKey("DateK_d")) PlayerPrefs.SetInt("DateK_d", 1);

        // 保存された値を読み込む
        Kp = PlayerPrefs.GetInt("DateK_p");
        Ki = PlayerPrefs.GetInt("DateK_i");
        Kd = PlayerPrefs.GetInt("DateK_d");

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

    // Kdの増減（関数名の修正）
    public void IncreaseGainKd()
    {
        if (Kd < 10)
        {
            Kd++;
            UpdateGainText();
        }
    }

    public void DecreaseGainKd()
    {
        if (Kd > 0)
        {
            Kd--;
            UpdateGainText();
        }
    }

    // UIテキストにゲインを反映
    void UpdateGainText()
    {
        if (gainText_K_p != null && gainText_K_i != null && gainText_K_d != null)
        {
            gainText_K_p.text = $"×{Kp}";
            gainText_K_i.text = $"×{Ki}";
            gainText_K_d.text = $"×{Kd}";
        }
    }

    // シーン遷移時に設定値を保存
    public void LoadStage_0_6()
    {
        PlayerPrefs.SetInt("DateK_p", Kp);
        PlayerPrefs.SetInt("DateK_i", Ki);
        PlayerPrefs.SetInt("DateK_d", Kd);
        PlayerPrefs.Save(); // 明示的に保存

        SceneManager.LoadScene("Stage_0_6");
    }
}
