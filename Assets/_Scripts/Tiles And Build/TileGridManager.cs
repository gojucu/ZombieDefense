using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class TileGridManager : MonoBehaviour
{

    //place
    [ReadOnly]
    public Vector2 gridPos;
    string coordinates;

    const int gridSize = 3;//Tile büyüklüğü

    public int GetGridSize()
    {
        return gridSize;
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }
    public Vector3 GetGridPos()
    {
        return new Vector3
        (
        Mathf.RoundToInt(transform.position.x / gridSize),
        0,
        Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }
    public Vector2 GetVector2Pos()
    {
        gridPos = new Vector2Int((int)GetGridPos().x, (int)GetGridPos().z);
        return gridPos;
    }


    private void SnapToGrid()
    {
        int gridSize = GetGridSize();
        transform.position = new Vector3(
            GetGridPos().x * gridSize,
            0,
            GetGridPos().z * gridSize
            );
    }
    public void UpdateLabel()
    {
        //TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = GetGridPos().x + "," + GetGridPos().z;
        gridPos = new Vector2Int((int)GetGridPos().x, (int)GetGridPos().z);
        //textMesh.text = labelText;
        coordinates = labelText;
        gameObject.name = "Tile "+ labelText;

    }


}
