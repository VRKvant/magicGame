using UnityEngine;
using UnityEngine.XR.MagicLeap;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class Fireball : MonoBehaviour, ISpell
{
    [SerializeField] private float _force;
    private Rigidbody _rigidbody;
    [SerializeField, Range(0, 50)]
    private int _damage;
    private void Start()
    {
        TryGetComponent<Rigidbody>(out _rigidbody);
        _rigidbody.useGravity = false;
        StartMoving();
        Destroy(gameObject, 5f);
    }
    private void StartMoving()
    {
        _rigidbody.AddForce(Camera.main.transform.forward * _force);
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        Enemy enemy;
        if(collision.collider.gameObject.TryGetComponent<Enemy>(out enemy))
        {
            enemy.TakeDamage(_damage);
        }
        if (!collision.collider.gameObject.GetComponent<MagicLeapTools.HandCollider>()) { Destroy(gameObject); }
    }
}
