using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour {

	public GameObject AudioSynthesizer_G;

	// Use this for initialization
	void Start () {
		play (1,true,true,1000);
	}
	
	// Update is called once per frame
	void Update (){
		
	}

	void play(int audioID, bool loop, bool play, int delay){
		AudioSource[] sources = null;

		if (play) {
			AudioSynthesizer audioSource = AudioSynthesizer_G.GetComponent<AudioSynthesizer> ();
			GameObject o = audioSource.getAudioSource (audioID);
			sources = o.GetComponents<AudioSource> ();
			sources [0].loop = loop;

			ulong udelay = (ulong)44.1 * (ulong)delay;

			sources [0].Play (udelay);
		} else {
			sources [0].Stop ();
		}
	}


}
