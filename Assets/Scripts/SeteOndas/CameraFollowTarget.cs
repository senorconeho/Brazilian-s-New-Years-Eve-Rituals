using UnityEngine;
using System.Collections;

/// <summary>
/// Makes a camera follow an object. When the camera hits the game screen limits it's stops following
/// </summary>
public class CameraFollowTarget : MonoBehaviour {

	public Transform	trTarget;				//< target to follow (any of the players characters)
	Camera cam;
	Transform tr;
	float fDistanceFromPlayer;
	/* -----------------------------------------------------------------------------------------------------------
	 * UNITY
	 * -----------------------------------------------------------------------------------------------------------
	 */

	void Awake() {

		cam = gameObject.GetComponent<Camera>();	
		tr = this.transform;
	}

	// Use this for initialization
	void Start () {

		fDistanceFromPlayer = tr.transform.position.z - trTarget.position.z;
	}
	
	/// <summary>
	///
	/// </summary>
	void LateUpdate() {

		if(trTarget == null)
			return;

		Vector3 vTargetPosition = trTarget.position;	// The position of the target in the world
		Vector3 vCurrentCameraPosition = tr.position;	// Current camera position


		// Follow target
		Vector3 vNewPosition = new Vector3(vTargetPosition.x, tr.position.y, vTargetPosition.z + fDistanceFromPlayer);
		tr.position = vNewPosition;
	}
 }
