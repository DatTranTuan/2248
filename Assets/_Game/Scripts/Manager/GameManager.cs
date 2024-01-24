using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Block block;
    public int maxNum;
    public int minNum;
    public NumberSO numberSO;
    [SerializeField] private LineController lineController;
    [SerializeField] private Transform lineParent;

    private Block currentBlock;
    private Block preBlock;
    private LineController line;
    private int index;
    private int blockCount;

    private List<LineController> lineList = new List<LineController>();
    private List<Block> listDeleteBlock = new List<Block>();

    private IState currentState;

    private void Start()
    {
        Init();
        ChangeState(new DrawState());
    }
    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }
    public void Init()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Block blockTmp = Instantiate(block);
                blockTmp.IsDrag = false;
                blockTmp.transform.position = new Vector2(i, j);
                int numberType = Random.Range(minNum, maxNum);
                blockTmp.NumberText.text = numberSO.listNumber[numberType].number.ToString();
                blockTmp.GetComponent<SpriteRenderer>().material.color = numberSO.listNumber[numberType].color;
                blockTmp.Number = numberType;
            }
        }
    }
    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
    public void DrawProces()
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
            listDeleteBlock.Add(preBlock);
            preBlock.IsDrag = true;
            line.LineRenderer.material.color = hit.collider.gameObject.GetComponent<Renderer>().material.color;
            line.LineRenderer.positionCount = 1;
            line.LineRenderer.SetPosition(0, preBlock.transform.position);
        }

        if (Input.GetMouseButton(0) && blockCount > 0)
        {
            //lineRenderer.enabled = true;

            line.LineRenderer.positionCount = 2;
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
                        line.LineRenderer.positionCount = 1;
                        line.LineRenderer.SetPosition(0, currentBlock.transform.position);
                        line.LineRenderer.material.color = hit.collider.gameObject.GetComponent<Renderer>().material.color;
                        currentBlock.IsDrag = true;
                        preBlock = currentBlock;
                        listDeleteBlock.Add(preBlock);
                    }
                    else
                    {
                        if (blockCount >= 2 && preBlock.Number + 1 == currentBlock.Number)
                        {
                            blockCount++;
                            line.LineRenderer.SetPosition(1, currentBlock.transform.position);
                            line = Instantiate(lineController, lineParent);
                            lineList.Add(line);
                            line.LineRenderer.positionCount = 1;
                            line.LineRenderer.SetPosition(0, currentBlock.transform.position);
                            line.LineRenderer.material.color = hit.collider.gameObject.GetComponent<Renderer>().material.color;
                            currentBlock.IsDrag = true;
                            preBlock = currentBlock;
                            listDeleteBlock.Add(preBlock);
                        }
                    }
                }
                else
                {
                    if (lineList.Count >= 2 && currentBlock.IsDrag == true && Mathf.Abs(line.LineRenderer.GetPosition(0).x - hit.transform.position.x) < 1.9
                        && Mathf.Abs(line.LineRenderer.GetPosition(0).y - hit.transform.position.y) < 1.9 && Vector3.Distance(hit.transform.position, lineList[lineList.Count - 2].LineRenderer.GetPosition(0)) < 0.1)
                    {
                        Debug.Log(11);
                        Destroy(lineList[lineList.Count - 1].gameObject);
                        Destroy(lineList[lineList.Count - 2].gameObject);
                        listDeleteBlock.RemoveAt(listDeleteBlock.Count - 1);
                        lineList.RemoveAt(lineList.Count - 1);
                        lineList.RemoveAt(lineList.Count - 1);
                        blockCount--;
                        line = Instantiate(lineController, lineParent);
                        lineList.Add(line);
                        line.LineRenderer.positionCount = 1;
                        line.LineRenderer.SetPosition(0, currentBlock.transform.position);
                        line.LineRenderer.material.color = hit.collider.gameObject.GetComponent<Renderer>().material.color;
                        preBlock.IsDrag = false;
                        preBlock = currentBlock;
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (blockCount > 0)
            {
                for (int i = lineList.Count - 1; i >= 0; i--)
                {
                    Destroy(lineList[i].gameObject);
                    lineList.RemoveAt(i);
                    if (i != blockCount - 1)
                    {
                        Destroy(listDeleteBlock[i].gameObject);
                        listDeleteBlock.RemoveAt(i);
                    }
                }
            }
            listDeleteBlock.Clear();
            lineList.Clear();

            if(blockCount> 0) ChangeState(new DropState());
            blockCount = 0;
        }
    }
}
