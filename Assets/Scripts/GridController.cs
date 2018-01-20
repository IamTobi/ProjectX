using UnityEngine;

namespace Assets.Scripts
{
    public class GridController : MonoBehaviour
    {
        #region singleton implementation
        private static GridController _instance;

        public static GridController Instance
        {
            get { return _instance; }
        }
        #endregion

        #region properties / attributes
        public static int GridHeight = 20;
        public static int GridWidth = 10;

        public Transform[,] Grid = new Transform[GridWidth, GridHeight];

        #endregion
        
        #region start

        private void Awake()
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
        }

        private void Start()
        {

        }
        #endregion

        #region update

        #endregion
        
        public bool CheckIsInsideGrid(Vector2 pos)
        {
            return ((int)pos.x >= 0 && (int)pos.x < GridWidth && (int)pos.y >= 0);
        }

        public Vector2 Round(Vector2 pos)
        {
            return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y)); 
        }

        public void UpdateGrid(Tetromino tetromino)
        {
            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    if(Grid[x,y] != null)
                    {
                        if(Grid[x,y].parent == tetromino.transform)
                        {
                            Grid[x, y] = null;
                        }
                    }
                }
            }

            foreach (Transform mino in tetromino.transform)
            {
                var pos = Round(mino.position);

                if(pos.y <GridHeight)
                {
                    Grid[(int)pos.x, (int)pos.y] = mino;
                }
            }
        }

        public Transform GetTransformAtGridPosition(Vector2 pos)
        {
            if(pos.y > GridHeight -1)
            {
                return null;
            }
            else
            {
                return Grid[(int)pos.x, (int)pos.y];
            }
        }
    }
}
