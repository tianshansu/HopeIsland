using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

    ///<summary>
    ///
    ///</summary>

public class FishingLineRenderer : MonoBehaviour
{
   
    private PlayerController player;
    
    [HideInInspector]
    public HookMovement hook;

    private LineRenderer lineRenderer;

    public int lineNum;

    public float lineWidth;
    public Color lineColor;

    [HideInInspector]
    //private int segments = 40; // Number of line segments in the circle



    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();

        // Initialize LineRenderer component
        lineRenderer = gameObject.GetComponent<LineRenderer>();
 

        lineRenderer.material = new Material(Shader.Find("Standard"));
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

    }

    void Update()
    {
        
        Vector3 direction1 = Quaternion.Euler(0, hook.angle, 0) * player.transform.forward;
        Vector3 direction2= Quaternion.Euler(0, -hook.angle, 0) * player.transform.forward;
        Vector3 startPt1 = new Vector3(player.transform.position.x, -1.5f, player.transform.position.z);

        // Calculate the end point of the line
        Vector3 endPoint1 = player.gameObject.transform.position + direction1 * (hook.radius);
        Vector3 endPt1 = new Vector3(endPoint1.x, -1.5f, endPoint1.z);

        Vector3 endPoint2 = player.gameObject.transform.position + direction2 * (hook.radius);
        Vector3 endPt2 = new Vector3(endPoint2.x, -1.5f, endPoint2.z);


        switch (lineNum)
        {
            case 0:
                {
                    lineRenderer.SetPosition(0, startPt1);//出发点
                    lineRenderer.SetPosition(1, endPt1);//结束点
                    break;
                }
            case 1:
                {
                    lineRenderer.SetPosition(0, startPt1);
                    lineRenderer.SetPosition(1, endPt2);
                    break;
                }
            //case 2:
            //    {
            //        //Vector3[] linePositions = new Vector3[segments + 1];

            //        //for (int i = 0; i <= segments; i++)
            //        //{
            //        //    float angle = Mathf.Lerp(-90f, 90f, i / (float)segments);
            //        //    float x = Mathf.Cos(Mathf.Deg2Rad * angle);
            //        //    float z = Mathf.Sin(Mathf.Deg2Rad * angle);

            //        //    linePositions[i] = Vector3.Lerp(endPt1, endPt2, 0.5f) + new Vector3(x, 0f, z) * Vector3.Distance(endPt1, endPt2) * 0.5f;
            //        //}

            //        Vector3[] linePositions = new Vector3[segments + 1];

            //        Vector3 direction = (startPt1 - endPt1).normalized;
            //        Quaternion rotation = Quaternion.LookRotation(direction);

            //        for (int i = 0; i <= segments; i++)
            //        {
            //            float angle = Mathf.Lerp(-120f, 60f, i / (float)segments);
            //            float x = Mathf.Cos(Mathf.Deg2Rad * angle);
            //            float z = Mathf.Sin(Mathf.Deg2Rad * angle);

            //            Vector3 offset = rotation * new Vector3(x, 0f, z);
            //            linePositions[i] = Vector3.Lerp(endPt2, endPt1, 0.5f) + offset * Vector3.Distance(endPt2, endPt1) * 0.5f;
            //        }

            //        lineRenderer.positionCount = segments + 1;
            //        lineRenderer.SetPositions(linePositions);
            //        break;
            //    }
        }


        

        
        
        
    }

   
}
