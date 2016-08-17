using UnityEngine;
using System.Collections;

public class PasswordKey : MonoBehaviour {

	// 光らせるためのスクリプト
	// 数字のとこにつけてね

	private Renderer _renderer;

	// Use this for initialization
	void Start () {
		_renderer = GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update () {
	}

	public void hikaru(){	
		_renderer.material.EnableKeyword("_EMISSION");
		_renderer.material.SetColor ("_EmissionColor", new Color (1, 1, 1));
	}

	public void kesu(){
		_renderer.material.EnableKeyword("_EMISSION");
		_renderer.material.SetColor ("_EmissionColor", new Color (0, 0, 0));
	}	
}
