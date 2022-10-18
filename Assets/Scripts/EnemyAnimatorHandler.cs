using UnityEngine;
public abstract class EnemyAnimatorHandler : MonoBehaviour
{
    protected abstract Animator _animator { get; set; }
    protected const string isNearToTargetAnimatorBoolParametr = "IsNearToTarget";
    protected const string isDiedAnimatorTriggerParametr = "Died";
    protected const string isWonAnimatorTriggerParametr = "Won";
    [SerializeField] public abstract float DyingAnimationDuration { get; protected set; }
}
