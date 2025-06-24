using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonManager_s5 : MonoBehaviour
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

    public void LoadPauseScene()
    {
        Debug.Log("Scene_4.1 に戻ります");
        SceneManager.LoadScene("Scene_4.1");
    }
}
