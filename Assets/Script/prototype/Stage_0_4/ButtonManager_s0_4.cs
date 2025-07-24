using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonManager_s0_4 : MonoBehaviour
{
    public GameObject startText;  // 画面中央のスタートテキストをInspectorで登録

    private bool hasTouched = false;

    void Update()
    {
        if (!hasTouched && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            hasTouched = true;

            if (startText != null)
            {
                startText.SetActive(false); // スタートテキストを非表示にする
            }

            // 必要であればこのあとに処理を追加（例：ゲーム開始処理）
        }
    }

    public void BackButton()
    {
        Debug.Log("Menu_0_4 に戻ります");
        SceneManager.LoadScene("Menu_0_4");
    }

    public void NextButton()
    {
        Debug.Log("Menu_0_5 に進みます");
        SceneManager.LoadScene("Menu_0_5");
    }
}