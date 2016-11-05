using UnityEngine;
using System.Collections.Generic;
public class EnemyHealth : MonoBehaviour
{
	public int startingHealth = 100;
	public int currentHealth;
	public float sinkSpeed = 2.5f;
	public int scoreValue = 10;
	public AudioClip deathClip;
	public float drop_prob;
	public List<GameObject> item_drop;
	Animator anim;
	AudioSource enemyAudio;
	ParticleSystem hitParticles;
	CapsuleCollider capsuleCollider;
	bool isDead;
	bool isSinking;


	void Awake ()
	{
		anim = GetComponent <Animator> ();
		enemyAudio = GetComponent <AudioSource> ();
		hitParticles = GetComponentInChildren <ParticleSystem> ();
		capsuleCollider = GetComponent <CapsuleCollider> ();
		currentHealth = startingHealth;
	}

	void Start()
	{
		drop_prob = .9f;
	}
	void Update ()
	{
		if(isSinking)
		{
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.tag == "PlayerProjectile")
			this.TakeDamage ((int)coll.gameObject.GetComponent<projectile>().dmg, coll.gameObject.transform.position);
	}
		
	public void TakeDamage (int amount, Vector3 hitPoint)
	{
		if(isDead)
			return;

		enemyAudio.Play ();

		currentHealth -= amount;

		hitParticles.transform.position = hitPoint;
		hitParticles.Play();

		if(currentHealth <= 0)
		{
			//randomDrop ();
			Death ();
		}
	}


	void Death ()
	{
		isDead = true;

		capsuleCollider.isTrigger = true;

		anim.SetTrigger ("Dead");

		enemyAudio.clip = deathClip;
		enemyAudio.Play ();
	}


	public void StartSinking ()
	{
		GetComponent <NavMeshAgent> ().enabled = false;
		GetComponent <Rigidbody> ().isKinematic = true;
		isSinking = true;
		//ScoreManager.score += scoreValue;
		Destroy (gameObject, 2f);
	}

	public void randomDrop() {

			float rand_num = Random.value;
		if (rand_num < drop_prob && item_drop.Count >0) {
			float ind = Random.value;
			if (ind < 0.5)
				GameObject.Instantiate (item_drop [0], transform.position, Quaternion.identity);
			else if (ind >= 0.5 && ind < 0.9)
				GameObject.Instantiate (item_drop [1], transform.position, Quaternion.identity);
			else
				GameObject.Instantiate (item_drop [2], transform.position, Quaternion.identity);
		}
	}
}
