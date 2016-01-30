using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	public float speed = 3.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		float fV = Input.GetAxis("Vertical");

		if(fV > 0) {

			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
	}
}
