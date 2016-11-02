using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class SceneChanger : MonoBehaviour {
	public Canvas canvas;
	private bool fading;
	private float fadeSec;
	private float originalFadeSec;
	private string sceneName;
	private CanvasGroup canvasG;

	private bool startFading;

	// Use this for initialization
	void Start () {
		fading = false;
		sceneName = "";
		canvasG = this.canvas.GetComponent<CanvasGroup> ();

		fadeSec = 3f;
		originalFadeSec = 3f;
		startFading = true;

		canvasG.alpha = 1;
	}
	
	// Update is called once per frame
	void Update () {

		if (fading) {
			fadeSec -= Time.deltaTime;
			canvasG.alpha = (originalFadeSec - fadeSec) / originalFadeSec;
			Debug.Log (fadeSec + " delta:" + Time.deltaTime);
			if (fadeSec <= 0f) {
				fading = false;
				fadeSec = 0f;
				originalFadeSec = 0f;
				SceneManager.LoadScene (sceneName);
			}
		}

		if (startFading) {
			fadeSec -= Time.deltaTime;
			canvasG.alpha = fadeSec / originalFadeSec;
			if (fadeSec <= 0f) {
				startFading = false;
				fadeSec = 0f;
				originalFadeSec = 0f;
			}
		}

	}

	public void changeWidthFadeOut(float fadeSec, string sceneName) {
		this.fadeSec = fadeSec;
		this.originalFadeSec = fadeSec;
		this.sceneName = sceneName;
		fading = true;
	}
}
