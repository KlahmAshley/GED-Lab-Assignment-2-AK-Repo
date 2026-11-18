using UnityEngine;
using UnityEngine.UIElements;

public class DialogueManagerController : Subject
{

    public bool IsDialogueOn
    {
        get; private set;
    }



    private DialogueManager dialogueManager;


    void Awake()
    {
        dialogueManager =
        (DialogueManager)
        FindObjectOfType(typeof(DialogueManager));


    }

    private void Start()
    {
       if(dialogueManager)
       {
           dialogueManager.Notify(this);
        }
    }

    private void OnEnable()
        {
            if (dialogueManager)
                Attach(dialogueManager);
        }


     private void OnDisable()
        {
           if (dialogueManager)
             Detach(dialogueManager);
        }
 
    public void ToggleDialogue()
    {
        IsDialogueOn = !IsDialogueOn;

        NotifyObservers();
    }

}
 