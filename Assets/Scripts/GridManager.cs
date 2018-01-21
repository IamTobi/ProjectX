using UnityEngine;

namespace Assets.Scripts
{

    [System.Serializable]
    public class Column
    {
        public Transform[] Row = new Transform[20];
    }


    public class GridManager : MonoBehaviour
    {
        public static int GridWidth = 10;
        public static int GridHeight = 20;

        public Column[] Grid = new Column[GridWidth]; 
        
        
        
        public bool InsideGrid(Vector2 pos)
        {
            return ((int)pos.x >= 0 && (int)pos.x < GridWidth && (int)pos.y >= 0);
        }

        public bool IsValidGridPosition(Transform tetromino)
        {
            foreach (Transform mino in tetromino)
            {
                if(mino.gameObject.tag.Equals(Constants.Tetrominos.Block))
                {
                    var vector = VectorExtension.RoundVector2(mino.position);

                    if (!InsideGrid(vector))
                    {
                        return false;
                    }

                    if (Grid[(int)vector.x].Row[(int)vector.y] != null && Grid[(int)vector.x].Row[(int)vector.y].parent != mino)
                    {
                        return false;
                    }
                }               
            }
            return true;
        }

        public void UpdateGrid(Transform tetromino)
        {
            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    if(Grid[x].Row[y] != null)
                    {
                        if(Grid[x].Row[y].parent == tetromino)
                        {
                            Grid[x].Row[y] = null;
                        }
                    }
                }
            }

            foreach (Transform mino in tetromino)
            {
                if(mino.gameObject.tag.Equals(Constants.Tetrominos.Block))
                {
                    var vector = VectorExtension.RoundVector2(mino.position);
                    Grid[(int)vector.x].Row[(int)vector.y] = mino;
                }
                
            }
        }
    }
}
