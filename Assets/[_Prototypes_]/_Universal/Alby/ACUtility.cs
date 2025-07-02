using UnityEngine;

namespace _ACUtil
{
    public class ACUtility
    {
        public void LookAtObject(GameObject user, GameObject target) => user.transform.LookAt(target.transform);
    }
}

