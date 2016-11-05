using UnityEngine;
using System.Collections;

public class Entrance : MonoBehaviour {
	public static Entrance S;
	// Use this for initialization
	void Start () {
		S = this;
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Enter()
	{
		this.gameObject.SetActive (false);
	}
}
