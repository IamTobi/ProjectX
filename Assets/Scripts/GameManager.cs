using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// GameManager used for initialization and keeping track of score and positions, and spawning tetrominos
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

        // Spawner position
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
