using UnityEngine;
using System.Collections;

public abstract class Button : MonoBehaviour {

    protected abstract void Activate(GameObject obj);
    
	void OnTriggerEnter2D(Collider2D other) {
        this.Activate(other.gameObject);
	}
}
