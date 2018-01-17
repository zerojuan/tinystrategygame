using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

class TimeControls : MonoBehaviour {

  public Text PlayLabel;
  public Text SpeedLabel;

  void Awake() {
    EventManager.StartListening( GameEvent.TOGGLE_PLAY, handleTogglePlay );
    EventManager.StartListening( GameEvent.SET_GAME_SPEED, handleSetGameSpeed );
  }

  public void onPlayClick() {
    EventManager.TriggerEvent( GameEvent.TOGGLE_PLAY );
  }

  public void onSpeedClick(int speed) {
    TSEventData data = new TSEventData();
    data.intVal = speed;
    EventManager.TriggerEvent( GameEvent.SET_GAME_SPEED, data ); 
  }

  private void handleTogglePlay(TSEventData data) {
    if ( PlayLabel.text == "Play" ) {
      PlayLabel.text = "Pause";
    } else {
      PlayLabel.text = "Play";
    }
  }

  private void handleSetGameSpeed(TSEventData data) {
    if ( SpeedLabel.text == "1x" ) {
      SpeedLabel.text = "2x";
    } else {
      SpeedLabel.text = "1x";
    }
  }
} 