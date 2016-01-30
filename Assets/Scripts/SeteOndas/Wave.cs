using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {

	SevenWavesGenerator controlScript;
	public float speed = 3.0f;
	public float scaleSpeed = 0.3f;
	public float deltaTime;

	
	void Awake() {

		controlScript = transform.Find("/LevelControl").gameObject.GetComponent<SevenWavesGenerator>();

		if(controlScript == null) {

			Debug.Log(this.transform + "LevelControl");
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	/// <summary>
	/// </summary>
	void Update () {

		transform.localScale += new Vector3(scaleSpeed * Time.deltaTime, scaleSpeed * Time.deltaTime,0);
	}
	
	/// <summary>
	/// </summary>
	public void SetTimeFromPlayer(float jumpTime, float lifeTime) {

		// Calculate how much time the player will have to jump the wave
		deltaTime = lifeTime - jumpTime;

		float scaleFromPlayer = scaleSpeed / jumpTime;
		Vector3 newScale = new Vector3(scaleFromPlayer,scaleFromPlayer,0);
		transform.localScale = newScale;

		StartCoroutine(ActivateJumpTime(deltaTime, jumpTime));
	}

	/// <summary>
	/// </summary>
	IEnumerator ActivateJumpTime(float timeToActivateJump, float jumpTime) {


		// This is the time the player have to hit the jump
		yield return new WaitForSeconds(timeToActivateJump);
		controlScript.ActivateJumpTime(jumpTime);
	}
}
