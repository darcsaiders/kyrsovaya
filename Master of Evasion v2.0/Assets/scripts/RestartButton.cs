using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour {//рестарт

    public void RestartGame(){
        Application.LoadLevel(Application.loadedLevel);	
	}
}
