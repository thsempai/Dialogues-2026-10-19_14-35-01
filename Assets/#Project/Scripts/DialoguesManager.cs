using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialoguesManager : MonoBehaviour
{
    private const string DEFAULT_ANSWER = "Suivant";
    [SerializeField] private Dialog firstDialog;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Button[] buttons;
    private Dialog currentDialog;


    public void Start()
    {
        LoadDialog(firstDialog);

    }

    public void LoadDialog(Dialog dialog)
    {
        currentDialog = dialog;
        text.text = dialog.Text;
        if (currentDialog.Prompts.Length > 0)
        {

            for (int index = 0; index < buttons.Length; index++)
            {
                if (index < currentDialog.Prompts.Length)
                {
                    UpdateButton(index);
                    buttons[index].gameObject.SetActive(true);
                }
                else
                {
                    buttons[index].gameObject.SetActive(false);
                }
            }
        }
        else
        {
            UpdateButton(buttons[0], 0, DEFAULT_ANSWER);
            for (int index = 1; index < buttons.Length; index++)
            {
                buttons[index].gameObject.SetActive(false);
            }
        }

    }

    public void UpdateButton(int index) => UpdateButton(buttons[index], index, currentDialog.Prompts[index]);


    public void UpdateButton(Button button, int index, string text)
    {
        button.GetComponentInChildren<TMP_Text>().text = text;
    }
}

