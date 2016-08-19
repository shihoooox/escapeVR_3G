using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour {

	public AudioClip audioClip;
	private AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = this.GetComponent<AudioSource> ();
		audioSource.clip = audioClip;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void play(bool p) {
		audioSource.loop = p;
		audioSource.Play ();
	}
}
