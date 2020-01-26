using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class Resortera : MonoBehaviour {

    public Transform _pivot;
    public float _springRange;
    public float _maxVel;

    public GameObject _flecha;
    public Transform _player;

    public Rigidbody2D _rb;

    Vector3 initPos = new Vector3(0, 2, 1.1f);
    Vector3 endPos = new Vector3(0, 0, 1.1f);

    public bool canDrag = true;

    // Use this for initialization
    void Start ()
    {
        _rb.GetComponent<Rigidbody2D>();
        _rb.bodyType = RigidbodyType2D.Kinematic;
	}
    private void Update()
    {
        if (!canDrag)
        {
            _flecha.transform.localPosition = Vector3.Lerp(transform.localPosition, endPos, Time.deltaTime);
        }
        FlechaFace();
    }
    void OnMouseDrag()
    {
        if (!canDrag)
            return;
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var dis = pos - _pivot.position;
        dis.z = 0;
        if (dis.magnitude > _springRange)
        {
            dis = dis.normalized * _springRange;
        }
        _flecha.transform.localPosition = initPos + dis + _pivot.position;
    }
    void OnMouseUp()
    {
        if (!canDrag)
            return;
        canDrag = false;
    }
    void FlechaFace()
    {
        if (!canDrag)
            return;
        Vector2 direccion = new Vector2(
            _player.transform.position.x - _flecha.transform.position.x,
            _player.transform.position.y - _flecha.transform.position.y);
        _flecha.transform.up = direccion;
    }
}
