using UnityEngine;
using UnityEngine.UI;

public class DescriptionManager_Menu_StageSerection : MonoBehaviour
{
    public Button[] stageButtons = new Button[12];
    public GameObject[] stageDescriptions = new GameObject[12];

    private int currentStageIndex = -1;

    private void Start()
    {
        // ボタンのクリックイベントを設定
        for (int i = 0; i < stageButtons.Length; i++)
        {
            int index = i; // クロージャ対策
            stageButtons[i].onClick.AddListener(() => SelectStage(index));
        }

        // 初期化で全て非表示に
        HideAllStages();
    }

    private void SelectStage(int stageIndex)
    {
        currentStageIndex = stageIndex;
        ShowSelectedStage();
    }

    private void ShowSelectedStage()
    {
        HideAllStages();

        if (currentStageIndex >= 0 && currentStageIndex < stageDescriptions.Length)
        {
            stageDescriptions[currentStageIndex].SetActive(true);
        }
    }

    private void HideAllStages()
    {
        foreach (var desc in stageDescriptions)
        {
            if (desc != null)
                desc.SetActive(false);
        }
    }
}
