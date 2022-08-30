using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterH2 : Interactive
{
    private DialogueController dialogueController;

    private void Awake()
    {
        dialogueController = GetComponent<DialogueController>();
    }

    public override void EmptyClicked()
    {
        if (isDone)
        {
            dialogueController.ShowDialogueFinish();
        }
        else
            dialogueController?.ShowDialogueEmpty();
    }

    protected override void OnClickedAction()
    {
        dialogueController.ShowDialogueFinish();
    }
}
