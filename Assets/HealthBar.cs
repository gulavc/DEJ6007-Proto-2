using UnityEngine;
using System.Collections;


//Shamelessly stolen from https://answers.unity.com/questions/11892/how-would-you-make-an-energy-bar-loading-progress.html
public class HealthBar : MonoBehaviour
{
    public float barDisplay; //current progress
    public Vector2 posOffset = new Vector2(20, 40);
    public Vector2 pos = new Vector2(0, 0);
    public Vector2 size = new Vector2(60, 20);
    public Texture2D emptyTex;
    public Texture2D fullTex;

    void OnGUI()
    {
        //draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.DrawTexture(new Rect(0, 0, size.x, size.y), emptyTex, ScaleMode.StretchToFill);

        //draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.DrawTexture(new Rect(0, 0, size.x, size.y), fullTex, ScaleMode.StretchToFill);
        GUI.EndGroup();
        GUI.EndGroup();
    }
    
}