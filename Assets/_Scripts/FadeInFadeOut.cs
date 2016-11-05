using UnityEngine;
using System.Collections;

public class FadeInFadeOut : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.2f;

    public int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

    public static FadeInFadeOut S;

    void Awake() {
        S = this;
    }

    void OnGUI() {
        alpha += fadeDir * fadeSpeed * Time.time;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade(int direction) {
        fadeDir = direction;
        return (fadeSpeed);
    }

    void OnLevelWasLoaded() {
        BeginFade(-1);
    }
}