using UnityEngine;
using System.Collections;

public class BlackBox : Box {

	public GameObject otherBox;

	public AudioSource audioSource;

	bool soundPlayed;

	private float currTimer = 0;
	private float lastTimeUpdate = 0;

	public float updateFrequency = 0.01f;
	public float scalingRateRatio = 0.01f;
	public float minScale = 0.1f;

	public Vector3 initialScale;
	public Vector3 scaleVector;
	public bool disappearing;

	void Awake() {
		audioSource = GetComponent<AudioSource> ();
		soundPlayed = false;
		disappearing = false;
		initialScale = this.transform.localScale;
		scaleVector = scalingRateRatio * this.transform.localScale;
	}


	// Update is called once per frame
	void Update () {
		currTimer = Time.time;
		if (currTimer - lastTimeUpdate > updateFrequency) {
			lastTimeUpdate = currTimer;
			if (disappearing) {
				Disappear();
			}
		}
	}

	void OnTriggerEnter(Collider coll) {
		switch(coll.gameObject.tag) {
		case "PlayerProjectile":
			print ("playerproj");
			disappearing = true;
			break;
		case "Player":
			break;
		default:
			print (coll.gameObject.tag);
			break;
		}
	}

	void Disappear() {
		if (!audioSource.isPlaying && !soundPlayed) {
			audioSource.Play();
			soundPlayed = true;
		}

		this.transform.localScale -= scaleVector;

		if (this.transform.localScale.magnitude * 80 < initialScale.magnitude) {
			Destroy (this.gameObject);
			Destroy (otherBox);
		}
	}
}
