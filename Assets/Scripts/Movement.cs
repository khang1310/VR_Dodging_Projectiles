using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Movement : MonoBehaviour {
    /* Elements */
    private Vector2 trackpad;
    private Vector3 velocity;
    private int collisionCount;
    private float trackpadRestriction = 0.4f;
    private CapsuleCollider bodyCollider;

    [SerializeField] private SteamVR_Input_Sources MovementHand;
    [SerializeField] private SteamVR_Action_Vector2 TrackpadAction;
    [SerializeField] private SteamVR_Action_Boolean JumpAction;
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float MovementSpeed = 2f;

    public GameObject AxisHand;

    [Header("Friction Materials")]
    public PhysicMaterial NoFrictionMaterial;
    public PhysicMaterial FrictionMaterial;

    /* Getters/Setters */
    public float JumpHeight { get => jumpHeight; set => jumpHeight = value; }
    public float MovementSpeed1 { get => MovementSpeed; set => MovementSpeed = value; }

    // Start is called before the first frame update
    void Start() {
        bodyCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update() {
        trackpad = TrackpadAction.GetAxis(MovementHand);

        velocity = Quaternion.AngleAxis(Angle(trackpad) + AxisHand.transform.localRotation.eulerAngles.y, Vector3.up) * Vector3.forward;

        Rigidbody rigidBody = GetComponent<Rigidbody>();

        // Check if the body is colliding with anything or not to apply friction.
        if (trackpad.magnitude > trackpadRestriction) {
            bodyCollider.material = NoFrictionMaterial;

            if (JumpAction.GetStateDown(MovementHand)) {
                float jumpSpeed = Mathf.Sqrt(2 * jumpHeight * 9.81f);
                rigidBody.AddForce(0, jumpSpeed, 0, ForceMode.VelocityChange);
            }

            rigidBody.AddForce(velocity.x * MovementSpeed - rigidBody.velocity.x, 0, velocity.z * MovementSpeed - rigidBody.velocity.z, ForceMode.VelocityChange);
        }

        // Give the collider friction if there's a collision.
        else if (collisionCount > 0) {
            bodyCollider.material = FrictionMaterial;
        }
    }

    public static float Angle(Vector2 p_vector2) {
        if (p_vector2.x < 0) {
            return 360 - (Mathf.Atan2(p_vector2.x, p_vector2.y) * Mathf.Rad2Deg * -1);
        }
        else {
            return Mathf.Atan2(p_vector2.x, p_vector2.y) * Mathf.Rad2Deg;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        collisionCount++;
    }
    private void OnCollisionExit(Collision collision) {
        collisionCount--;
    }
}
