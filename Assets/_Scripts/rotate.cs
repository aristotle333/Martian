using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

    public void PlaySound() {
        this.GetComponent<AudioSource>().Play();
    }
}
