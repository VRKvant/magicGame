using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using System;
public class SpellContainer : MonoBehaviour
{
    [SerializeField] private List<NeededGestures> _spellNeededGestures;
    [SerializeField] private List<GameObject> _spellsPrefabs;
    private const float CONFIDENCE_THRESHOLD = 0.95f;
    private void Update()
    {
        MLHandTracking.HandKeyPose rightHandKeyPose;
        MLHandTracking.HandKeyPose leftHandKeyPose;
        if (TryGetHandPose(MLHandTracking.Right, out rightHandKeyPose) && TryGetHandPose(MLHandTracking.Left, out leftHandKeyPose))
        {
            CallSpell(rightHandKeyPose, leftHandKeyPose);
        }

    }
    private void CallSpell(MLHandTracking.HandKeyPose rightHandKeyPose, MLHandTracking.HandKeyPose leftHandKeyPose)
    {
        NeededGestures curGestures = new NeededGestures();
        curGestures._leftHandGesture = leftHandKeyPose;
        curGestures._rightHandGesture = rightHandKeyPose;
        for(int i = 0; i < _spellsPrefabs.Count; i++)
        {
            if(curGestures == _spellNeededGestures[i])
            {
                CastSpell(_spellsPrefabs[i]);
                return;
            }
           
        }
    }
    private bool TryGetHandPose(MLHandTracking.Hand hand, out MLHandTracking.HandKeyPose handKeyPose)
    {
        handKeyPose = MLHandTracking.HandKeyPose.NoHand;
        if (hand != null)
        {
            handKeyPose = hand.KeyPose;
            return (hand.HandKeyPoseConfidence >= CONFIDENCE_THRESHOLD);
        }
        return false;
    }
    private void CastSpell(GameObject spellPrefab)
    {
        if (_cooldownReady)
        {
            Instantiate(spellPrefab, (MagicLeapTools.HandInput.Right.Skeleton.Position + MagicLeapTools.HandInput.Left.Skeleton.Position) / 2, Quaternion.identity);
            _cooldownReady = false;
            Invoke(nameof(SetCooldownReady), 1f);
        }

    }
    private bool _cooldownReady = true;
    private void SetCooldownReady()
    {
        
        _cooldownReady = true;
    }
    [Serializable]
    public struct NeededGestures
    {
        [field: SerializeField] public MLHandTracking.HandKeyPose _rightHandGesture;
        [field: SerializeField] public MLHandTracking.HandKeyPose _leftHandGesture;

        public static bool operator ==(NeededGestures a, NeededGestures b) 
        {
            return (a._leftHandGesture == b._leftHandGesture) && (a._rightHandGesture == b._rightHandGesture);
        }
        public static bool operator !=(NeededGestures a, NeededGestures b)
        {
            return (a._leftHandGesture != b._leftHandGesture) || (a._rightHandGesture != b._rightHandGesture);
        }
    }

}

