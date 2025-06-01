using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUIManager : MonoBehaviour
{
    public Image[] cardSlots;         
    public Sprite[] cardSprites;

    private List<int> cardTypes = new List<int>();
    public int CardCount()
    {
        return cardTypes.Count;
    }

    public bool CanAddCard()
    {
        return cardTypes.Count < cardSlots.Length;
    }

    public void AddCard(int weaponIndex)
    {
        if (!CanAddCard()) return;

        cardSlots[cardTypes.Count].sprite = cardSprites[weaponIndex];
        cardSlots[cardTypes.Count].enabled = true;

        cardTypes.Add(weaponIndex);
    }

    public int UseCard(int index)
    {
        if (index < 0 || index >= cardTypes.Count) return -1;

        int weaponUsed = cardTypes[index];

        for (int i = index; i < cardTypes.Count - 1; i++)
        {
            cardSlots[i].sprite = cardSlots[i + 1].sprite;
            cardTypes[i] = cardTypes[i + 1];
        }

        cardSlots[cardTypes.Count - 1].enabled = false;
        cardTypes.RemoveAt(cardTypes.Count - 1);

        return weaponUsed;
    }
}
