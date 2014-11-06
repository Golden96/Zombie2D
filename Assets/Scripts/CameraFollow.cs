using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float damping = 1;
	public float lookAheadFactor = 3;
	public float lookAheadReturnSpeed = 0.5f;
	public float lookAheadMoveThreshold = 0.1f;
	public float yPosRestiction = -1;

	float offsetZ;
	Vector3 lastTargetPosition;// Esta dando la ultima posicion del personaje.
	Vector3 currentVelocity;//Velocidad del personaje.
	Vector3 lookAheadPos;//Posicion actual del personaje.

	// Use this for initialization
	void Start () {
		lastTargetPosition = target.position;//La ultima posicion del personaje es igual a la posicion 
		offsetZ = (transform.position - target.position).z;
		transform.parent = null;
	}
	
	// Update is called once per frame
	void Update () {
		
		// only update lookahead pos if accelerating or changed direction
		float xMoveDelta = (target.position - lastTargetPosition).x;
		
		bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;
		
		if (updateLookAheadTarget) {
			lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
		} else {
			lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
		}
		
		Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
		Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);
		
		newPos = new Vector3(newPos.x, Mathf.Clamp(newPos.y,yPosRestiction,Mathf.Infinity), newPos.z);
		transform.position = newPos;
		
		lastTargetPosition = target.position;		
	}
}