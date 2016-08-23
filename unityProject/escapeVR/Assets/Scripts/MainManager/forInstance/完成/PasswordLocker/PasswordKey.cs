using UnityEngine;
using System.Collections;

public class PasswordKey : MonoBehaviour {

	// 光らせるためのスクリプト
	// 数字のとこにつけてね

	public int keyCode;

	private Renderer _renderer;

	// Use this for initialization
	void Start () {
		_renderer = GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update () {
	}

	public void hikaru(){	
		_renderer.material.EnableKeyword("_Color");
		_renderer.material.SetColor ("_Color", new Color(0f, 0f, 0f, 0.5f));
	}

	public void kesu(){
		_renderer.material.EnableKeyword("_Color");
		_renderer.material.SetColor ("_Color", new Color(0f, 0f, 0f, 0f));
	}	
}
