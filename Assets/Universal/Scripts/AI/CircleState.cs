using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleState : State
{
    public Transform targetObject;
    public Transform rootParent;
    public Color gizmoColor = Color.green;
    public float radius = 5.0f;
    public int segments = 32;
    public float moveSpeed = 2.0f;

    private float currentAngle = 0.0f;
    private Vector3 targetPosition;






    private void Awake()
    {
        targetObject = GameObject.FindGameObjectWithTag("Player").transform;

        rootParent = transform.root;

        
    }

    private void Start()
    {
        if (targetObject == null || rootParent == null)
            return;

        // Initialize the target position to the starting position
        targetPosition = CalculatePositionOnCircle(currentAngle);
    }


    public override State RunCurrentState()
    {



        // Calculate the next position along the circle
        currentAngle += moveSpeed * Time.deltaTime;
        if (currentAngle >= 360.0f)
            currentAngle -= 360.0f;

        Vector3 nextPosition = CalculatePositionOnCircle(currentAngle);

        // Smoothly move the root parent to the next position
        rootParent.transform.position = Vector3.Lerp(rootParent.transform.position, nextPosition, Time.deltaTime * moveSpeed);
        rootParent.transform.LookAt(targetObject);

        return this;
      
    }

    private Vector3 CalculatePositionOnCircle(float angle)
    {
        return targetObject.position + Quaternion.Euler(0, angle, 0) * (Vector3.forward * radius);
    }

    private void OnDrawGizmos()
    {
        if (targetObject == null || rootParent == null)
            return;

        Gizmos.color = gizmoColor;

        float angleIncrement = 360.0f / segments;
        Vector3 previousPoint = CalculatePositionOnCircle(0.0f);
        Vector3 firstPoint = previousPoint;

        for (int i = 1; i <= segments; i++)
        {
            float angle = i * angleIncrement;
            Vector3 point = CalculatePositionOnCircle(angle);

            Gizmos.DrawLine(previousPoint, point);

            previousPoint = point;
        }

        Gizmos.DrawLine(previousPoint, firstPoint);
    }




}
