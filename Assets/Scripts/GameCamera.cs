using UnityEngine;

public class GameCamera : MonoBehaviour {
    public float swivelMinZoom, swivelMaxZoom;
    public float stickMinZoom, stickMaxZoom;
    public float moveSpeedMinZoom, moveSpeedMaxZoom;
    public float rotationSpeed;
    public float moveSpeed;

    private Transform swivel, stick;

    float zoom = 1f;
    float rotationAngle;

    void Awake() {
        swivel = transform.GetChild( 0 );
        stick = swivel.GetChild( 0 );
    }

    void Update() {
        float zoomDelta = Input.GetAxis( "Mouse ScrollWheel" );
        if (zoomDelta != 0f) {
            AdjustZoom( zoomDelta );
        }

        float rotationDelta = Input.GetAxis( "Rotation" );
        if (rotationDelta != 0f) {
            AdjustRotation( rotationDelta );
        }

        float xDelta = Input.GetAxis( "Horizontal" );
        float zDelta = Input.GetAxis( "Vertical" );
        if (xDelta != 0f || zDelta != 0f) {
            AdjustPosition( xDelta, zDelta );
        }
    }

    void AdjustZoom( float delta ) {
        zoom = Mathf.Clamp01( zoom + delta );

        // zoom in and out
        float distance = Mathf.Lerp( stickMinZoom, stickMaxZoom, zoom );
        stick.localPosition = new Vector3( 0f, 0f, distance );

        // go to a flatter angle as you zoom out
        float angle = Mathf.Lerp( swivelMinZoom, swivelMaxZoom, zoom );
        swivel.localRotation = Quaternion.Euler( angle, 0f, 0f );
    }

    void AdjustRotation( float delta ) {
        rotationAngle += delta * rotationSpeed * Time.deltaTime;
        if (rotationAngle < 0f) {
            rotationAngle += 360f;
        } else if (rotationAngle >= 360f) {
            rotationAngle -= 360f;
        }
        transform.localRotation = Quaternion.Euler( 0f, rotationAngle, 0f );
    }

    void AdjustPosition( float xDelta, float zDelta ) {
        Vector3 direction = 
            transform.localRotation 
            * new Vector3(xDelta, 0f, zDelta).normalized;
		float damping = Mathf.Max(Mathf.Abs(xDelta), Mathf.Abs(zDelta));
		float distance =
			Mathf.Lerp(moveSpeedMinZoom, moveSpeedMaxZoom, zoom) *
			damping * Time.deltaTime;

		Vector3 position = transform.localPosition;
		position += direction * distance;
		transform.localPosition = position;
    }
}