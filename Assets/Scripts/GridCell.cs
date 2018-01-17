using UnityEngine;
using System.Collections;

public class GridCell : MonoBehaviour {
    public RectTransform uiRect;
    public GridCoordinates coordinates;
    public CellData data;   

    public Vector3 Position {
        get {
            return transform.localPosition;
        }
    }

    public int Elevation {
        get {
            return elevation;
        }
        set {
            if (elevation == value) {
                return;
            }
            elevation = value;
            Vector3 position = transform.localPosition;
            position.y = value;
            transform.localPosition = position;

            Vector3 uiPosition = uiRect.localPosition;
            uiPosition.z = -position.y;
            uiRect.localPosition = uiPosition;            
            
        }
    }

    int elevation = int.MinValue;

    [SerializeField]
    GridCell[] neighbors;

    public GridCell GetNeighbor( GridDirection direction ) {
        return neighbors[ ( int )direction ];
    }

    public bool IsNeighborRoad( GridDirection direction ) {
        if (GetNeighbor( direction ) == null) {
            return true;
        }
        return GetNeighbor( direction ).data.HasRoad;
    }

    public void SetNeighbor( GridDirection direction, GridCell cell ) {
        neighbors[ ( int )direction ] = cell;        
        cell.neighbors[ ( int )direction.Opposite() ] = this;
    }

    public override string ToString() {
        return this.coordinates.ToString();
    }

    public byte AreNeighborsRoad() {
        byte b = 0; // 0000 0000

        for (int i = 0; i < 8; i++) {
            if (IsNeighborRoad( ( GridDirection )i )) {                
                b ^= (byte)( 1 << i );
            }            
        }

        return b;
    }
}
