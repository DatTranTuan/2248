using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    [SerializeField] private NumberSO numberSO;
    [SerializeField] private LineController lineController;
    [SerializeField] private Transform lineParent;

    private Block currentBlock;
    private Block preBlock;
    private LineController line;

    private int index;
    private int blockCount;

    private List<LineController> lineList = new List<LineController>();

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        if (hit.collider != null && Input.GetMouseButtonDown(0))
        {
            blockCount++;
            line = Instantiate(lineController, lineParent);
            lineList.Add(line);
            index = hit.collider.GetComponent<Block>().Number;
            //line.LineRenderer.enabled = true;
            preBlock = hit.collider.GetComponent<Block>();
            preBlock.IsDrag = true;
            line.LineRenderer.material.color = hit.collider.gameObject.GetComponent<Renderer>().material.color;
            line.LineRenderer.SetPosition(0, preBlock.transform.position);
        }

        if (Input.GetMouseButton(0) && blockCount > 0)
        {
            //lineRenderer.enabled = true;
            line.LineRenderer.SetPosition(1, mousePosition);

            if (hit.collider != null && Vector3.Distance(hit.transform.position, line.LineRenderer.GetPosition(0)) > 0.01)
            {
                currentBlock = hit.collider.GetComponent<Block>();
                
                if (Mathf.Abs(line.LineRenderer.GetPosition(0).x - hit.transform.position.x) < 1.9 && Mathf.Abs(line.LineRenderer.GetPosition(0).y - hit.transform.position.y) < 1.9
                    && currentBlock.IsDrag == false)
                {
                    if (preBlock.Number == hit.collider.GetComponent<Block>().Number)
                    {
                        blockCount++;
                        line.LineRenderer.SetPosition(1, currentBlock.transform.position);
                        line = Instantiate(lineController, lineParent);
                        lineList.Add(line);
                        line.LineRenderer.SetPosition(0, currentBlock.transform.position);
                        line.LineRenderer.material.color = hit.collider.gameObject.GetComponent<Renderer>().material.color;
                        currentBlock.IsDrag = true;
                        preBlock = currentBlock;
                    }
                    else
                    {
                        if (blockCount >= 2 && preBlock.Number + 1 == currentBlock.Number)
                        {
                            line.LineRenderer.SetPosition(1, currentBlock.transform.position);
                            line = Instantiate(lineController, lineParent);
                            line.LineRenderer.SetPosition(0, currentBlock.transform.position);
                            line.LineRenderer.material.color = hit.collider.gameObject.GetComponent<Renderer>().material.color;
                            currentBlock.IsDrag = true;
                            preBlock = currentBlock;
                        }
                    }

                }
                else
                {
                    if (Mathf.Abs(line.LineRenderer.GetPosition(0).x - hit.transform.position.x) < 1.9 && Mathf.Abs(line.LineRenderer.GetPosition(0).y - hit.transform.position.y) < 1.9 && hit == preBlock)
                    {
                        Destroy(lineList[lineList.Count - 1]);
                        Destroy(lineList[lineList.Count - 2]);
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            //line.LineRenderer.enabled = false;
            Debug.Log("insdie");

            //if (Mathf.Abs(lineRenderer.GetPosition(0).x - hit.transform.position.x) < 1.9 && Mathf.Abs(lineRenderer.GetPosition(0).y - hit.transform.position.y) < 1.9)
            //{
            //    if (hit.collider != null && Vector3.Distance(firstBlock.transform.position, hit.transform.position) > 0.1f)
            //    {
            //        index++;
            //        Destroy(firstBlock.gameObject);
            //        block.NumberText.text = numberSO.listNumber[index].number.ToString();
            //        block.GetComponent<SpriteRenderer>().material.color = numberSO.listNumber[index].color;
            //    }
            //}
        }


    }
}
