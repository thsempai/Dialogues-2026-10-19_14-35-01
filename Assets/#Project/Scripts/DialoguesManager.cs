using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialoguesManager : MonoBehaviour
{
    private const string DEFAULT_ANSWER = "Suivant";
    private const string DEFAULT_END_DIALOG = "Fin";
    [SerializeField] private Dialog firstDialog;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Button[] buttons;
    private Dialog currentDialog;



    private void OnEnable()
    {
        Active();
        LoadDialog(firstDialog);
    }

    private void OnDisable()
    {
        Deactive();
    }

    private void SetActive(bool ok)
    {
        text.gameObject.SetActive(ok);
        image.gameObject.SetActive(ok);
        for (int index = 0; index < buttons.Length; index++)
        {
            buttons[index].gameObject.SetActive(ok);
        }
    }

    private void Active() => SetActive(true);
    private void Deactive() => SetActive(false);

    public void LoadDialog(Dialog dialog)
    {
        currentDialog = dialog;
        text.text = dialog.Text;
        image.sprite = dialog.Image;
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
            UpdateButton(buttons[0], 0, currentDialog.NextDialogs.Length > 0 ? DEFAULT_ANSWER : DEFAULT_END_DIALOG);
            for (int index = 1; index < buttons.Length; index++)
            {
                buttons[index].gameObject.SetActive(false);
            }
        }

    }

    public void LoadDialog(int index)
    {
        if (index < currentDialog.NextDialogs.Length)
        {
            LoadDialog(currentDialog.NextDialogs[index]);
        }
        else
        {
            enabled = false;
        }
    }
    public void UpdateButton(int index) => UpdateButton(buttons[index], index, currentDialog.Prompts[index]);

    public void UpdateButton(Button button, int index, string text)
    {
        button.GetComponentInChildren<TMP_Text>().text = text;
    }
}

