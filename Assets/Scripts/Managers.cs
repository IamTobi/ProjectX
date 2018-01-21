using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(GameManager))]
    [RequireComponent(typeof(GridManager))]
    [RequireComponent(typeof(PlayerInputManager))]

    public class Managers : MonoBehaviour
    {
        private static GameManager _gameManager;
        public static GameManager GameManager
        {
            get { return _gameManager; }
        }

        private static PlayerInputManager _inputManager;
        public static PlayerInputManager Input
        {
            get { return _inputManager; }
        }

        private static GridManager _gridManager;
        public static GridManager Grid
        {
            get { return _gridManager; }
        }

        private void Awake()
        {
            _gameManager = GetComponent<GameManager>();
            _inputManager = GetComponent<PlayerInputManager>();
            _gridManager = GetComponent<GridManager>();

            DontDestroyOnLoad(gameObject);
        }
    }
}
