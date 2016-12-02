using UnityEngine;
using System.Collections;
using AutoComponentCathes;

public class AutoComponentCathesExampleSubComponent2 : MonoBehaviour
{
	private AutoComponentCathesExampleMain main { get { return this.AutoFindObject<AutoComponentCathesExampleMain>(); } }
	private SpriteRenderer sp { get { return this.AutoGetComponent<SpriteRenderer>(); } }

	// Use this for initialization
	void Start()
	{
		sp.color = Color.green;
		transform.position = main.subComponentsPos[1];
	}

	// Update is called once per frame
	void Update()
	{

	}
}
