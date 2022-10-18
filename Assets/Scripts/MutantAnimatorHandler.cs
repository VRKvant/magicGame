using UnityEngine;
public class MutantAnimatorHandler : EnemyAnimatorHandler
{
    [field: SerializeField] public override float DyingAnimationDuration { get; protected set; }
    [HideInInspector] protected override Animator _animator { get; set; }
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void OnDie()
    {
        _animator.SetTrigger(isDiedAnimatorTriggerParametr);
    }
    public void OnReadyToDamage()
    {
        _animator.SetBool(isNearToTargetAnimatorBoolParametr, true);
    }
    public void OnWin()
    {
        _animator.SetTrigger(isWonAnimatorTriggerParametr);
    }
}
