using UnityEngine;
using UnityEngine.InputSystem;

public class ConstructionController : MonoBehaviour
{
    private InputActionAsset inputAsset;

    public BuildingData[] buildings;
    private BuildingData selected;
    public int currentIndex;

    public float buildDistance;

    private GameObject preview;
    private Vector2 rightStickInput = Vector2.up;
    public bool showPreview = false;

    private Vector3 pos;
    private Quaternion rot;

    private void Awake()
    {
        currentIndex = 0;
        selected = buildings[currentIndex];

        inputAsset = GetComponent<PlayerInput>().actions;
        inputAsset.Enable();
    }

    void OnBuild()
    {
        Construct();
    }
    void OnPreview(InputValue value)
    {
        showPreview = value.isPressed;

        if (!showPreview)
            Cancel();
    }

    void OnRightStick(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        if (input != Vector2.zero)
        rightStickInput = input;
    }

    void OnSwapNext() => Swap(1);
    void OnSwapPrevious() => Swap(-1);



    private void Update()
    {
        if (showPreview)
            Preview();
    }

    void Swap(int direction)
    {
        currentIndex = (currentIndex + direction) % buildings.Length;
        selected = buildings[currentIndex];
    }

    private void Preview()
    {
        StartPreview();
        
        pos = new Vector3(rightStickInput.x, 0, rightStickInput.y).normalized * buildDistance + transform.position;
        rot = Quaternion.LookRotation((transform.position - pos).normalized, Vector3.up);
    }

    private void Construct()
    {
        if (preview != null)
            Instantiate(selected.prefab, pos, rot);
    }

    private void Cancel()
    {
        EndPreview();
    }

    private void StartPreview()
    {
        if (preview == null && selected != null)
            preview = Instantiate(selected.prefab, Vector3.zero, Quaternion.identity);
    }

    private void EndPreview()
    {
        if (preview != null)
        {
            Destroy(preview);
            preview = null;
        }

        showPreview = false;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (showPreview)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawCube(pos, Vector3.one);
        }
    }
#endif
}