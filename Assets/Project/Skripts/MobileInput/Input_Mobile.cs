using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InstantGamesBridge;

public class Input_Mobile : MonoBehaviour
{
	private Vector2 lookInputPrev = Vector2.zero;

	void Awake()
	{
		if (Bridge.device.type == InstantGamesBridge.Modules.Device.DeviceType.Desktop)
		{
			Destroy(gameObject);
			return;
		}
	}

	void OnEnable()
	{
		if (Muwer.rid)
		{
			Muwer.rid.rut = Vector2.zero;
			lookInputPrev = Muwer.rid.rut;
			//StartCoroutine(StopEnum());
		}

	}

	void Start()
	{
		Muwer.rid.rut = Vector2.zero;
		lookInputPrev = Muwer.rid.rut;
		StartCoroutine(StopEnum());
	}


	public void MovementInput(Vector2 temp)
	{
		if (Muwer.rid)
		{
			Muwer.rid.muve.z = temp.y;
			Muwer.rid.muve.x = temp.x;
		}
	}

	public void RotationInput(Vector2 temp)
	{
		Muwer.rid.rut = temp;
	}

	private IEnumerator StopEnum()
	{

		while (true)
		{
			//print("Muwer.regit.rotationInput = " + Muwer.regit.rotationInput);
			//print("\n\r" + "lookInputPrev = " + lookInputPrev);

			lookInputPrev = Muwer.rid.rut;
			yield return new WaitForSeconds(0.02f);
			if (lookInputPrev == Muwer.rid.rut)
			{
				lookInputPrev = Vector2.zero;
				Muwer.rid.rut = Vector2.zero;
			}




		}
	}
}
