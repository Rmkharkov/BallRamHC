using UnityEngine;

namespace Target
{
    public class TargetDoorView : MonoBehaviour, ITargetDoorView
    {
        [SerializeField] private Transform doorTransf;
        
        public void CloseDoor()
        {
            doorTransf.rotation = Quaternion.Euler(0, 0, 0);
        }

        public void OpenDoor()
        {
            doorTransf.Rotate(new Vector3(0, 90f, 0));
        }
    }
}