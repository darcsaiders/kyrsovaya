using UnityEngine;
using System.Collections;

public class SetParticleSortingLayer : MonoBehaviour {//система частиц(взрывы и горение)

    public string sortingLayerName;

    public int sortingOrder;

    void Start()
    {
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = sortingLayerName;

        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = sortingOrder;
    }
}
