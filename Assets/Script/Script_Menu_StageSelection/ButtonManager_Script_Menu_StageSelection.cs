using UnityEngine;
using UnityEngine.UI;

public class DescriptionManager : MonoBehaviour
{
    public Button Stage_0_1;
    public Button Stage_0_2;
    public Button Stage_0_3;
    public Button Stage_0_4;
    public Button Stage_0_5;
    public Button Stage_0_6;
    public Button Stage_0_7;
    public Button Stage_0_8; 
    public Button Stage_0_9;
    public Button Stage_0_10; 
    public Button Stage_0_11;
    public Button Stage_0_12;

    public GameObject show_Stage_0_1;
    public GameObject show_Stage_0_2;
    public GameObject show_Stage_0_3;
    public GameObject show_Stage_0_4;
    public GameObject show_Stage_0_5;
    public GameObject show_Stage_0_6;
    public GameObject show_Stage_0_7;
    public GameObject show_Stage_0_8;
    public GameObject show_Stage_0_9;
    public GameObject show_Stage_0_10;
    public GameObject show_Stage_0_11;
    public GameObject show_Stage_0_12;

    private SelectedStage currentStage = SelectedStage.None;

    private enum SelectedStage
    {
        None,
        Stage_0_1,
        Stage_0_2,
        Stage_0_3,
        Stage_0_4,
        Stage_0_5,
        Stage_0_6,
        Stage_0_7,
        Stage_0_8,
        Stage_0_9,
        Stage_0_10,
        Stage_0_11,
        Stage_0_12
    }

    private void SelectStage(SelectedStage stage)
    {
        currentStage = stage;
        ShowSelectedStage();
    }

    void Start()
    {
        Stage_0_1.onClick.AddListener(() => SelectStage(SelectedStage.Stage_0_1));
        Stage_0_2.onClick.AddListener(() => SelectStage(SelectedStage.Stage_0_2));
        Stage_0_3.onClick.AddListener(() => SelectStage(SelectedStage.Stage_0_3));
        Stage_0_4.onClick.AddListener(() => SelectStage(SelectedStage.Stage_0_4));
        Stage_0_5.onClick.AddListener(() => SelectStage(SelectedStage.Stage_0_5));
        Stage_0_6.onClick.AddListener(() => SelectStage(SelectedStage.Stage_0_6));
        Stage_0_7.onClick.AddListener(() => SelectStage(SelectedStage.Stage_0_7));
        Stage_0_8.onClick.AddListener(() => SelectStage(SelectedStage.Stage_0_8));
        Stage_0_9.onClick.AddListener(() => SelectStage(SelectedStage.Stage_0_9));
        Stage_0_10.onClick.AddListener(() => SelectStage(SelectedStage.Stage_0_10));
        Stage_0_11.onClick.AddListener(() => SelectStage(SelectedStage.Stage_0_11));
        Stage_0_12.onClick.AddListener(() => SelectStage(SelectedStage.Stage_0_12));

        //‚·‚×‚Ä‚ð”ñ•\Ž¦‚É‚µ‚Ä‚¨‚­
        HideAllStages();
    }

    private void ShowSelectedStage()
    {
        HideAllStages();

        switch (currentStage)
        {
            case SelectedStage.Stage_0_1:
                show_Stage_0_1.SetActive(true);
                break;
            case SelectedStage.Stage_0_2:
                show_Stage_0_2.SetActive(true);
                break;
            case SelectedStage.Stage_0_3:
                show_Stage_0_3.SetActive(true);
                break;
            case SelectedStage.Stage_0_4:
                show_Stage_0_4.SetActive(true);
                break;
            case SelectedStage.Stage_0_5:
                show_Stage_0_5.SetActive(true);
                break;
            case SelectedStage.Stage_0_6:
                show_Stage_0_6.SetActive(true);
                break;
            case SelectedStage.Stage_0_7:
                show_Stage_0_7.SetActive(true);
                break;
            case SelectedStage.Stage_0_8:
                show_Stage_0_8.SetActive(true);
                break;
            case SelectedStage.Stage_0_9:
                show_Stage_0_9.SetActive(true);
                break;
            case SelectedStage.Stage_0_10:
                show_Stage_0_10.SetActive(true);
                break;
            case SelectedStage.Stage_0_11:
                show_Stage_0_11.SetActive(true);
                break;
            case SelectedStage.Stage_0_12:
                show_Stage_0_12.SetActive(true);
                break;
        }
    }

    private void HideAllStages()
    {
        show_Stage_0_1.SetActive(false);
        show_Stage_0_2.SetActive(false);
        show_Stage_0_3.SetActive(false);
        show_Stage_0_4.SetActive(false);
        show_Stage_0_5.SetActive(false);
        show_Stage_0_6.SetActive(false);
        show_Stage_0_7.SetActive(false);
        show_Stage_0_8.SetActive(false);
        show_Stage_0_9.SetActive(false);
        show_Stage_0_10.SetActive(false);
        show_Stage_0_11.SetActive(false);
        show_Stage_0_12.SetActive(false);
    }
}
