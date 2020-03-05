using UnityEngine;

public class ConstructionController : MonoBehaviour
{
    public PlayerControls controls;

    public BuildingData[] buildings;
    private BuildingData selected;
    private int currentIndex;

    public float buildDistance;

    private GameObject preview;
    private Vector2 rightStickInput = Vector2.up;
    private bool showPreview = false;

    private Vector3 pos;
    private Quaternion rot;

    void Start()
    {
        currentIndex = 0;
        selected = buildings[currentIndex];

        controls = new PlayerControls();

        controls.Construction.Build.performed += ctx => showPreview = true;
        controls.Construction.Build.canceled += ctx => Construct();
        controls.Construction.CancelBuild.performed += ctx => Cancel();

        controls.Construction.RightStick.performed += ctx => rightStickInput = ctx.ReadValue<Vector2>();

        controls.Construction.SwapNext.performed += ctx => Swap(1);
        controls.Construction.SwapPrevious.performed += ctx => Swap(-1);
    }

    void Update()
    {
        if (showPreview)
            Preview();
    }

    private void OnEnable()
    {
        controls.Construction.Enable();
    }

    private void OnDisable()
    {
        controls.Construction.Disable();
    }

    void Swap(int direction)
    {
        selected = buildings[(currentIndex + direction) % buildings.Length];
    }

    private void Preview()
    {
        StartPreview();
        
        pos = new Vector3(rightStickInput.x, 0, rightStickInput.y).normalized * buildDistance + transform.position;
        rot = Quaternion.LookRotation((transform.position - pos).normalized, Vector3.up);
    }

    private void Construct()
    {
        if (preview == null)
            return;

        Instantiate(selected.prefab, pos, rot);

        EndPreview();
    }

    private void Cancel()
    {
        EndPreview();
    }

    private void StartPreview()
    {
        if (preview == null)
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
}