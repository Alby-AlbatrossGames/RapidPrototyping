using UnityEngine;

namespace Prototype4
{
    public class FollowHandle : MonoBehaviour
    {
        public GameObject handle;
        private RectTransform handleRect;
        private RectTransform thisRect;

        private void Start()
        {
            handleRect = handle.GetComponent<RectTransform>();
            thisRect = GetComponent<RectTransform>();
            SetTextPosition();
        }

        public void SetTextPosition()
        {
            thisRect.position = (new Vector2(thisRect.position.x, handleRect.position.y));
        }
    }
}

