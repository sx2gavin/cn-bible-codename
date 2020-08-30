using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamCard : MonoBehaviour
{
    public enum Teams
    {
        Unknown,
        Innocent,
        Blue,
        Red,
        Spy
    }

    [SerializeField] Color redTeam = new Color32(214, 71, 66, 255);
    [SerializeField] Color blueTeam = new Color32(66, 179, 214, 255);
    [SerializeField] Color spy = new Color32(36, 31, 31, 255);
    [SerializeField] Color innocent = new Color32(255, 232, 186, 255);

    private Image image;

    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetTeam(Teams team)
    {
        switch (team)
        {
            case Teams.Innocent:
                image.color = innocent;
                break;
            case Teams.Blue:
                image.color = blueTeam;
                break;
            case Teams.Red:
                image.color = redTeam;
                break;
            case Teams.Spy:
                image.color = spy;
                break;
            default:
                image.color = Color.white;
                break;
        }
    }
}
