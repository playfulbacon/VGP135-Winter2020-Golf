using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallLevelUI : MonoBehaviour
{
    [SerializeField]
    Slider experienceSlider;

    [SerializeField]
    Text levelText;

    [SerializeField]
    GameObject levelUpText;

    [SerializeField]
    Text xpText;

    private BallLevel ballLevel;
    private float xpSliderTarget = 0;

    private void Start()
    {
        ballLevel = FindObjectOfType<BallLevel>();

        ballLevel.OnXPChange += XpChanged;
        ballLevel.OnLevelChange += () => LevelChanged();
        ballLevel.OnGoal += (x) => xpText.text = $"You gained {x} experience points.";

        SetLevel();

        xpSliderTarget = (float)ballLevel.Xp / (float)ballLevel.XpToLevelUp;
        experienceSlider.value = xpSliderTarget;

        levelUpText.SetActive(false);
    }

    private void XpChanged()
    {
        xpSliderTarget = (float)ballLevel.Xp / (float)ballLevel.XpToLevelUp;
    }

    private void LevelChanged(bool playAudio = true)
    {
        SetLevel();

        xpSliderTarget = 0;
        experienceSlider.value = 0;

        if (playAudio)
            GetComponent<AudioSource>().Play();

        StopCoroutine(LevelUp());
        StartCoroutine(LevelUp());
    }

    void SetLevel()
    {
        levelText.text = $"LV. {ballLevel.Level}";
    }

    private void Update()
    {
        if (experienceSlider.value != xpSliderTarget)
            experienceSlider.value = Mathf.MoveTowards(experienceSlider.value, xpSliderTarget, Time.deltaTime * 0.5f);
    }

    IEnumerator LevelUp()
    {
        levelUpText.SetActive(true);
        yield return new WaitForSeconds(1.25f);
        levelUpText.SetActive(false);
    }
}
