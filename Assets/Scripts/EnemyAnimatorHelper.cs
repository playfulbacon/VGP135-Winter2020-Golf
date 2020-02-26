using UnityEngine;

public class EnemyAnimatorHelper : MonoBehaviour
{
    public event System.Action OnAttack, OnAttackComplete;

    void Attack()
    {
        OnAttack?.Invoke();
    }

    void AttackComplete()
    {
        OnAttackComplete?.Invoke();
    }
}
