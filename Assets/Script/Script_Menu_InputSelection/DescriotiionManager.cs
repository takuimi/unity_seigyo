using UnityEngine;
using UnityEngine.UI;

public class DescriptionManager : MonoBehaviour
{
    public GameObject explanation_ImpulseInput;
    public GameObject explanation_StepInput;
    public GameObject explanation_LumpInput;
    public GameObject explanation_PControl;
    public GameObject explanation_PIControl;
    public GameObject explanation_PIDControl;

    public Button impulseButton;
    public Button stepButton;
    public Button lumpButton;
    public Button PButton;
    public Button PIButton;
    public Button PIDButton;
    public Button explanationButton;
    public Button proceedButton;
    public Button hideButton1;
    public Button hideButton2;
    public Button hideButton3;
    public Button hideButton4;
    public Button hideButton5;
    public Button hideButton6;

    private enum SelectedInput
    {
        None,
        Impulse,
        Step,
        Lump,
        P,
        PI,
        PID
    }

    private SelectedInput currentSelection = SelectedInput.None;

    void Start()
    {
        // 各ボタンにリスナーを登録
        impulseButton.onClick.AddListener(SelectImpulse);
        stepButton.onClick.AddListener(SelectStep);
        lumpButton.onClick.AddListener(SelectLump);
        PButton.onClick.AddListener(SelectP);
        PIButton.onClick.AddListener(SelectPI);
        PIDButton.onClick.AddListener(SelectPID);

        explanationButton.onClick.AddListener(ShowExplanation);

        hideButton1.onClick.AddListener(HideExplanation);
        hideButton2.onClick.AddListener(HideExplanation);
        hideButton3.onClick.AddListener(HideExplanation);
        hideButton4.onClick.AddListener(HideExplanation);
        hideButton5.onClick.AddListener(HideExplanation);
        hideButton6.onClick.AddListener(HideExplanation);

        // 全ての説明を非表示にしておく
        HideExplanation();
    }

    public void SelectImpulse()
    {
        currentSelection = SelectedInput.Impulse;
        Debug.Log("Impulse selected");
    }

    public void SelectStep()
    {
        currentSelection = SelectedInput.Step;
        Debug.Log("Step selected");
    }

    public void SelectLump()
    {
        currentSelection = SelectedInput.Lump;
        Debug.Log("Lump selected");
    }

    public void SelectP()
    {
        currentSelection = SelectedInput.P;
        Debug.Log("P Control selected");
    }

    public void SelectPI()
    {
        currentSelection = SelectedInput.PI;
        Debug.Log("PI Control selected");
    }

    public void SelectPID()
    {
        currentSelection = SelectedInput.PID;
        Debug.Log("PID Control selected");
    }

    public void ShowExplanation()
    {
        HideExplanation();  // 一度全て非表示にする

        switch (currentSelection)
        {
            case SelectedInput.Impulse:
                explanation_ImpulseInput.SetActive(true);
                break;
            case SelectedInput.Step:
                explanation_StepInput.SetActive(true);
                break;
            case SelectedInput.Lump:
                explanation_LumpInput.SetActive(true);
                break;
            case SelectedInput.P:
                explanation_PControl.SetActive(true);
                break;
            case SelectedInput.PI:
                explanation_PIControl.SetActive(true);
                break;
            case SelectedInput.PID:
                explanation_PIDControl.SetActive(true);
                break;
            case SelectedInput.None:
                Debug.Log("何も選択されていません");
                break;
        }
    }

    private void HideExplanation()
    {
        explanation_ImpulseInput.SetActive(false);
        explanation_StepInput.SetActive(false);
        explanation_LumpInput.SetActive(false);
        explanation_PControl.SetActive(false);
        explanation_PIControl.SetActive(false);
        explanation_PIDControl.SetActive(false);
    }
}
