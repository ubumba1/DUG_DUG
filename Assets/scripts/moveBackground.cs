using UnityEngine;

public class moveBackground : MonoBehaviour
{
    [SerializeField] private float speed = 6;
    private Transform backgroundTransform;
    private float backgroundSize;
    private float targetBackgroundPosition;
    private bool isMoving;

    void Start()
    {
        backgroundTransform = GetComponent<Transform>();
        backgroundSize = GetComponent<SpriteRenderer>().bounds.size.y - 4;
        targetBackgroundPosition = backgroundTransform.position.y;
        isMoving = false;
    }

    void Update()
    {
        if (isMoving)
        {
            Move();
        }
    }

    void Move()
    {
        float step = speed * Time.deltaTime;
        backgroundTransform.position = Vector3.MoveTowards(backgroundTransform.position, new Vector3(0, targetBackgroundPosition, 0), step);

        // Если фон стал невидимым для камеры, сбросим его позицию
        if (!IsVisibleFromCamera())
        {
            backgroundTransform.position = new Vector3(0, targetBackgroundPosition, 0);
            targetBackgroundPosition = Mathf.Repeat(targetBackgroundPosition, backgroundSize);
            isMoving = false;
        }
    }

    public void RaiseBackground(float amount)
    {
        targetBackgroundPosition += amount;
        isMoving = true;
    }

    // Проверка, видим ли объект относительно камеры
    private bool IsVisibleFromCamera()
    {
        if (backgroundTransform.GetComponent<Renderer>() == null)
        {
            // Если компонента Renderer отсутствует, считаем объект видимым
            return true;
        }

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        return GeometryUtility.TestPlanesAABB(planes, backgroundTransform.GetComponent<Renderer>().bounds);
    }
}