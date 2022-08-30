using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueController))]
public class DialogueController : MonoBehaviour
{
    public DialogueData_SO dialogueEmpty;
    public DialogueData_SO dialogueFinish;

    private Stack<string> dialogueEmptyStack;
    private Stack<string> dialogueFinishStack;

    private bool isTalking;

    private void Awake()
    {
        FillDialogueStack();
    }

    private void FillDialogueStack()
    {
        dialogueEmptyStack = new Stack<string>();
        dialogueFinishStack = new Stack<string>();

        for (int i = dialogueEmpty.dialogueList.Count - 1; i > -1; i--)
        {
            dialogueEmptyStack.Push(dialogueEmpty.dialogueList[i]);
        }
        for (int i = dialogueFinish.dialogueList.Count - 1; i > -1; i--)
        {
            dialogueEmptyStack.Push(dialogueFinish.dialogueList[i]);
        }
    }

    public void ShowDialogueEmpty()
    {
        
    }

    public void ShowDialogueFinish()
    {

    }
}
