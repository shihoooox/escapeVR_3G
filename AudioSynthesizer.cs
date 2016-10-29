using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioSynthesizer : MonoBehaviour {

	public GameObject elevatorStart;
	public GameObject elevatorLoop;
	public GameObject elevatorEnd;
	private Dictionary<int,GameObject> dic = new Dictionary<int,GameObject>();


	// Use this for initialization
	void Start () {
		dic.Add(1, elevatorStart);
		dic.Add(2, elevatorLoop);
		dic.Add(3, elevatorEnd);
	}

	// Update is called once per frame
	void Update () {
	
	}
		
	public AudioSource[] getAudioSource(int audioID){
		//AudioID で指定された GameObject の AudioSource を
		// getComponent()して、得られたインスタンスを返す。
		return dic[audioID].GetComponents<AudioSource>();
	}

}
