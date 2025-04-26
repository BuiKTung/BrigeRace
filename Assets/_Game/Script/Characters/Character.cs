using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : ColorObject
{
    [SerializeField] Animator animator;
    [SerializeField] private LayerMask groundLayer;[SerializeField] LayerMask stairLayer;
    [SerializeField] private PlayerBrick playerBrickPrefab;
    [SerializeField] private Transform holder;
    [SerializeField] private Transform eyes;
    private List<PlayerBrick> listPlayerBrick = new List<PlayerBrick> ();
    public int listBrickCount => listPlayerBrick.Count;
    public Stage stage;
    private string currentAnimName;
    protected bool isCanMove ;
    protected bool isWin = false;

    //private void Start()
    //{
    //    eyes.rotation = Quaternion.identity;
    //}
    public virtual void OnInit()
    {
        ChangeAnim("Idle");
        ChangeColor(colorType);
        isWin = false;
        eyes.rotation = Quaternion.identity;

    }
    public void ChangeAnim(string newAnim)
    {
        if(newAnim != currentAnimName)
        {
            animator.ResetTrigger(newAnim);
            currentAnimName = newAnim;
            animator.SetTrigger(currentAnimName);
        }
    }
    public bool CheckGround(Vector3 nextPoint)
    {
        RaycastHit hit;
        if (Physics.Raycast(nextPoint + Vector3.up * 0.5f, Vector3.down, out hit,5f, groundLayer))
        { 
            return true;
        }
        return false;  
    }
    public bool CanMove(Vector3 nextPoint)
    {
        isCanMove = true;
        RaycastHit hit;
        
        if (Physics.Raycast(nextPoint + Vector3.up * 0.5f, Vector3.down, out hit, 5f, stairLayer))
        {
            Stair stair = hit.collider.GetComponent<Stair>();
            if (stair.colorType != colorType && listPlayerBrick.Count > 0 && eyes.forward.z > 0)
            {  
                stair.SetAtiveRender();
                stair.ChangeColor(this.colorType);
                RemoveBrick();
                stage.NewBrick(this.colorType);
            }

            if (stair.colorType != colorType && listPlayerBrick.Count == 0 && eyes.forward.z > 0)
            {
                isCanMove = false;
            }
        }
        return isCanMove;
    }
    public virtual void AddBrick()
    {
        PlayerBrick playerBrick = Instantiate(playerBrickPrefab,holder) ;
        playerBrick.ChangeColor(colorType);
        playerBrick.transform.localPosition = Vector3.up * 0.2f * listPlayerBrick.Count;
        listPlayerBrick.Add(playerBrick);
    }
    public virtual void RemoveBrick()
    {
        if(listPlayerBrick.Count > 0 )
        {
            PlayerBrick playerBrick = listPlayerBrick[listPlayerBrick.Count - 1];
            listPlayerBrick.RemoveAt(listPlayerBrick.Count - 1);
            Destroy(playerBrick.gameObject);
        }
    }
    public virtual void ClearRemove()
    {
        for (int i = 0; i < listPlayerBrick.Count; i++)
        {
            Destroy(listPlayerBrick[i]);
        }

        listPlayerBrick.Clear();
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BrickGround"))
        {
            BrickGround brickGround = other.GetComponent<BrickGround>();
            if(colorType == brickGround.colorType)
            {
                brickGround.OnDespawn();
                AddBrick();
                Destroy(brickGround.gameObject);
                Debug.Log("vacham");
            }
        }
        if (other.CompareTag("EndPoint"))
        {
            isWin = true;
            ChangeAnim("Dance");
            transform.Rotate(0, 180, 0);
        }
    }

}
    