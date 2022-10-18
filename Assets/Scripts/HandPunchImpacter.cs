using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.XR.MagicLeap;
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class HandPunchImpacter : MonoBehaviour
{
    [SerializeField] private GameObject _punchVFX;
    private void OnCollisionEnter(Collision collision)
    {
        if (GetComponent<MagicLeapTools.HandCollider>())
        {
            Destroy(Instantiate(_punchVFX, collision.GetContact(0).point, Quaternion.identity), 1f);
        }
    }
}