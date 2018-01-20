using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// GameManager used for Initialisation and keeping Track of score and positions
    /// </summary>
    public class GameManager : MonoBehaviour {
        
        /// <summary>
        /// Singleton Implementation
        /// </summary>
        private static GameManager _instance;

        public static GameManager Instance
        {
            get { return _instance; }
        }

        public Transform StartingPosition;


        void Start()
        {
            DontDestroyOnLoad(transform.gameObject);

            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }

            SpawnNextTetromino();
        }

        public void SpawnNextTetromino()
        {
            var objectToSpawn = ObjectPooler.SharedInstance.GetRandomPooledObject(Constants.Tetrominos.Identifier);
            objectToSpawn.transform.position = StartingPosition.position;
            objectToSpawn.SetActive(true);
        }
        
        void Update () {
	
        }
    }
}
