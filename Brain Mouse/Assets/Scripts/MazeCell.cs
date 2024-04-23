using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField]
    private GameObject _leftWall;

    [SerializeField] 
    private GameObject _rightWall;

    [SerializeField]
    private GameObject _frontWall;

    [SerializeField]
    private GameObject _backWall;

    [SerializeField]
    private GameObject _unvisitedBlock;
    
    // Add a boolean property that tells me if the cell has been visiten by the maze generator.

    public bool IsVisited { get; private set; }

    // Create some helper methods
    
    public void Visit()
    {
        IsVisited = true;
        _unvisitedBlock.SetActive(false);
    }

    //Helper methods that will clear each of the walls

    public void ClearLeftWall()
    { 
        _leftWall.SetActive(false); 
    }

    public void ClearFrontWall()
    {
        _frontWall.SetActive(false);
    }

    public void ClearBackWall()
    {
        _backWall.SetActive(false);
    }

    public void ClearRightWall()
    {
        _rightWall.SetActive(false);

    }
}
