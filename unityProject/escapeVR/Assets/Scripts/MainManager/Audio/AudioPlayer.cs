using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour {

	public GameObject AudioSynthesizer_G;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update (){
	}


	public void play(int audioID, bool loop, bool play, int delay){
		AudioSynthesizer audioSynthesizer = AudioSynthesizer_G.GetComponent<AudioSynthesizer> ();
		AudioSource[] audioSources = audioSynthesizer.getAudioSource (audioID);

		if (play) {
			ulong udelay = (ulong)44.1 * (ulong)delay;
			audioSources [0].loop = loop;
			audioSources [0].Play (udelay);
		} else {
			audioSources [0].Stop ();
		}
	}


}
