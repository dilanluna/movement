using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	public InputActionAsset actions;
	public CharacterController controller;
	private Vector2 movement;
	private Animator animator;
	private bool heldJumpButton;
	private InputActionMap controls;

	private void Awake() {
		controls = actions.FindActionMap("Gameplay");
		controls.FindAction("Jump").performed += context => OnJump(context);
	}

	private void Start()
	{
		animator = this.GetComponent<Animator>();
	}

	private void Update()
	{
		movement = controls.FindAction("Move").ReadValue<Vector2>();
		animator.SetFloat("Movement", Mathf.Abs(movement.x));
	}

	private void FixedUpdate() {
		controller.Move(movement, heldJumpButton);
	}

	private void OnJump(InputAction.CallbackContext context) {
		heldJumpButton = context.action.IsPressed();
	}

	private void OnEnable() {
		actions.Enable();
	}

	private void OnDisable() {
		actions.Disable();
	}
}
