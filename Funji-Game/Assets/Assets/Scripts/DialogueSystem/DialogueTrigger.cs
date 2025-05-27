using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] private DialogueRound dialogue;

        [ContextMenu("Trigger Dialogue")]

        public void TriggerDialogue()
        {
            DIalogueManager.Instance.StartDialogue(dialogue);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Player"))
            {
                TriggerDialogue();
            }
        }
    }
}
