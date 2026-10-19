using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Dialogues", menuName = "Scriptable Objects/Dialogues")]
public class Dialog : ScriptableObject
{
    [field: SerializeField] public Image Image { get; private set; }
    [field: SerializeField] public string Text { get; private set; }
    [field: SerializeField] public string[] Prompts { get; private set; }
    [field: SerializeField] public Dialog[] NextDialogs { get; private set; }

}
