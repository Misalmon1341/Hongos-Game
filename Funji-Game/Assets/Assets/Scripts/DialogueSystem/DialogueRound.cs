using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Scriptable Objects/ Dialogue Round")]
    public class DialogueRound : ScriptableObject
    {
      [SerializeField]  private List<DialogueTurn> dialogueTurnsList;

        public List<DialogueTurn> DialogueTurnsList => dialogueTurnsList; 
    }
}
