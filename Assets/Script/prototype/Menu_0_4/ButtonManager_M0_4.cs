using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonManager_M_0_4 : MonoBehaviour
{
    private int Kp;
    public TextMeshProUGUI gainText_K_p;

    void Start()
    {
        // 初期値が保存されていない場合は1に設定
        if (!PlayerPrefs.HasKey("DateK_p")) PlayerPrefs.SetInt("DateK_p", 1);

        // 保存された値を読み込む
        Kp = PlayerPrefs.GetInt("DateK_p");

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

    // UIテキストにゲインを反映
    void UpdateGainText()
    {
        if (gainText_K_p != null)
        {
            gainText_K_p.text = $"×{Kp}";
        }
    }

    // シーン遷移時に設定値を保存
    public void LoadStage_0_4()
    {
        PlayerPrefs.SetInt("DateK_p", Kp);
        PlayerPrefs.Save(); // 明示的に保存

        SceneManager.LoadScene("Stage_0_4");
    }
}