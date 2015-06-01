using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)//метод уничтожающий объект соприкосновившийся с колайдером(зеленой линие на которой стоит галочка isTrigger)
    {
        Destroy(other.gameObject);
    }
}
