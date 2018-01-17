using UnityEngine;
using System.Collections;

public struct CellData {
    public bool HasWater;
    public bool HasRoad;
    public bool HasBuilding;

    public CellData( bool hasWater, bool hasRoad, bool hasBuilding ) {
        this.HasWater = hasWater;
        this.HasRoad = hasRoad;
        this.HasBuilding = hasBuilding;
    }

    public override string ToString() {
        return "Has Water" + this.HasWater + "Has Road: " + this.HasRoad + " Has Building " + this.HasBuilding;
    }
}
