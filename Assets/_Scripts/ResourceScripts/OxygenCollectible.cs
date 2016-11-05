using UnityEngine;
using System.Collections;

public class OxygenCollectible : Collectible {

	public OxygenCollectible() : base(CollectiblesType.OXYGEN, 1, 20.0f) {}

    // Set to true if you want to set the quantity on the inspector
    public bool isCustom = false;
		
	void Start() {
        if (!isCustom) {
            this.quantity = Random.Range(5, 11);
        }
    }
}
