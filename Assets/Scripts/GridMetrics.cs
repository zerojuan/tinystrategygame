using UnityEngine;
using System.Collections;

public static class GridMetrics {

    public const int gridWidth = 30;
    public const int gridHeight = 30;

    public const float cellWidth = 3f;
    public const float cellHeight = 3f;

    public static Vector3[] Corners = {
        new Vector3( 0 - (cellWidth/2), 0,  0 - (cellHeight/2) ),
        new Vector3( 0 + (cellWidth/2), 0, 0 - (cellHeight/2) ),
        new Vector3( 0 + (cellWidth/2), 0, 0 + (cellHeight/2) ),
        new Vector3( 0 - (cellWidth/2), 0, 0 + (cellHeight/2) )
    };

}
