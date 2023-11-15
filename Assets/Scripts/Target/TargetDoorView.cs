using System;
using UnityEngine;

namespace Target
{
    public class TargetDoorView : MonoBehaviour, ITargetDoorView
    {
        [SerializeField] private Transform doorTransf;
        private Quaternion _startRotation;

        private void Start()
        {
            _startRotation = doorTransf.rotation;
        }

        public void CloseDoor()
        {
            doorTransf.rotation = _startRotation;
        }

        public void OpenDoor()
        {
            doorTransf.Rotate(new Vector3(0, 90f, 0));
        }
    }
}