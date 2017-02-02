using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class ObjectPoolerItem  {

        public int AmountToPool;
        public GameObject ObjectToPool;
        public bool ShouldExpand;

    }
}
