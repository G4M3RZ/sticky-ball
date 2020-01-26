using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulso : MonoBehaviour {

    public Resortera _touchGlobal;
    public GameObject _flecha;

    public Rigidbody2D _rb;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (!_touchGlobal.canDrag)
        {
            _rb.constraints = ~RigidbodyConstraints2D.FreezePosition;
            _rb.gravityScale = 1.3f;
            _rb.AddForce(-_flecha.transform.up * 500);
            _touchGlobal.canDrag = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            _rb.constraints = ~RigidbodyConstraints2D.FreezePositionX;
            _rb.gravityScale = 0;
        }
    }
}
