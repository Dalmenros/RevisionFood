using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
	public LayerMask m_DragLayers;

	[Range(0.0f, 100.0f)]
	public float m_Damping = 1.0f;

	[Range(0.0f, 100.0f)]
	public float m_Frequency = 5.0f;

	public bool m_DrawDragLine = true;
	public Color m_Color = Color.cyan;

	public TargetJoint2D m_TargetJoint;

	public GameObject lumiere;



	void Update()
	{
		// Calculate the world position for the mouse.
		var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


		if (Input.GetMouseButtonDown(0))
		{

			// Fetch the first collider.
			// NOTE: We could do this for multiple colliders.
			var collider = Physics2D.OverlapPoint(worldPos, m_DragLayers);
			if (!collider)
				return;

			// Fetch the collider body.
			var body = collider.attachedRigidbody;
			if (!body)
				return;

			if(collider.gameObject.layer == LayerMask.NameToLayer("Lumiere"))
            {
				Debug.Log("Fuck");
            }

			// Add a target joint to the Rigidbody2D GameObject.
			m_TargetJoint = body.gameObject.AddComponent<TargetJoint2D>();
			m_TargetJoint.dampingRatio = m_Damping;
			m_TargetJoint.frequency = m_Frequency;

			// Attach the anchor to the local-point where we clicked.
			m_TargetJoint.anchor = m_TargetJoint.transform.InverseTransformPoint(worldPos);
		}
		else if (Input.GetMouseButtonUp(0))
		{
			Destroy(m_TargetJoint);
			m_TargetJoint = null;
			return;
		}


		// Update the joint target.
		if (m_TargetJoint)
		{
			m_TargetJoint.target = worldPos;

			m_TargetJoint.breakForce = 250;

			// Draw the line between the target and the joint anchor.
			if (m_DrawDragLine)
				Debug.DrawLine(m_TargetJoint.transform.TransformPoint(m_TargetJoint.anchor), worldPos, m_Color);
		}
	}
	void OnMouseOver()
	{
		if (m_TargetJoint != null)
        {
			Destroy(m_TargetJoint);
		}
	}
}