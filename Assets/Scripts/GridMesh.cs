using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( MeshFilter ), typeof( MeshRenderer ) )]
public class GridMesh : MonoBehaviour {
    public int xSize, ySize;

    public Texture2D terrainSpriteSheet;
    public int tileResolution = 64;

    private MeshFilter meshFilter;
    private List<Vector2> UVArray;
    private Mesh mesh;
    private MeshCollider meshCollider;

    private List<Vector3> vertices = new List<Vector3>();
    private List<Vector2> uv = new List<Vector2>();
    private List<int> triangles = new List<int>();

    private float tileWidth = 9f;
    private float tileHeight = 9f;

    private void Awake() {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        meshCollider = gameObject.AddComponent<MeshCollider>();
        mesh.name = "Procedural Grid";
    }

    void Start() {
    }

    public void Triangulate( GridCell[] cells ) {
        mesh.Clear();
        vertices.Clear();
        uv.Clear();
        triangles.Clear();
        //uv[ i ] = new Vector2( ( float )x / xSize, ( float )( y ) / ySize );        
        for (int i = 0; i < cells.Length; i++) {
            Triangulate( cells[ i ] );
        }
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uv.ToArray();

        mesh.RecalculateNormals();
        meshCollider.sharedMesh = mesh;
    }

    void Triangulate( GridCell cell ) {
        Vector3 center = cell.Position;
        // create corner vertices
        Vector3 v1 = center + GridMetrics.Corners[ 0 ];
        Vector3 v2 = center + GridMetrics.Corners[ 1 ];
        Vector3 v3 = center + GridMetrics.Corners[ 2 ];
        Vector3 v4 = center + GridMetrics.Corners[ 3 ];

        AddQuad( v1, v2, v3, v4 );
        SetTile( cell );
    }

    void AddQuad( Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4 ) {
        int vertexIndex = vertices.Count;
        vertices.Add( v1 );
        vertices.Add( v2 );
        vertices.Add( v3 );
        vertices.Add( v4 );
        triangles.Add( vertexIndex );
        triangles.Add( vertexIndex + 3 );
        triangles.Add( vertexIndex + 1 );
        triangles.Add( vertexIndex + 1 );
        triangles.Add( vertexIndex + 3 );
        triangles.Add( vertexIndex + 2 );
    }

