using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationCreator : MonoBehaviour {

	public GameObject actorPrefab;

	public Transform[] actors = new Transform[ 10 ];
	// Use this for initialization
	void Start () {
		for( var i = 0; i < 10; i++ ) {
			actors[ i ] = Instantiate( actorPrefab ).GetComponent<Transform>();
			actors[ i ].position = new Vector3( i + 10, 0, 2 );
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
