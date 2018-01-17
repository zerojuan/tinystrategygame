using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {
  public GameObject gameManagerPrefab;
  void Awake() {
    if ( GameManager.instance == null ) {
      Instantiate( gameManagerPrefab );
    }
  }
}