using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public string PlaySceneName;

	void OnPlayButton () {
		SceneManager.LoadScene (PlaySceneName);
	}

	void OnQuitButton () {
		Application.Quit ();
	}
}
