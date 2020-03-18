using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsUI : MonoBehaviour
{
    [SerializeField]
    Text skillPointsText;

    [SerializeField]
    Transform holder;

    [SerializeField]
    Button toggleButton;

    [SerializeField]
    Transform jumpHolder, fireHolder, accuracyHolder;

    [SerializeField]
    GameObject skillButton;

    BallLevel ballLevel;

    void Start()
    {
        ballLevel = FindObjectOfType<BallLevel>();
        SetSkillPoints();

        toggleButton.onClick.AddListener( () => SetVisible(!holder.gameObject.activeSelf) );
        SetVisible(false);

        // setup buttons
        List<Button> jumpButtons = new List<Button>(jumpHolder.GetComponentsInChildren<Button>());
        foreach (Button button in jumpButtons)
        {
            int level = jumpButtons.IndexOf(button) + 1;
            int cost = level;
            button.GetComponentInChildren<Text>().text = $"Level {level}";
            button.onClick.AddListener(() =>
            {
                if (AttemptBuy(cost))
                    FindObjectOfType<Skill_Jump>().SetSkillLevel(level);
            }
            );
        }

        List<Button> fireButtons = new List<Button>(fireHolder.GetComponentsInChildren<Button>());
        foreach (Button button in fireButtons)
        {
            int level = fireButtons.IndexOf(button) + 1;
            int cost = level;
            button.GetComponentInChildren<Text>().text = $"Level {level}";
            button.onClick.AddListener(() =>
            {
                if (AttemptBuy(cost))
                    FindObjectOfType<Skill_Fire>().SetSkillLevel(level);
            }
            );
        }

        Button[] accuracyButtons = accuracyHolder.GetComponentsInChildren<Button>();
        foreach (Button button in accuracyButtons)
        {
            button.onClick.AddListener(() => print("buy skill"));
        }
    }

    bool AttemptBuy(int cost)
    {
        if (ballLevel.SkillPoints >= cost)
        {
            ballLevel.SpendSkillPoints(cost);
            return true;
        }
        else return false;
    }

    void SetSkillPoints()
    {
        skillPointsText.text = $"Skill Points: {ballLevel.SkillPoints}";
    }

    void SetVisible(bool set)
    {
        holder.gameObject.SetActive(set);
    }
}
