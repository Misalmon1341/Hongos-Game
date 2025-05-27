using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    [System.Serializable]
    public class DialogueTurn  
    {
        [field: SerializeField]

        public DialogueCharacterSo Character {  get; private set; }

        [SerializeField, TextArea(2,4)]
        private string dialogueLine = string.Empty;

        public string DialogueLine => dialogueLine;
    }
}
