using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;

    private Transform[] points;

    private Block block;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        if (hit.collider != null && Input.GetMouseButtonDown(0))
        {
            block = hit.collider.GetComponent<Block>();
            Debug.Log(hit.collider.gameObject.name);
            lineRenderer.SetPosition(0, block.transform.position);
            lineRenderer.material.color = hit.collider.gameObject.GetComponent<Renderer>().material.color;
        }
        if (Input.GetMouseButton(0))
        {
            lineRenderer.SetPosition(1, mousePosition);
            if(hit.collider!= null && Vector3.Distance( hit.transform.position,lineRenderer.GetPosition(0))>0.01)
            {
                Debug.Log(1);
                if (Mathf.Abs(lineRenderer.GetPosition(0).x - hit.transform.position.x) < 1.9 && Mathf.Abs(lineRenderer.GetPosition(0).y - hit.transform.position.y) < 1.9
                    && block.Number== hit.collider.GetComponent<Block>().Number) 
                { 
                    block = hit.collider.GetComponent<Block>();
                    lineRenderer.SetPosition(1, block.transform.position);                
                }
            }
        }
    }
}
