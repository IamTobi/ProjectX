using Assets.Scripts;
using UnityEngine;

namespace Assets
{
    public class BlockSpawner : MonoBehaviour
    {

        public Transform StartingPosition;

        
        void Start ()
        {
            SpawnBlock();
        }

        private void SpawnBlock()
        {
            var objectToSpawn = ObjectPooler.SharedInstance.GetRandomPooledObject("Tetromino");
            objectToSpawn.transform.position = StartingPosition.position;
            objectToSpawn.SetActive(true);
        }
        
    }
}
