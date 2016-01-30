using UnityEngine;
using System.Collections;

/// <summary>
/// Generate the level with the seven waves to be jumped
/// </summary>
public class SevenWavesGenerator : MonoBehaviour {

	public Transform wavePrefab; //<

	int numWaves = 7;
	public float[] timeBeforeNextWave = new float[7]; //< distance, in world units, before the next wave
	Transform[] trWaves = new Transform[7];
	float currentLevelTimer;
	public int currentWave = 0;

	// Tools for the designer
	public float baseJumpTime = 3.0f;
	public float varianceBetweenJumpTimes = 0.5f;
	public float waveLifeTime = 5.0f;

	bool playerIsAlive = true;

	float slowMotionSpeed = 0.35f;

	public bool isJumpTimeOn = false;
	public bool playerJumpedWave = false;

	public Transform barPrefab;

	// Use this for initialization
	void Start () {
	
		currentLevelTimer = 0;
		GenerateWavesValues();
		InstantiateWave();
	}

	void Update() {

		if(!playerIsAlive)
			return;

		// DEBUG
		if(isJumpTimeOn && Input.GetButton("Fire1")) {
			// To test: make the jump successful
			playerJumpedWave = true;
			PlayerJumpedWave();
		}
	}

	/// <summary>
	/// </summary>
	void InstantiateWave() {

		// Activate the wave
		trWaves[currentWave] = Instantiate(wavePrefab) as Transform;
		Wave waveScript = trWaves[currentWave].gameObject.GetComponent<Wave>();
		waveScript.SetTimeFromPlayer(timeBeforeNextWave[currentWave], waveLifeTime);

		// Points to the next wave
		currentWave++;
	}
	
	/// <summary>
	/// </summary>
	void GenerateWavesValues() {

		for(int i=0; i<numWaves; i++) {

			timeBeforeNextWave[i] = Random.Range(-varianceBetweenJumpTimes, varianceBetweenJumpTimes) + baseJumpTime;
		}
	}

	/// <summary>
	/// </summary>
	void GameWon() {

		playerIsAlive = false;
	}

	/// <summary>
	/// </summary>
	public void ActivateJumpTime(float jumpTime) {

		// Slows down time
		Time.timeScale = slowMotionSpeed;

		// Instantiate the bar
		Transform trBar = Instantiate(barPrefab) as Transform;
		Bar barScript = trBar.gameObject.GetComponent<Bar>();
		// Set the max jump time in the bar script
		barScript.DurationTime = jumpTime;
		// Set the speed factor for when the game slows down
		barScript.TempDeltaTime = slowMotionSpeed;



		// Activate the bar
		StartCoroutine(JumpBarIsOn(jumpTime * slowMotionSpeed));
	}

	/// <summary>
	/// </summary>
	IEnumerator JumpBarIsOn(float jumpTime) {

		// Bar activated
		playerJumpedWave = false;
		// Activate the bar
		isJumpTimeOn = true;

		// Keeps the bar on for the time specified or until the player hits
		yield return new WaitForSeconds(jumpTime);

		if(!playerJumpedWave) {

			// time ended, player missed the jump
			PlayerFailedToJumpWave();
		}

	}

	/// <summary>
	/// </summary>
	void PlayerJumpedWave() {

		DeactivateJumpTime();
		currentWave++;
		if(currentWave >= numWaves - 1) {

			GameWon();
		}
	}

	/// <summary>
	/// </summary>
	void DeactivateJumpTime() {

		Time.timeScale = 1.0f;
		isJumpTimeOn = false;
	}

	/// <summary>
	/// </summary>
	public void PlayerFailedToJumpWave() {

		Time.timeScale = 0.0f;
		// DEBUG
		Debug.Log("Player failed to jump the wave");

		// TODO: destroy the wave game object
		// Restart level
	}
}
