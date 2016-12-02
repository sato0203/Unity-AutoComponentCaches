using UnityEngine;
using System.Collections;
using AutoComponentCathes;

public class AutoComponentCathesExampleSubComponent3 : MonoBehaviour
{
	private AutoComponentCathesExampleMain main { get { return this.AutoFindObject<AutoComponentCathesExampleMain>(); } }
	private SpriteRenderer sp { get { return this.AutoGetComponent<SpriteRenderer>(); } }

	// Use this for initialization
	void Start()
	{
		sp.color = Color.blue;
		transform.position = main.subComponentsPos[2];
	}

	// Update is called once per frame
	void Update()
	{

	}
}
