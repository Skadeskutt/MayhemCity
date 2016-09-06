using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    [Range(1f, 100f)]
    public float movementSpeed = 50.0f;
    [Range(1f, 150f)]
    public float movementSuperSpeed = 100.0f;
    [Range(0.1f, 10f)]
    public float mouseRotateSense = 7f;
    [Range(0.1f, 10f)]
    public float zoomModifier = 2f;
    [Range(0.1f, 1000f)]
    public float zoomMaxClamp = 50f;
    [Range(0.1f, 1000f)]
    public float zoomMinClamp = 150f;

    private Vector3 moveDirection = Vector3.zero;
    private GameObject cam;

    private float zoomY = 500f;
    private float zoomZ = -500f;

    void Awake() {
        cam = gameObject.GetComponentInChildren<Camera>().gameObject;
    }
	
	void Update() {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection *= Input.GetKey(KeyCode.Space) ? movementSuperSpeed : movementSpeed;
        moveDirection *= (zoomY / 100f);
        transform.Translate(moveDirection * Time.deltaTime);

        if(Input.GetMouseButton(1) || Input.GetMouseButton(2)) {
            transform.Rotate(new Vector3(0f, Input.GetAxis("Mouse X") * mouseRotateSense, 0f));
        }

        if(zoomMaxClamp >= zoomMinClamp) {
            zoomMaxClamp = zoomMinClamp - 0.1f;
        }

        zoomY -= Input.mouseScrollDelta.y * zoomModifier;
        zoomZ += Input.mouseScrollDelta.y * zoomModifier;

        zoomY = Mathf.Clamp(zoomY, zoomMaxClamp, zoomMinClamp);
        zoomZ = Mathf.Clamp(zoomZ, -zoomMinClamp, -zoomMaxClamp);

        cam.transform.localPosition = new Vector3(0f, zoomY, zoomZ);
    }
}
