using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
  private LevelGrid levelGrid;

    private void Start()
    {
        levelGrid = new LevelGrid(20, 20);
    }
}
