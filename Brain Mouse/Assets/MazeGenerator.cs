using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
//using UnityEditor.UI;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private MazeCell _mazeCellPrefab;

    [SerializeField]
    private int _mazeWidth;

    [SerializeField]
    private int _mazeDepth;

    [SerializeField]

    private int _seed;

    [SerializeField]
    private bool _useSeed;

    // The Array that holds the Grid Cells

    private MazeCell[,] _mazeGrid;
    //TUrn the start type into a co-routine
    void Start()
    {
        if (_useSeed)
        {
            Random.InitState(_seed);
        }
        else
        {
            int randomSeed = Random.Range(-100000, 100000);
            Random.InitState(randomSeed);

            Debug.Log(randomSeed);
        }

        _mazeGrid = new MazeCell[_mazeWidth, _mazeDepth];
        for (int x =  0; x < _mazeWidth; x++)
        {
            for (int z = 0; z < _mazeDepth; z++)
            {
                _mazeGrid[x,z] = Instantiate(_mazeCellPrefab, new Vector3(x,0,z), Quaternion.identity);

            }
        }

         GenerateMaze(null, _mazeGrid[0, 0]);
    }
    // New private co-routine to generate the maze

    private void GenerateMaze(MazeCell previousCell, MazeCell currentCell)
    {
        currentCell.Visit();
        ClearWalls(previousCell, currentCell);



        MazeCell nextCell;

        do
        {

            nextCell = GetNextUnvisitedCell(currentCell);

            if (nextCell != null) 
            {
                 GenerateMaze(currentCell, nextCell);
            }
        } while (nextCell != null);
    }

    //Method to move to surrouding cells
    private MazeCell GetNextUnvisitedCell(MazeCell currentCell)
    {
        var unvisitedCells = GetUnvisitedCells(currentCell);

        return unvisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }


    // will return all of the unvisited neighbors

    private IEnumerable<MazeCell> GetUnvisitedCells(MazeCell currentCell)
    {
        int x = (int)currentCell.transform.position.x;
        int z = (int)currentCell.transform.position.z;

        if (x + 1 < _mazeWidth)
        {
            var cellToRight = _mazeGrid[x + 1, z];

            if (cellToRight.IsVisited == false)
            {
                yield return cellToRight;
            }
        }

        if (x - 1 >= 0)
        {
            var cellToLeft = _mazeGrid[x - 1, z];

            if(cellToLeft.IsVisited == false)
            {
                yield return cellToLeft;
            }
        }

        if (z + 1 < _mazeDepth)
        {
            var cellToFront = _mazeGrid[x, z + 1];

            if (cellToFront.IsVisited == false)
            {
                yield return cellToFront;
            }
        }

        if (z - 1 >= 0)
        {
            var cellToBack = _mazeGrid[x, z - 1];

            if(cellToBack.IsVisited == false)
            {
                yield return cellToBack;
            }

        }
    }
    private void ClearWalls(MazeCell previousCell, MazeCell currentCell)
    {
        if (previousCell == null)
        {
            return;
        }

        // This clears the left and right walls
        if (previousCell.transform.position.x < currentCell.transform.position.x)
        {
            previousCell.ClearRightWall();
            currentCell.ClearLeftWall();
        }
        else if (previousCell.transform.position.x > currentCell.transform.position.x)
        {
            previousCell.ClearLeftWall();
            currentCell.ClearRightWall();
        }

        // This clears the back to front walls
        if (previousCell.transform.position.z < currentCell.transform.position.z)
        {
            previousCell.ClearFrontWall();
            currentCell.ClearBackWall();
        }
        else if (previousCell.transform.position.z > currentCell.transform.position.z)
        {
            previousCell.ClearBackWall();
            currentCell.ClearFrontWall();
        }
    }

}
