using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// GameManager used for initialization and keeping track of score and positions, and spawning tetrominos
    /// </summary>
    public class GameManager : MonoBehaviour {
        
        // Spawner position
        public Transform StartingPosition;
        public Tetromino CurrentTetromino;


        void Start()
        {
            SpawnNextTetromino();
        }

        public void SpawnNextTetromino()
        {
            var objectToSpawn = ObjectPooler.SharedInstance.GetRandomPooledObject(Constants.Tetrominos.Identifier);
            objectToSpawn.transform.position = StartingPosition.position;
            objectToSpawn.SetActive(true);
            Managers.GameManager.CurrentTetromino = objectToSpawn.GetComponent<Tetromino>();

        }
        
        void Update () {
            Managers.GameManager.CurrentTetromino.MovementController.ShapeUpdate();
        }
    }
}
