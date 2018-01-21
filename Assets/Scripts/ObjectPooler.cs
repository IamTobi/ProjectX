using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    
    public class ObjectPooler : MonoBehaviour
    {
        #region static properties
        public static ObjectPooler SharedInstance;

        #endregion
        
        #region public properties
        
        public List<ObjectPoolerItem> ItemsToPool;
        public List<GameObject> PooledObjects;
        #endregion

        #region init
        private void Awake()
        {
            SharedInstance = this;
            PooledObjects = new List<GameObject>();
            foreach (var objectPoolerItem in ItemsToPool)
            {
                for (var i = 0; i < objectPoolerItem.AmountToPool; i++)
                {
                    var obj = Instantiate(objectPoolerItem.ObjectToPool);
                    obj.SetActive(false);
                    PooledObjects.Add(obj);
                }
            }
        }

        private void Start()
        {
            
        }
        #endregion

        #region public methods
        public GameObject GetPooledObject(string objectTag)
        {
            foreach (var pooledObject in PooledObjects)
            {
                if (!pooledObject.activeInHierarchy && pooledObject.tag == objectTag)
                {
                    return pooledObject;
                }
            }
            foreach (var item in ItemsToPool)
            {
                if (item.ObjectToPool.tag != objectTag) continue;
                if (!item.ShouldExpand) continue;
                var obj = Instantiate(item.ObjectToPool);
                obj.SetActive(false);
                PooledObjects.Add(obj);
                return obj;
            }
            return null;
        }

        public GameObject GetRandomPooledObject(string objectTag)
        {
            var inactiveObjects = PooledObjects.Where(item => !item.activeInHierarchy).ToList();

            if (inactiveObjects.Any())
            {
                var randomObject = inactiveObjects[(int)Random.Range(0, Mathf.Round((inactiveObjects.Count - 1)))];
                return randomObject;
            }

            foreach (var item in ItemsToPool)
            {
                if (item.ObjectToPool.tag != objectTag) continue;
                if (!item.ShouldExpand) continue;
                var obj = Instantiate(item.ObjectToPool);
                obj.SetActive(false);
                PooledObjects.Add(obj);
                return obj;
            }
            return null;
        }
        #endregion
    }
}