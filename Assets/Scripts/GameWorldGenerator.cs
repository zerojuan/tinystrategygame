using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using tokhang.model;

public class GameWorldGenerator : MonoBehaviour {
    public World world;

    public float budget = 10000.00f;

    void Start () {
        world = new World();
    }
}