using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonManager_s0_4 : MonoBehaviour
{
    public GameObject startText;  // ��ʒ����̃X�^�[�g�e�L�X�g��Inspector�œo�^

    private bool hasTouched = false;

    void Update()
    {
        if (!hasTouched && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            hasTouched = true;

            if (startText != null)
            {
                startText.SetActive(false); // �X�^�[�g�e�L�X�g���\���ɂ���
            }

            // �K�v�ł���΂��̂��Ƃɏ�����ǉ��i��F�Q�[���J�n�����j
        }
    }

    public void BackButton()
    {
        Debug.Log("Menu_0_4 �ɖ߂�܂�");
        SceneManager.LoadScene("Menu_0_4");
    }

    public void NextButton()
    {
        Debug.Log("Menu_0_5 �ɐi�݂܂�");
        SceneManager.LoadScene("Menu_0_5");
    }
}