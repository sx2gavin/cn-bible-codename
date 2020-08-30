using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsBoard : MonoBehaviour
{
    [SerializeField] private WordCard wordCard;
    [SerializeField] private SecretBoard secretBoard;
    [SerializeField] private WordsReader wordsReader;

    private List<WordCard> wordCards = new List<WordCard>();

    private List<string> wordsList;

    // Start is called before the first frame update
    void Start()
    {
        secretBoard.NewSecret += OnNewSecretGenerated;
        LoadAvailableWordsFromReader();
    }

    private void OnDestroy()
    {
        secretBoard.NewSecret -= OnNewSecretGenerated;
    }

    private void LoadAvailableWordsFromReader()
    {
        wordsList = wordsReader.LoadWordsFromFile();
        GenerateWords();
    }

    private void OnNewSecretGenerated()
    {
        foreach (WordCard card in wordCards)
        {
            if (card.GetComponent<TeamCard>())
            {
                card.GetComponent<TeamCard>().SetTeam(TeamCard.Teams.Unknown);
            }
        }
    }

    public void GenerateWords()
    {
        wordCards.Clear();

        foreach (Transform child in transform)
        {
            child.GetComponent<WordCard>().WordCardClicked -= OnWordCardClicked;
            Destroy(child.gameObject);
        }

        wordsList.Shuffle();

        for (int i = 0; i < 25; i++)
        {
            WordCard card = Instantiate(wordCard, transform);
            wordCards.Add(card);
            card.UpdateWord(i, wordsList[i]);
            card.WordCardClicked += OnWordCardClicked;
        }
    }

    private void OnWordCardClicked(WordCard card)
    {
        TeamCard.Teams team = secretBoard.CheckSecret(card.GetIndex());
        if (card.GetComponent<TeamCard>())
        {
            card.GetComponent<TeamCard>().SetTeam(team);
        }
    }
}
