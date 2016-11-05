using UnityEngine;
using System.Collections;

public class HealthCollectible : Collectible {

	public HealthCollectible() : base(CollectiblesType.HEALTH, 1, 20.0f) {}

	void Start() {
		this.quantity = Random.Range (5, 11);
	}
}
