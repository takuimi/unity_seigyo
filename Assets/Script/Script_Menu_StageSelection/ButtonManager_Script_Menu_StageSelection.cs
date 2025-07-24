using UnityEngine;
using UnityEngine.UI;

public class DescriptionManager_Menu_StageSerection : MonoBehaviour
{
    public Button[] stageButtons = new Button[12];
    public GameObject[] stageDescriptions = new GameObject[12];

    private int currentStageIndex = -1;

    private void Start()
    {
        // �{�^���̃N���b�N�C�x���g��ݒ�
        for (int i = 0; i < stageButtons.Length; i++)
        {
            int index = i; // �N���[�W���΍�
            stageButtons[i].onClick.AddListener(() => SelectStage(index));
        }

        // �������őS�Ĕ�\����
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
