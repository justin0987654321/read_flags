using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(BoxCollider2D))]
public class dragSprite : MonoBehaviour
{
    public delegate void DragEndedDelagate(dragSprite draggableObjects);
    public DragEndedDelagate dragEndedCallBack;

    private Vector3 _dragOffset;
    private Camera _cam;
    public GameObject gameObject;
    private bool isDragged = false;
    private Vector3 MouseDragStartPosition;
    private Vector3 spriteStartPosition;

    //private RaycastHit2D raydata = Physics2D.Linecast(transform.position, 15);

    [SerializeField] private float _speed = 10;

    void Awake()
    {
        _cam = Camera.main;
    }

    void OnMouseDown()
    {

       
        MouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //  spriteStartPosition = transform.LocalPosition;
        spriteStartPosition = transform.position; 
       // _dragOffset = transform.position - GetMousePos();
	    
    }

    void OnMouseDrag()
    {
        if (isDragged ) {
            transform.position = spriteStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - MouseDragStartPosition);
        }
      
    }
    void OnMouseUp() {
        isDragged = false;
        dragEndedCallBack(this);
    }

        /* 
         void OnDrop() {
             GameObject child1 = gameObject.transform.GetChild(0).gameObject;
             Debug.Log("here");
         }
        */
        void Update()
        {
           if (Input.GetMouseButtonDown(0))
            {
                Physics2D.queriesHitTriggers = false;
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.name);
                   isDragged = true;
                }
            }
        }

    }
