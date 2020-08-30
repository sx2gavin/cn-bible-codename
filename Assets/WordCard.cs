using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WordCard : MonoBehaviour, IPointerClickHandler
{
    public event Action<WordCard> WordCardClicked;

    [SerializeField] private Text word;

    private int index;

    public void UpdateWord(int index, string newWord)
    {
        this.index = index;
        word.text = newWord;
    }

    public int GetIndex()
    {
        return index;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        WordCardClicked?.Invoke(this);
    }
}
