using UnityEngine;
using System.Collections;

public class ElevatorButton : MonoBehaviour {

	private Renderer _renderer;

	// Use this for initialization
	void Start () {
		_renderer = GetComponent<Renderer>();
		//StartCoroutine(BlinkerCoroutine());
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void forInstanceMotion(int actNum){	
		if(actNum == 1) {
			//光る処理
			_renderer.material.EnableKeyword("_EMISSION");
			_renderer.material.SetColor ("_EmissionColor", new Color (1, 1, 1));
			return;
		}else if(actNum == 2){
			_renderer.material.EnableKeyword("_EMISSION");
			_renderer.material.SetColor("_EmissionColor", new Color(0, 0, 0));
			return;
		}
	}
}
