using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLevel : MonoBehaviour
{
    public System.Action OnXPChange;
    public System.Action OnLevelChange;
    public System.Action<int> OnGoal;

    public bool resetLevelAndXp = false;

    private int level = 1;
    public int Level { get { return level; } }

    private int xpToLevelUp = 10;
    public int XpToLevelUp { get { return xpToLevelUp; } }

    private int xp = 0;
    public int Xp { get { return xp; } }
    private int xpBank = 0;

    Coroutine xpChangingCoroutine = null;

    private void Awake()
    {
        BallCollision[] ballCollisions = FindObjectsOfType<BallCollision>();
        foreach(BallCollision ballCollision in ballCollisions)
            ballCollision.OnEnemyKill += (x) => ChangeXP(x.xpValue);

        FindObjectOfType<Goal>().OnGoal += Goal;

        SetXP(PlayerPrefs.GetInt("xp"));
        int savedLevel = PlayerPrefs.GetInt("level");
        SetLevel(savedLevel == 0 ? 1 : savedLevel);

        if (resetLevelAndXp)
        {
            SetXP(0);
            SetLevel(1);
            resetLevelAndXp = false;
        }
    }

    private void Goal()
    {
        int xp = FindObjectOfType<LevelManager>().LevelPar - (int)FindObjectOfType<ScoreManager>().GetScore();
        if (xp < 0)
            xp = 0;

        ChangeXP(xp);
        OnGoal?.Invoke(xp);
    }

    public void ChangeXP(int change)
    {
        if (xpChangingCoroutine != null)
            StopCoroutine(xpChangingCoroutine);
        else
            xpChangingCoroutine = StartCoroutine(XPChanging(change));
    }

    IEnumerator XPChanging(int change)
    {
        xpBank += change;

        while(xpBank > 0)
        {
            xpBank--;
            SetXP(xp + 1);

            yield return new WaitForSeconds(0.15f);

            if (xp == xpToLevelUp)
            {
                SetLevel(level + 1);
                SetXP(0);
                yield return new WaitForSeconds(0.5f);
            }
        }

        xpChangingCoroutine = null;
    }

    private void SetXP(int set)
    {
        xp = set;
        PlayerPrefs.SetInt("xp", xp);
        OnXPChange?.Invoke();
    }

    private void SetLevel(int set)
    {
        level = set;
        PlayerPrefs.SetInt("level", level);
        OnLevelChange?.Invoke();
    }
}
