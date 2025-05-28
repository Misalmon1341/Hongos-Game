using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueUI : MonoBehaviour
    {
        //DialogueUI
        [SerializeField] private GameObject panel;
        [SerializeField] private RectTransform dialogbox;
        [SerializeField] private Image characterphoto;
        [SerializeField] private TextMeshProUGUI charactername;
        [SerializeField] private TextMeshProUGUI dialogarea;

        public void ShowDialogBox()
        {
            panel.SetActive(true);
            dialogbox.gameObject.SetActive(true);
        }
        public void HideDialogBox()
        {   
            panel.SetActive(false);
            dialogbox.gameObject.SetActive(false);
        }
        public void SetCharacterInfo(DialogueCharacterSo character)
        {
            if (character == null) return;
            characterphoto.sprite = character.Profilephoto;
            charactername.text = character.Name;
        }
        public void ClearDialogArea()
        {
            dialogarea.text = string.Empty;
        }

        public void SetDialogueArea(string text)
        {
            dialogarea.text = text;
        }

        public void AppendtoDialogArea(char letter)
        {
            dialogarea.text += letter;
        }
    }
}
