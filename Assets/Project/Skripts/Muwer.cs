using UnityEngine;
using System.Collections;

public class Muwer : MonoBehaviour {
    public Animator anim;
    public Vector2 rut;
	public Vector3 muve;
	public float sensitivity = 1.1f;
	public Transform cam;
	public float minimumY = -60F;
	public float maximumY = 60F;
	public float speed = 6.0F;
	public float gravity = 20.0F;

	private Vector3 moveDirection = Vector3.zero;
	float rotationY = 0F;
    public float spid { get; set; }
    public CharacterController controller { get; set; }
	public static Muwer rid {get; set;}

	void Awake(){
        spid = speed;
		if (rid == null) {
			rid = this;
		} else {
			Destroy (this);
		}
	}
	void OnDestroy(){
		rid = null;
	}

	void Start () {
		controller = GetComponent<CharacterController>();
	}

	void Update() {
        if (cam != null)
        {
            //Time.timeScale = 0.1f + controller.velocity.magnitude / spid;
            if (Time.timeScale > 0)
            {
                float rotationX = transform.localEulerAngles.y + rut.x * sensitivity;
                rotationY += rut.y * sensitivity;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
                cam.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
                transform.localEulerAngles = new Vector3(0, rotationX, 0);
            }
        }

        if (controller.isGrounded)
        {
            if (controller.velocity.magnitude > 0.1f)
            {
                anim.SetBool("Run", true);
                anim.SetFloat("Speed", controller.velocity.magnitude / speed);
            }
            else
            {
                anim.SetBool("Run", false);
                anim.SetFloat("Speed", 1);
            }
            moveDirection = muve;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

        }
        else
        {
            moveDirection.y -= gravity * Time.unscaledDeltaTime;
        }
        controller.Move(moveDirection * Time.unscaledDeltaTime);
    }
}
