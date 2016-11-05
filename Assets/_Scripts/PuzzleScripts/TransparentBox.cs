using UnityEngine;
using System.Collections;

public class TransparentBox : MonoBehaviour {

    public int                  frameCounter = 0;

    public Renderer             rendererReference;

    public byte                 current_alpha;
    public bool                 increasing = true;

    private int                 animationSpeed = 150;

    void Start() {
        rendererReference = this.GetComponent<Renderer>();
    }

    void FixedUpdate() {
        frameCounter++;
        if (increasing) {
            if (frameCounter >= animationSpeed) {
                increasing = false;
                frameCounter = 0;
            }
            Color32 oldColor = rendererReference.material.color;
            current_alpha = (byte)(oldColor.a + 1);
            rendererReference.material.color = new Color32(oldColor.r, oldColor.g, oldColor.b, current_alpha);
        }
        else {
            if (frameCounter >= animationSpeed) {
                increasing = true;
                frameCounter = 0;
            }
            Color32 oldColor = rendererReference.material.color;
            current_alpha = (byte)(oldColor.a - 1);
            rendererReference.material.color = new Color32(oldColor.r, oldColor.g, oldColor.b, current_alpha);
        }
    }


    //void Update() {
    //    frameCounter++;
    //    if (increasing && frameCounter < animationSpeed) {
    //        Color32 oldColor = rendererReference.material.color;
    //        byte alpha = oldColor.a + 1;
    //        rendererReference.material.color = new Color32(oldColor.r, oldColor.g, oldColor.b, alpha);
    //        if (alpha >= alpha_max) {
    //            increasing = false;
    //        }
    //    }
    //    //float currTime = Time.time % animationCycleTime;
    //    //u = currTime / animationCycleTime;                            // Used for linear interpolation
    //    //if (increasing) {
    //    //    current_alpha = (byte)Mathf.Lerp(alpha_min, alpha_max, u);
    //    //    Color32 oldColor = rendererReference.material.color;
    //    //    rendererReference.material.color = new Color32(oldColor.r, oldColor.g, oldColor.b, current_alpha);
    //    //    if (u > 0.98) {
    //    //        increasing = false;
    //    //    }
    //    //}
    //    //else {
    //    //    current_alpha = (byte)Mathf.Lerp(alpha_max, alpha_min, u);
    //    //    Color oldColor = rendererReference.material.color;
    //    //    rendererReference.material.color = new Color(oldColor.r, oldColor.g, oldColor.b, current_alpha);
    //    //    if (u > 0.98) {
    //    //        increasing = true;
    //    //    }
    //    //}
    //}


}
