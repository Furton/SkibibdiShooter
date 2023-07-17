using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour {

	private Muwer muwer;
	// Use this for initialization
	void Start () {
        muwer = Muwer.rid;
	}
	

	void Update () {
		muwer.muve = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
        muwer.rut = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Gun.rid.Shut();
        }
        if (Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown(KeyCode.Tab))
        {
            Interface.rid.Menu();
        }
    }
}
