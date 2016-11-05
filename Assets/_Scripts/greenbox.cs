using UnityEngine;
using System.Collections;

public class greenbox : Box {

    public float updateFrequency = 0.01f;
    public float scalingRateRatio = 0.01f;
    public float minScale = 0.1f;           // Must be a number between 0 and

    public bool decreasingSize = false;
    public bool increasingSize = false;

    private float currTimer = 0;
    private float lastTimeUpdate = 0;

    public Vector3 initialScale;
    public Vector3 scaleVector;

	public AudioSource audioSource;

	public AudioClip increasingSound;
	public AudioClip decreasingSound;

	bool increasingSoundPlayed;
	bool decreasingSoundPlayed;

    void Start() {
		audioSource = GetComponent<AudioSource> ();
		Debug.Assert (audioSource);
        initialScale = this.transform.localScale;
        scaleVector = scalingRateRatio * this.transform.localScale;
		increasingSoundPlayed = false;
		decreasingSoundPlayed = false;
    }

    void Update() {
        currTimer = Time.time;
        if (currTimer - lastTimeUpdate > updateFrequency) {
            lastTimeUpdate = currTimer;
            if (decreasingSize) {
                DecreaseSize();
            }
            else if (increasingSize) {
                IncreasingSize();
            }
        }
    }

	void OnTriggerEnter(Collider coll)
	{
		print (coll.gameObject.tag);
		print ("GreenBox got hit");
		if (coll.gameObject.tag == "PlayerProjectile") 
		{
            decreasingSize = true;
			//this.transform.localPosition = new Vector3 (-this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z);
            Destroy(coll.gameObject);
		}
	}

    void DecreaseSize() {

		if (!audioSource.isPlaying && !decreasingSoundPlayed) {
			audioSource.PlayOneShot (decreasingSound);
			decreasingSoundPlayed = true;
		}
        this.transform.localScale -= scaleVector;
        if (this.transform.localScale.magnitude * 80 < initialScale.magnitude) {
            Debug.Log("set increasingSize to true");
            decreasingSize = false;
            increasingSize = true;
            this.transform.localPosition = new Vector3(-this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z);
            Debug.Log("Switched sides");
			decreasingSoundPlayed = false;
        }
    }

    void IncreasingSize() {
		if (!audioSource.isPlaying && !increasingSoundPlayed) {	
			audioSource.PlayOneShot (increasingSound);
			increasingSoundPlayed = true;
		}
        this.transform.localScale += scaleVector;
        if (this.transform.localScale.magnitude > initialScale.magnitude) {
            decreasingSize = false;
            increasingSize = false;
            this.transform.localScale = initialScale;           // Set it back initial size to avoid small errors
			increasingSoundPlayed = false;
        }
    }
}
