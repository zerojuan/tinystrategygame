using UnityEngine;

[System.Serializable]
public struct GridCoordinates {

    [SerializeField]
    private int x, z;

    public int X {
        get {
            return x;
        }
    }

    public int Z {
        get {
            return z;
        }
    }

    public int Y {
        get {
            return -X - Z;
        }
    }

    public GridCoordinates( int x, int z ) {
        this.x = x;
        this.z = z;
    }

    public static GridCoordinates FromPosition( Vector3 position ) {
        float x = position.x / ( GridMetrics.cellWidth );
        float y = x;
        float z = position.z / ( GridMetrics.cellHeight );        

        //Debug.Log( "Position: " + position.ToString() );

        // TODO: do proper coordinate conversion

        return new GridCoordinates( Mathf.RoundToInt( x ) , Mathf.RoundToInt( z ) );
    }

    public override string ToString() {
        return "(" +
            X.ToString() + ", " + Z.ToString() + ")";
    }

    public string ToStringOnSeparateLines() {
        return X.ToString() + "\n" + Z.ToString() + "\n";
    }
}
