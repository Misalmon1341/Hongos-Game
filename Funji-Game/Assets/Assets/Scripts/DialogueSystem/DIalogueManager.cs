using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

namespace DialogueSystem
{
    public class DIalogueManager : MonoBehaviour
    {
        [SerializeField] private DialogueUI dialogueUI;
        [SerializeField] private float typingspeed = 0.05f;
        [SerializeField] private AudioSource typingAudioSource;
        public static DIalogueManager Instance {  get; private set; }
        private Queue<DialogueTurn> dialogueTurnsQueue;

        public bool isDialogInProgress { get; private set; } = false;

        private void Awake()
        {
            Instance = this;
            dialogueUI.HideDialogBox();
        }

        public void StartDialogue(DialogueRound dialogue)
        {
            if(isDialogInProgress)
            {
                Debug.LogWarning($"Dialogue already in progress");
                return;
            }

            isDialogInProgress = true;
            dialogueTurnsQueue = new Queue<DialogueTurn>(dialogue.DialogueTurnsList);
            StartCoroutine(DialogueCoroutine());
        }

        private IEnumerator DialogueCoroutine()
        {
            dialogueUI.ShowDialogBox();
            while (dialogueTurnsQueue.Count > 0)
            {
                var currentturn = dialogueTurnsQueue.Dequeue();
                dialogueUI.SetCharacterInfo(currentturn.Character);
                dialogueUI.ClearDialogArea();
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return));

                yield return new WaitUntil(() => Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return));
                yield return null;
            }
            dialogueUI.HideDialogBox();
            isDialogInProgress=false;
        }
        private IEnumerator TypeSentence(DialogueTurn dialogueTurn)
        {
            var typingWaitSeconds = new WaitForSeconds(typingspeed);

            foreach (char letter in dialogueTurn.DialogueLine.ToCharArray())
            {
                dialogueUI.AppendtoDialogArea(letter);
                if (!char.IsWhiteSpace(letter)) typingAudioSource.Play();
                yield return typingWaitSeconds;
            }
        }
    }
}
