using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeGuns : MonoBehaviour
{
    public GameObject[] guns;
    public CardUIManager cardUI;

    public bool ActiveGuns(int numero)
    {
        
        if (!cardUI.CanAddCard())
        {
            Debug.Log("Slots llenos");
            return false; 
        }  
          
        
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(false);
        }

        guns[numero].SetActive(true);
        cardUI.AddCard(numero);
        return true;
    }
}
