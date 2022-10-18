using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using MagicLeap.Core;
using MagicLeapTools;
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
[ExecuteAlways]
public class MyOwnHandCollider : MonoBehaviour
{
    [SerializeField] private KeyPointVisualizer.KeyPoint _keyPoint;
    private ManagedKeypoint _status;
    private Camera _mainCamera;
    private SphereCollider _collider;
    private Rigidbody _rigidbody;
    private void Awake()
    {
        _mainCamera = Camera.main;
        _collider = GetComponent<SphereCollider>();
        _collider.radius = 0.01f;
        //_collider.enabled = false;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.mass = 5f;
        _rigidbody.isKinematic = true;
        _rigidbody.useGravity = false;
        try
        {
            KeyPointVisualizer.KeyPoint prevKeyPoint = GetComponent<KeyPointVisualizer>().keyPoint;
            _keyPoint = prevKeyPoint;
            DestroyImmediate(GetComponent<KeyPointVisualizer>());
        }catch { return; }
    }
    private void FixedUpdate() 
    {
        if (!HandInput.Ready)
        {
            return;
        }

        switch (_keyPoint)
        {
            case KeyPointVisualizer.KeyPoint.RightHandCenter:
                _status = HandInput.Right.Skeleton.HandCenter;
                break;

            case KeyPointVisualizer.KeyPoint.RightWristCenter:
                _status = HandInput.Right.Skeleton.WristCenter;
                break;

            case KeyPointVisualizer.KeyPoint.RightThumbKnuckle:
                _status = HandInput.Right.Skeleton.Thumb.Knuckle;
                break;

            case KeyPointVisualizer.KeyPoint.RightThumbJoint:
                _status = HandInput.Right.Skeleton.Thumb.Joint;
                break;

            case KeyPointVisualizer.KeyPoint.RightThumbTip:
                _status = HandInput.Right.Skeleton.Thumb.Tip;
                break;

            case KeyPointVisualizer.KeyPoint.RightIndexKnuckle:
                _status = HandInput.Right.Skeleton.Index.Knuckle;
                break;

            case KeyPointVisualizer.KeyPoint.RightIndexJoint:
                _status = HandInput.Right.Skeleton.Index.Joint;
                break;

            case KeyPointVisualizer.KeyPoint.RightIndexTip:
                _status = HandInput.Right.Skeleton.Index.Tip;
                break;

            case KeyPointVisualizer.KeyPoint.RightMiddleKnuckle:
                _status = HandInput.Right.Skeleton.Middle.Knuckle;
                break;

            case KeyPointVisualizer.KeyPoint.RightMiddleJoint:
                _status = HandInput.Right.Skeleton.Middle.Joint;
                break;

            case KeyPointVisualizer.KeyPoint.RightMiddleTip:
                _status = HandInput.Right.Skeleton.Middle.Tip;
                break;

            case KeyPointVisualizer.KeyPoint.RightRingKnuckle:
                _status = HandInput.Right.Skeleton.Ring.Knuckle;
                break;

            case KeyPointVisualizer.KeyPoint.RightRingTip:
                _status = HandInput.Right.Skeleton.Ring.Tip;
                break;

            case KeyPointVisualizer.KeyPoint.RightPinkyKnuckle:
                _status = HandInput.Right.Skeleton.Pinky.Knuckle;
                break;

            case KeyPointVisualizer.KeyPoint.RightPinkyTip:
                _status = HandInput.Right.Skeleton.Pinky.Tip;
                break;

            case KeyPointVisualizer.KeyPoint.LeftHandCenter:
                _status = HandInput.Left.Skeleton.HandCenter;
                break;

            case KeyPointVisualizer.KeyPoint.LeftWristCenter:
                _status = HandInput.Left.Skeleton.WristCenter;
                break;

            case KeyPointVisualizer.KeyPoint.LeftThumbKnuckle:
                _status = HandInput.Left.Skeleton.Thumb.Knuckle;
                break;

            case KeyPointVisualizer.KeyPoint.LeftThumbJoint:
                _status = HandInput.Left.Skeleton.Thumb.Joint;
                break;

            case KeyPointVisualizer.KeyPoint.LeftThumbTip:
                _status = HandInput.Left.Skeleton.Thumb.Tip;
                break;

            case KeyPointVisualizer.KeyPoint.LeftIndexKnuckle:
                _status = HandInput.Left.Skeleton.Index.Knuckle;
                break;

            case KeyPointVisualizer.KeyPoint.LeftIndexJoint:
                _status = HandInput.Left.Skeleton.Index.Joint;
                break;

            case KeyPointVisualizer.KeyPoint.LeftIndexTip:
                _status = HandInput.Left.Skeleton.Index.Tip;
                break;

            case KeyPointVisualizer.KeyPoint.LeftMiddleKnuckle:
                _status = HandInput.Left.Skeleton.Middle.Knuckle;
                break;

            case KeyPointVisualizer.KeyPoint.LeftMiddleJoint:
                _status = HandInput.Left.Skeleton.Middle.Joint;
                break;

            case KeyPointVisualizer.KeyPoint.LeftMiddleTip:
                _status = HandInput.Left.Skeleton.Middle.Tip;
                break;

            case KeyPointVisualizer.KeyPoint.LeftRingKnuckle:
                _status = HandInput.Left.Skeleton.Ring.Knuckle;
                break;

            case KeyPointVisualizer.KeyPoint.LeftRingTip:
                _status = HandInput.Left.Skeleton.Ring.Tip;
                break;

            case KeyPointVisualizer.KeyPoint.LeftPinkyKnuckle:
                _status = HandInput.Left.Skeleton.Pinky.Knuckle;
                break;

            case KeyPointVisualizer.KeyPoint.LeftPinkyTip:
                _status = HandInput.Left.Skeleton.Pinky.Tip;
                break;
        }


        if (_status != null)
        {
            transform.position = _status.positionFiltered;
            //transform.position = _status.positionRaw;

            //_collider.enabled = _status.Visible;
        }
    }
}

