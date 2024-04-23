using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCollider : MonoBehaviour
{
    //public float Radius = 3.471885f;
    //public int NumPoints = 32;

    //EdgeCollider2D EdgeCollider;
    //float CurrentRadius = 0.0f;

    ///// <summary>
    ///// Start this instance.
    ///// </summary>
    //void Start()
    //{
    //    CreateCircle();
    //}

    ///// <summary>
    ///// Update this instance.
    ///// </summary>
    //void FixedUpdate()
    //{
    //    // If the radius or point count has changed, update the circle
    //    if (NumPoints != EdgeCollider.pointCount || CurrentRadius != Radius)
    //    {
    //        CreateCircle();
    //    }
    //}

    ///// <summary>
    ///// Creates the circle.
    ///// </summary>
    //void CreateCircle()
    //{
    //    Vector2[] edgePoints = new Vector2[NumPoints + 1];
    //    EdgeCollider = GetComponent<EdgeCollider2D>();

    //    for (int loop = 0; loop <= NumPoints; loop++)
    //    {
    //        float angle = (Mathf.PI * 2.0f / NumPoints) * loop;
    //        edgePoints[loop] = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
    //    }

    //    EdgeCollider.points = edgePoints;
    //    CurrentRadius = Radius;
    //}

    private void Awake()
    {
        PolygonCollider2D poly = GetComponent<PolygonCollider2D>();
        if(poly == null)
        {
            poly = gameObject.AddComponent<PolygonCollider2D>();
        }
        Vector2[] points = poly.points;
        EdgeCollider2D edge = gameObject.AddComponent<EdgeCollider2D>();
        edge.points = points;
        Destroy(poly);
    }
}
