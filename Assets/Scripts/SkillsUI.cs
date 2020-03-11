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
        foreach(Button button in jumpButtons)
        {
            int level = jumpButtons.IndexOf(button) + 1;
            button.GetComponentInChildren<Text>().text = $"Level {level}";
            button.onClick.AddListener(() => FindObjectOfType<Skill_Jump>().SetSkillLevel(level));
        }

        List<Button> fireButtons = new List<Button>(fireHolder.GetComponentsInChildren<Button>());
        foreach (Button button in fireButtons)
        {
            int level = fireButtons.IndexOf(button) + 1;
            button.GetComponentInChildren<Text>().text = $"Level {level}";
            button.onClick.AddListener(() => { FindObjectOfType<Skill_Fire>().SetSkillLevel(level); });
        }

        Button[] accuracyButtons = accuracyHolder.GetComponentsInChildren<Button>();
        foreach (Button button in accuracyButtons)
        {
            button.onClick.AddListener(() => print("buy skill"));
        }
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
