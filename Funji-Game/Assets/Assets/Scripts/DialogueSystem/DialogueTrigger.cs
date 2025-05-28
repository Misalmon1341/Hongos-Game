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

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                TriggerDialogue();
            }
        }
        private void OnTriggerExit(Collider collision)
        {
            if (collision.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
}
