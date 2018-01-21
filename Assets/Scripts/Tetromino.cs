using UnityEngine;

namespace Assets.Scripts
{
    public enum TetrominoType
    {
        Jenkins,
        Leeroy,
        LeftSnake,
        RightSnake,
        Square,
        Stick,
        Tina
    }

    public class Tetromino : MonoBehaviour
    {
        public TetrominoType Type;
        public TetrominoMovementController MovementController;

        void Awake()
        {
            MovementController = GetComponent<TetrominoMovementController>();
        }

        void Start()
        {
            // Default position not valid? Then it's game over
            if (!Managers.Grid.IsValidGridPosition(this.transform))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
