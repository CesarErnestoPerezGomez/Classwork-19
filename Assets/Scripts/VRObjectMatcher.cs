using UnityEngine;
using TMPro;

public class VRObjectMatcher : MonoBehaviour {
    public enum PropShape { Cube, Sphere, Cylinder }
    public enum PropColor { Red, Green, Blue }
    public enum PropSize { Small, Medium, Large }

    [Header("Active Player Object")]
    public MeshFilter activeMeshFilter;
    public MeshRenderer activeMeshRenderer;
    public Transform activeTransform;

    [Header("Target Solution")]
    public PropShape targetShape;
    public PropColor targetColor;
    public PropSize targetSize;
    public Vector3 targetRotation;

    [Header("Assets & Settings")]
    public Mesh cubeMesh;
    public Mesh sphereMesh;
    public Mesh cylinderMesh;
    public Material baseMaterial; // Assign a standard material here
    public TextMeshProUGUI feedbackText;

    // Current States
    private PropShape currentShape = PropShape.Cube;
    private PropColor currentColor = PropColor.Red;
    private PropSize currentSize = PropSize.Medium;

    void Start() {
        ResetObject(); // Ensure the object starts clean
    }

    // --- SHAPE CONTROLS ---
    public void SetShapeCube() { currentShape = PropShape.Cube; activeMeshFilter.mesh = cubeMesh; }
    public void SetShapeSphere() { currentShape = PropShape.Sphere; activeMeshFilter.mesh = sphereMesh; }
    public void SetShapeCylinder() { currentShape = PropShape.Cylinder; activeMeshFilter.mesh = cylinderMesh; }

    // --- COLOR CONTROLS ---
    public void SetColorRed() { currentColor = PropColor.Red; activeMeshRenderer.material.color = Color.red; }
    public void SetColorGreen() { currentColor = PropColor.Green; activeMeshRenderer.material.color = Color.green; }
    public void SetColorBlue() { currentColor = PropColor.Blue; activeMeshRenderer.material.color = Color.blue; }

    // --- SIZE CONTROLS ---
    public void SetSizeSmall() { currentSize = PropSize.Small; activeTransform.localScale = Vector3.one * 0.5f; }
    public void SetSizeMedium() { currentSize = PropSize.Medium; activeTransform.localScale = Vector3.one; }
    public void SetSizeLarge() { currentSize = PropSize.Large; activeTransform.localScale = Vector3.one * 1.5f; }

    // --- ROTATION CONTROLS (45-degree increments) ---
    public void RotateX() => activeTransform.Rotate(45f, 0, 0, Space.World);
    public void RotateY() => activeTransform.Rotate(0, 45f, 0, Space.World);
    public void RotateZ() => activeTransform.Rotate(0, 0, 45f, Space.World);

    // --- RESET ACTION ---
    public void ResetObject() {
        SetShapeCube();
        SetColorRed();
        SetSizeMedium();
        activeTransform.rotation = Quaternion.identity;
        feedbackText.text = "Object reset to original state.";
        feedbackText.color = Color.white;
    }

    // --- VALIDATION ACTION ---
    public void ConfirmAnswer() {
        bool shapeMatch = (currentShape == targetShape);
        bool colorMatch = (currentColor == targetColor);
        bool sizeMatch = (currentSize == targetSize);

        // Calculate rotation difference with a lenient 15-degree tolerance
        float angleDifference = Quaternion.Angle(activeTransform.rotation, Quaternion.Euler(targetRotation));
        bool rotationMatch = angleDifference <= 15f;

        if (shapeMatch && colorMatch && sizeMatch && rotationMatch) {
            feedbackText.text = "Success! The object matches perfectly.";
            feedbackText.color = Color.green;
        } else {
            // Vague feedback as requested, indicating an error without revealing the exact missing property
            feedbackText.text = "Not quite right. Check your properties and try again!";
            feedbackText.color = new Color(1f, 0.64f, 0f); // Orange
        }
    }
}