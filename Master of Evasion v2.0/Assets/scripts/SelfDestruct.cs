using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {//время жизни взрыва

    public float lifetime;
	
	void Start () {
        Destroy(gameObject, lifetime);
	}
}
