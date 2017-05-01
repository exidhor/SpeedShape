
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Text GameOverTimeText;
	public Image ImageTuto;
	public Text TextTuto;
	public string BlopSceneName;
	public GameObject Canvas;
	public GameObject Sheep;

	[HideInInspector]
	public bool isGameOver = false;

	private Animator canvasAnimator;

	private bool tofuSequence = true;
	private bool blopSequence = false;
	private bool bouftouSequence = false;

	void Awake () {
		DontDestroyOnLoad (gameObject);
		DontDestroyOnLoad (Canvas);
		canvasAnimator = GameObject.FindGameObjectWithTag ("UI").GetComponent<Animator> ();
	}

	void Start () {
		DisplayTuto ("Press space to fly up !");
	}

	void Update () {
		if (isGameOver) {
			if (tofuSequence) {
				tofuSequence = false;
				blopSequence = true;
				SceneManager.LoadScene (BlopSceneName);
				StartCoroutine (DoShapeShiftBlob ());
				isGameOver = false;
			} else if (blopSequence) {
				canvasAnimator.SetTrigger ("Flash");
				SceneManager.LoadScene ("Mouton");
				StartCoroutine (DoShapeShiftBouftou ());
				blopSequence = false;
				isGameOver = false;
			}
			else {
				GameOverTimeText.text = "You survived " + Mathf.RoundToInt (GetComponent<ScoreManager> ().TimeElapsed) + " seconds";
				canvasAnimator.SetBool ("GameOver", true);
				gameObject.SendMessage ("StopCount");
				Destroy (GameObject.FindGameObjectWithTag ("Player"));
				StartCoroutine (end ());
			}
			isGameOver = false;
		}

		if (Input.GetButtonDown ("Jump") || Input.GetButtonDown("Fire1")) {
			RemoveTuto ();
		}
	}

	public void Replay () {
		Debug.Log ("Replay !");
		SceneManager.LoadScene ("FlappyTofu");
	}

	void DisplayTuto (string text) {
		TextTuto.text = text;
		TextTuto.enabled = true;
		ImageTuto.enabled = true;
		Time.timeScale = 0f;
	}

	void RemoveTuto () {
		TextTuto.enabled = false;
		ImageTuto.enabled = false;
		Time.timeScale = 1f;
	}

	IEnumerator DoShapeShiftBlob() {
		yield return new WaitForSeconds (.6f);
		canvasAnimator.SetTrigger ("Flash");
		yield return new WaitForSeconds (.7f);
		GameObject.Find ("SphereBird").SetActive (false);
		GameObject.Find ("ArmatureBird").SetActive (false);
		GameObject.Find ("SphereBlob").GetComponent<SkinnedMeshRenderer> ().enabled = true;
		yield return new WaitForSeconds (.6f);
		DisplayTuto("Hold space to jump higher !");
		yield return new WaitForSeconds (.1f);
		DisplayTuto("Press space to jump higher while climbing");
		yield return new WaitForSeconds (.1f);
		DisplayTuto("You can't jump higher while coming down ");
	}

	IEnumerator DoShapeShiftBouftou() {
		yield return new WaitForSeconds (.6f);
		DisplayTuto("Hold CTRL to Dash !");
	}

	IEnumerator end() {
		yield return new WaitForSeconds (5f);
		SceneManager.LoadScene ("MenuLeRetour");
		Destroy(GameObject.Find("Canvas"));
		Destroy (GameObject.FindGameObjectWithTag ("GameController"));
	}
}
