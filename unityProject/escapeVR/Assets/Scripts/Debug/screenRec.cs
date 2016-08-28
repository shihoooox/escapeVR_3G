using UnityEngine;
using System.Collections;
using System;

public class screenRec : MonoBehaviour {

	public int framerate;
	public int superSize;
	public float animationLengthSec;
	public bool autoRecord;
	public bool autoEndRecording;
	public bool press_C_to_capture;

	private int frameCount = -1;
	private bool recording;
	private int captureCount = 0;

	// Use this for initialization
	void Start () {
		if (autoRecord)
			this.startRecording ();
		if(press_C_to_capture) {
			System.IO.Directory.CreateDirectory ("CaptureOnlyFrame");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (recording) 
			this.recordingPath ();

		if (press_C_to_capture && Input.GetKeyDown (KeyCode.C))
			this.capturePath();

		Debug.Log ("current frame : " + frameCount);
	}

	void capturePath() {
		String name = "CaptureOnlyFrame/capture" + captureCount + ".png";
		Application.CaptureScreenshot (name, superSize);
		captureCount++;
		Debug.Log ("captured in : " + name);
	}

	void endRecordingPath() {
		if (frameCount > framerate * animationLengthSec) {
			Debug.Log ("end recording path");
			Application.Quit ();
		}

	}

	void recordingPath() {
		if (frameCount > 0) {
			String name = "Capture/frame" + frameCount.ToString ("0000") + ".png";
			Application.CaptureScreenshot (name, superSize);
		}
		frameCount++;
		if (frameCount > 0 && frameCount % 60 == 0) {
			Debug.Log ((frameCount / 60).ToString() + " seconds elapsed.");
		}
	}

	void startRecording() {
		System.IO.Directory.CreateDirectory ("Capture");
		Debug.Log ("capture and output to : " + System.IO.Directory.GetCurrentDirectory());
		Time.captureFramerate = framerate;
		frameCount = -1;
		recording = true;
	}
}
