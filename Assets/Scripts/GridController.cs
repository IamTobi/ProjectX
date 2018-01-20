using UnityEngine;

namespace Assets.Scripts
{
    public class GridController : MonoBehaviour
    {
        private static GridController _instance;

        public static GridController Instance
        {
            get { return _instance; }
        }
    
        private static int _gridHeight = 22;
        private static int _gridWidth = 10;
        private Transform[,] _grid = new Transform[_gridWidth, _gridHeight];

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }
        
        private void Start()
        {
            
        }
    }
}
