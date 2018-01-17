using UnityEngine.Events;

public class GameEvent : UnityEvent<TSEventData> {
  public const string TOGGLE_PLAY = "ts_toggle_play";
  public const string SET_GAME_SPEED = "ts_set_game_speed";
}