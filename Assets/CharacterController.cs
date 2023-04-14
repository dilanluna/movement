using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	public LayerMask ground;
	public float speed = 1f;
	public float jumpForce = 1f;
	public GameObject groundCheck;
	private Rigidbody2D body;
	private bool isFacingRight = true;

	private void Start() {
		body = this.GetComponent<Rigidbody2D>();
	}

	public void Move(Vector2 movement, bool canJump) {
		if (isFacingRight && movement.x < 0 || !isFacingRight && movement.x > 0) {
			Flip();
		}

		if (canJump && IsGrounded()) {
			Jump();
		}

		Vector2 force = movement * speed;
		body.AddForce(force, ForceMode2D.Impulse);
		// body.velocity = new Vector2(body.velocity.x + movement.x * speed, body.velocity.y);
	}

	public void Jump() {
		Debug.Log(body.velocity);
		// if (body.velocity.y < 0) {
		// 	Debug.Log(body.velocity);
		// }
		Vector2 force = Vector2.up * jumpForce;
		body.AddForce(force, ForceMode2D.Impulse);

		// if (IsGrounded()) {

			// float force = jumpForce;
			// if (body.velocity.y < 0) {
			// 	force -= body.velocity.y;
			// }
			// body.AddForce(Vector2.up * force, ForceMode2D.Impulse);
		// }
	}

	public bool IsGrounded() {
		Collider2D collider = Physics2D.OverlapCircle(groundCheck.transform.position, .2f, ground);
		return collider != null;
	}

	private void Flip() {
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;

		isFacingRight = !isFacingRight;
	}
}
