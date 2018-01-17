using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GridMap : MonoBehaviour {
    public int cellCountX;
    public int cellCountY;

    private Canvas gridCanvas;
    private GridMesh gridMesh;

    public GridCell GridCellPrefab;
    public Text CellLabelPrefab;
    // public House3D House1x1Prefab;
    // public House3D House2x1Prefab;
    // public House3D House1x2Prefab;
    // public House3D House2x2Prefab;

    // public DistrictFeature Plaza;    

    GridCell[] cells;

    // private List<House3D> houses = new List<House3D>();

    private void Awake() {
        gridCanvas = GetComponentInChildren<Canvas>();
        gridMesh = GetComponentInChildren<GridMesh>();       

        // CreateCells();
    }
/*
    private void Start() {
        ShowUI( false );

        gridMesh.Triangulate( cells );
    }

    void CreateCells() {
        cellCountX = GridMetrics.gridWidth;
        cellCountY = GridMetrics.gridHeight;

        cells = new GridCell[ cellCountX * cellCountY ];

        for (int y = 0, i = 0; y < cellCountY; y++) {
            for (int x = 0; x < cellCountX; x++) {
                CreateCell( x, y, i++ );
            }
        }

    }

    void CreateCell( int x, int y, int i ) {
        Vector3 position;
        position.x = x * ( GridMetrics.cellWidth );
        position.y = 0f;
        position.z = y * ( GridMetrics.cellHeight );

        GridCell cell = cells[ i ] = Instantiate<GridCell>( GridCellPrefab );
        cell.coordinates = new GridCoordinates( x, y );
        cell.data = new CellData( false, false, false );

        // E - W neighbors
        if (x > 0) {            
            cell.SetNeighbor( GridDirection.W, cells[ i - 1 ] );
        }

        if (y > 0) {
            // every odd row
            //if (( y & 1 ) != 0) {                
                cell.SetNeighbor( GridDirection.S, cells[ i - cellCountX ] );
                if (x > 0) {
                    cell.SetNeighbor( GridDirection.SW, cells[ i - cellCountX - 1 ] );
                }
                if (x < cellCountX - 1) {
                    cell.SetNeighbor( GridDirection.SE, cells[ i - cellCountX + 1 ] );
                }
            //}        
        }

        cell.transform.localPosition = position;
        cell.transform.SetParent( transform, false );

        Text label = Instantiate<Text>( CellLabelPrefab );
        label.rectTransform.anchoredPosition =
            new Vector2( position.x, position.z );
        
        label.text = cell.coordinates.ToString();
        cell.uiRect = label.rectTransform;
        cell.uiRect.SetParent( gridCanvas.transform, false );
        cell.Elevation = 0;
    }

    void SetCell( int x, int y, CellData data ) {
        var cell = GetCell( x, y );
        cell.data = data;
    }

    public GridCell GetCell( int x, int y ) {
        int index = x + (cellCountX * y);
        if ( index < 0 || index > cells.Length )
        {
            return null;
        }

        return cells[ x + ( cellCountX * y ) ];
    }

    public GridCell GetCell( Vector3 position ) {
        position = transform.InverseTransformPoint( position );
        Debug.Log( "Beff" );
        GridCoordinates coordinates = GridCoordinates.FromPosition( position );
        Debug.Log( "Coords: " + coordinates.ToString() );                      
        return GetCell( coordinates.X, coordinates.Z ) ;
    }

    public bool CanPlaceBuilding( GridCell cell, int width, int height ) {
        var coordinates = cell.coordinates;
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                var coords = new GridCoordinates( coordinates.X + x, coordinates.Z + y );
                var c = GetCell( coords.X, coords.Z );
                if (c.data.HasBuilding || c.data.HasRoad || c.data.HasWater) {
                    return false;
                }
            }
        }

        return true;
    }

    public House3D AddBuilding( GridCell cell, int width, int height ) {
        // set cell and neighbors as building
        var coordinates = cell.coordinates;
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                var coords = new GridCoordinates( coordinates.X + x, coordinates.Z + y );
                var c = GetCell( coords.X, coords.Z );
                c.data.HasBuilding = true;
            }
        }

        House3D house;
        if (width == 1 && height == 1) {
            house = Instantiate<House3D>( House1x1Prefab );
        } else if (width == 2 && height == 1) {
            house = Instantiate<House3D>( House2x1Prefab );
        } else if (width == 1 && height == 2) {
            house = Instantiate<House3D>( House1x2Prefab );
        } else {
            house = Instantiate<House3D>( House2x2Prefab );
        }

        house.transform.localPosition = cell.transform.localPosition;
        house.transform.SetParent( transform, false );

        houses.Add(house);

        return house;
    }

    public void ClearBuildings()
    {        
        foreach( House3D house in houses )
        {
            Destroy(house.gameObject);
        }
        houses = new List<House3D>();
    }

    public void ClearMap()
    {
        for( int x = 0; x < cellCountX; x++ )
        {
            for( int y = 0; y < cellCountY; y++ )
            {
                GridCell cell = GetCell(x, y);
                if ( cell != null )
                {
                    cell.data = new CellData(false, false, false);
                }
            }
        }
    }

    public void RemoveBuilding( GridCell cell ) {

    }

    public void ShowUI( bool val ) {
        gridCanvas.gameObject.SetActive( val );
    }

    public void Refresh() {
        gridMesh.Triangulate( cells );
    }
*/
    // Update is called once per frame
    void Update() {

    }
}
