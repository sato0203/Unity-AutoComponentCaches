using UnityEngine;
using System.Collections;
using AutoComponentCathes;

public class AutoComponentCathesExampleMain : MonoBehaviour {

	public Vector3[] subComponentsPos;

	private AutoComponentCathesExampleSubComponent1 sub1 { get { return this.AutoFindObject<AutoComponentCathesExampleSubComponent1>();} }
	private AutoComponentCathesExampleSubComponent2 sub2 { get { return this.AutoFindObject<AutoComponentCathesExampleSubComponent2>();} }
	private AutoComponentCathesExampleSubComponent3 sub3 { get { return this.AutoFindObject<AutoComponentCathesExampleSubComponent3>();} }

	private SpriteRenderer[] spChildren { get { return this.AutoGetComponentsInChildren<SpriteRenderer>();} }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		foreach (var obj in spChildren)
		{
			obj.transform.position = new Vector3(Random.Range(-2f,2f),Random.Range(0,4f),0);
		}
	}
}
