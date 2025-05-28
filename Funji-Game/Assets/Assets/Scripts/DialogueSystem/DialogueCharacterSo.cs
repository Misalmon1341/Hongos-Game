using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    [CreateAssetMenu(fileName = "New Dialogue Character", menuName = "Scriptable Objects/Dialogue Character")]
    public class DialogueCharacterSo : ScriptableObject
    {
        [Header("Character Info")]
        [SerializeField] private string charactername;
        [SerializeField] private Sprite profilephoto;

        public string Name => charactername;

        public Sprite Profilephoto => profilephoto;
    }
}
