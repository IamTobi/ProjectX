using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {

    public GameObject Grid;

    private BoxCollider2D _collider;

    private void Awake()
    {
        
    }

    // Use this for initialization

    void Start ()
    {
        _collider = GetComponent<BoxCollider2D>();	
	}
    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update () {

        Grid.transform.Translate(Vector3.right);
	}
}
