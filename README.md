# VR Object Matching Interaction

## Implementation Details

This project is a Virtual Reality object-matching interaction developed in Unity (URP) and tested on the Meta Quest 2 via OpenXR. The primary objective is to allow users to interact with a floating UI to modify the properties of a 3D object until it matches a predefined target.

**Core Architecture & Setup:**
* **Environment:** Unity 2022+ with Universal Render Pipeline (URP) and OpenXR plugin.
* **Target Platform:** Android (Meta Quest 2), currently running and tested successfully in the Unity Editor via Quest Link (no final `.apk` deployment yet).
* **User Interface:** A World Space Canvas floats in the VR environment, utilizing a `TrackedDeviceGraphicRaycaster` to enable interaction via VR laser pointers.
* **Interaction Logic:** The `VRObjectMatcher.cs` script manages the state of the `ActiveObject`. Users can toggle its Shape (Cube, Sphere, Cylinder), Color (Red, Green, Blue), Size (Small, Medium, Large), and Rotation (45-degree increments across X, Y, Z axes). 
* **Validation:** The system compares the active object's enumerator states against the `TargetObject`. Rotation validation includes a 15-degree tolerance (via `Quaternion.Angle`) to prevent strict hardware-tracking frustrations. Feedback is provided dynamically via a text panel, changing color and messaging based on the success state.

---

## AI-Use Declaration

This project utilized AI assistance (Gemini) as a technical thought partner for C# script generation and UI architecture planning. The AI was used to accelerate boilerplate generation for the object-matching logic and provide instructions for wiring Unity UI components.

**Relevant Prompts Used (Adapted for Documentation):**

* **Interaction Logic & Scripting:** 
  > *"Create a VR interface and C# script that allows the user to modify an active object's shape (cube, sphere, cylinder), color (red, green, blue), size (small, medium, large), and rotation (X, Y, Z axes) until it matches a target object. Include validation logic that provides clear success feedback and vague error feedback without being excessively strict on rotation."*
* **UI Integration & Wiring:** 
  > *"I am starting from a blank VR template. How should I structure the UI for this, and how exactly do I map the script methods to each UI button?"*