    void SetTile( GridCell cell ) {        
        if (cell.data.HasRoad && cell.data.HasWater) {
            SetTile( new Vector2( 4, 0 ) );
            // draw bridge
        } else if (cell.data.HasRoad) {
            var neighbors = cell.AreNeighborsRoad();
            if (neighbors == 255) { // 1111 1111
                SetTile( TileSpriteMap.ROAD_8 );
            } else if (neighbors == 85) { // 1111 1101
                SetTile( TileSpriteMap.ROAD_0 );
            } else if (neighbors == 85) { // 0101 0101
                SetTile( TileSpriteMap.ROAD_0 );
            } else if (neighbors == 215) { // 1101 0111
                SetTile( TileSpriteMap.ROAD_EWST_2 );
            } else if (neighbors == 125) { // 0111 1101
                SetTile( TileSpriteMap.ROAD_EWNT_2 );
            } else if (neighbors == 245) { // 1111 0101
                SetTile( TileSpriteMap.ROAD_NSET_2 );
            } else if (neighbors == 95) { // 1111 1010                
                SetTile( TileSpriteMap.ROAD_NSWT_2 );
            } else if (cell.IsNeighborRoad( GridDirection.E ) &&
                        cell.IsNeighborRoad( GridDirection.W ) &&
                        cell.IsNeighborRoad( GridDirection.N ) &&
                        cell.IsNeighborRoad( GridDirection.NE ) &&
                        cell.IsNeighborRoad( GridDirection.NW )) {
                SetTile( TileSpriteMap.ROAD_EWS_2 );
            } else if (cell.IsNeighborRoad( GridDirection.E ) &&
                        cell.IsNeighborRoad( GridDirection.W ) &&
                        cell.IsNeighborRoad( GridDirection.S ) &&
                        cell.IsNeighborRoad( GridDirection.SE ) &&
                        cell.IsNeighborRoad( GridDirection.SW )) {
                SetTile( TileSpriteMap.ROAD_EWN_2 );
            } else if (cell.IsNeighborRoad( GridDirection.S ) &&
                        cell.IsNeighborRoad( GridDirection.N ) &&
                        cell.IsNeighborRoad( GridDirection.E ) &&
                        cell.IsNeighborRoad( GridDirection.NE ) &&
                        cell.IsNeighborRoad( GridDirection.SE )) {
                SetTile( TileSpriteMap.ROAD_NSW_2 );
            } else if (cell.IsNeighborRoad( GridDirection.S ) &&
                        cell.IsNeighborRoad( GridDirection.N ) &&
                        cell.IsNeighborRoad( GridDirection.W ) &&
                        cell.IsNeighborRoad( GridDirection.NW ) &&
                        cell.IsNeighborRoad( GridDirection.SW )) {
                SetTile( TileSpriteMap.ROAD_NSE_2 );
            } else if (cell.IsNeighborRoad( GridDirection.E ) &&
                        cell.IsNeighborRoad( GridDirection.W ) &&
                        cell.IsNeighborRoad( GridDirection.N )) {
                SetTile( TileSpriteMap.ROAD_NT_1 );
            } else if (cell.IsNeighborRoad( GridDirection.E ) &&
                        cell.IsNeighborRoad( GridDirection.W ) &&
                        cell.IsNeighborRoad( GridDirection.S )) {
                SetTile( TileSpriteMap.ROAD_ST_1 );
            } else if (cell.IsNeighborRoad( GridDirection.S ) &&
                        cell.IsNeighborRoad( GridDirection.N ) &&
                        cell.IsNeighborRoad( GridDirection.E )) {
                SetTile( TileSpriteMap.ROAD_WT_1 );
            } else if (cell.IsNeighborRoad( GridDirection.S ) &&
                        cell.IsNeighborRoad( GridDirection.N ) &&
                        cell.IsNeighborRoad( GridDirection.W )) {
                SetTile( TileSpriteMap.ROAD_ET_1 );
            } else if (cell.IsNeighborRoad( GridDirection.E ) &&
                        cell.IsNeighborRoad( GridDirection.N )) {
                SetTile( TileSpriteMap.ROAD_WN_1 );
            } else if (cell.IsNeighborRoad( GridDirection.E ) &&
                        cell.IsNeighborRoad( GridDirection.S )) {
                SetTile( TileSpriteMap.ROAD_WS_1 );
            } else if (cell.IsNeighborRoad( GridDirection.W ) &&
                        cell.IsNeighborRoad( GridDirection.S )) {
                SetTile( TileSpriteMap.ROAD_ES_1 );
            } else if (cell.IsNeighborRoad( GridDirection.W ) &&
                        cell.IsNeighborRoad( GridDirection.N )) {
                SetTile( TileSpriteMap.ROAD_EN_1 );
            } else if (cell.IsNeighborRoad( GridDirection.E ) &&
                        cell.IsNeighborRoad( GridDirection.W )) {
                SetTile( TileSpriteMap.ROAD_EW_1 );
            } else if (cell.IsNeighborRoad( GridDirection.S ) &&
                        cell.IsNeighborRoad( GridDirection.N )) {
                SetTile( TileSpriteMap.ROAD_NS_1 );
            } else if (cell.IsNeighborRoad( GridDirection.E )) {
                SetTile( TileSpriteMap.ROAD_W_END );
            } else if (cell.IsNeighborRoad( GridDirection.W )) {
                SetTile( TileSpriteMap.ROAD_E_END );
            } else if (cell.IsNeighborRoad( GridDirection.N )) {
                SetTile( TileSpriteMap.ROAD_S_END );
            } else if (cell.IsNeighborRoad( GridDirection.S )) {
                SetTile( TileSpriteMap.ROAD_N_END );
            } else {
                SetTile( TileSpriteMap.ROAD_0 );
            }

            // draw road
        } else if (cell.data.HasWater) {
            SetTile( new Vector2( 0, 4 ) );
            // draw water
        } else if (cell.data.HasBuilding) {
            // draw building
            SetTile( new Vector2( 6, 6 ) );
        } else {
            // draw ground
            SetTile( new Vector2( 6, 5 ) );
        }

    }

    void SetTile( Vector2 point ) {
        float x = point.x;
        float y = point.y;
        uv.Add( new Vector2( x / tileWidth, y / tileHeight ) );
        uv.Add( new Vector2( ( x + 1f ) / tileWidth, y / tileHeight ) );
        uv.Add( new Vector2( ( x + 1f ) / tileWidth, ( y + 1f ) / tileHeight ) );
        uv.Add( new Vector2( x / tileWidth, ( y + 1f ) / tileHeight ) );
    }

    private void OnDrawGizmos() {
        if (vertices == null) {
            return;
        }
        Gizmos.color = Color.black;
        for (int i = 0; i < vertices.Count; i++) {
            Gizmos.DrawSphere( vertices[ i ], 0.1f );
        }
    }
}
