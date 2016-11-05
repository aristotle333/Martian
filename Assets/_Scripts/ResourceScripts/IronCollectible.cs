using UnityEngine;
using System.Collections;

public class IronCollectible : Collectible {

	public IronCollectible() : base(CollectiblesType.IRON, 1, 20.0f) {}
		
	void Start() {
		this.quantity = Random.Range (10, 31);
	}

}
