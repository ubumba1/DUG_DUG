using UnityEngine;

public class moveBackground : MonoBehaviour
{
    [SerializeField]
    float _speed;
    private Transform back_Transform;
    private float back_Size;
    private float back_pos;
    private bool IsMove = false;

    private float targetBackPos; 

    void Start()
    {
        back_Transform = GetComponent<Transform>();
        back_Size = GetComponent<SpriteRenderer>().bounds.size.y;
        targetBackPos = back_pos; 
    }

    void Update()
    {
        if(IsMove == true)
        {
            Move();
            IsMove = false;
        }
    }
    public void SetOneMove()
    {
        IsMove = true;
    }
    public void Move()
    {
        back_pos = Mathf.Lerp(back_pos, targetBackPos, _speed * Time.deltaTime); 
        back_pos = Mathf.Repeat(back_pos, back_Size);
        back_Transform.position = new Vector3(0, back_pos, 0);
    }

}
