using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
    public Texture2D element;
    public Sprite heart;
    public Texture2D emptyHeart;
    
    
    void OnGUI () {
        // Fixed Layout
        //GUI.Button (new Rect (25,25,100,30), "I am a Fixed Layout Button");
        GUI.Box(new Rect (20,20,100,100),"Hello world");
    
        // Automatic Layout
        //GUILayout.Button ("I am an Automatic Layout Button");
    }

}
