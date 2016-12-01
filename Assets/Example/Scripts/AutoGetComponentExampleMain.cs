using UnityEngine;
using System.Collections;

public class AutoGetComponentExampleMain : MonoBehaviour {

	AutoGetComponent<SpriteRenderer> sp = new AutoGetComponent<SpriteRenderer>();

	// Use this for initialization
	void Start () {
		sp.Instance(this).color = new Color(1, 1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
