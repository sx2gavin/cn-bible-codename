using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretBoard : MonoBehaviour
{
    public event Action NewSecret;

    [SerializeField] private TeamCard colourCard;

    private TeamCard.Teams[] secrets = new TeamCard.Teams[25];

    private void Start()
    {
        GenerateBoard();
    }

    public void GenerateBoard()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < 25; i++)
        {
            if (i >= 0 && i <= 8)
            {
                secrets[i] = TeamCard.Teams.Red;
            }
            else if (i >= 9 && i <= 16)
            {
                secrets[i] = TeamCard.Teams.Blue;
            }
            else if (i == 17)
            {
                secrets[i] = TeamCard.Teams.Spy;
            }
            else
            {
                secrets[i] = TeamCard.Teams.Innocent;
            }
        }

        secrets.Shuffle();

        for (int i = 0; i < 25; i++)
        {
            TeamCard card = Instantiate(colourCard, transform);
            card.SetTeam(secrets[i]);
        }

        NewSecret?.Invoke();
    }

    public TeamCard.Teams CheckSecret(int index)
    {
        return secrets[index];
    }

}
