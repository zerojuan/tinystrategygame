using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

class GameManager : MonoBehaviour {
  public static GameManager instance;

  public Text dayTitle;

  private float gameTime;
  private float gameSpeed = 1.0f;

  void Awake() {
    if ( instance == null ) {
      instance = this;
    } else if ( instance != this ) {
      Destroy( gameObject );
    }

    DontDestroyOnLoad( gameObject );

    gameTime = 0;

    EventManager.StartListening( GameEvent.TOGGLE_PLAY, onTogglePlay );
    EventManager.StartListening( GameEvent.SET_GAME_SPEED, onSetGameSpeed );

    InitGame();
  }

  void InitGame() {
    // This is the initial game
    dayTitle = GameObject.Find( "DayTitle" ).GetComponent<Text>();

    dayTitle.text = "WTF";
  }

  void showTime() {
    gameTime += Time.deltaTime;

    double hour = Math.Floor( gameTime % 24 );
    double day = Math.Floor( gameTime / 24 );

    dayTitle.text = String.Format("D: {0} H: {1}", day + 1, hour );
  }

  void onTogglePlay( TSEventData data ) {
    if ( Time.timeScale > 0.0f ) {
      Time.timeScale = 0f;
    } else {
      Time.timeScale = gameSpeed;
    }
  }

  void onSetGameSpeed( TSEventData data ) {
    if ( Time.timeScale == 1.0f ) {
      Time.timeScale = gameSpeed = 2.0f;
    } else {
      Time.timeScale = gameSpeed = 1.0f;
    }
  }

  void Update() {
    showTime();
  }
}