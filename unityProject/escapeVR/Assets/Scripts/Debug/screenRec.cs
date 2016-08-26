using UnityEngine;
using System.Collections;
using System;

public class screenRec : MonoBehaviour {

	public int framerate;
	public int superSize;
	public float animationLengthSec;
	public bool autoRecord;
	public bool autoEndRecording;

	private int frameCount = -1;
	private bool recording;

	// Use this for initialization
	void Start () {
		if (autoRecord)
			this.startRecording ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (recording) 
			this.recordingPath ();

		if (autoEndRecording)
			this.endRecordingPath ();

		Debug.Log ("current frame : " + frameCount);
	}

	void endRecordingPath() {
		if (frameCount > framerate * animationLengthSec) {
			Debug.Log ("end recording path");
			Application.Quit ();
		}

	}

	void recordingPath() {
		if (Input.GetKeyDown (KeyCode.C)) {
			recording = false;
			enabled = false;
		} else {
			if (frameCount > 0) {
				String name = "Capture/frame" + frameCount.ToString ("0000") + ".png";
				Application.CaptureScreenshot (name, superSize);
			}
			frameCount++;
			if (frameCount > 0 && frameCount % 60 == 0) {
				Debug.Log ((frameCount / 60).ToString() + " seconds elapsed.");
			}
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
