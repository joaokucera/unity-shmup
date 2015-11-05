using UnityEngine;
using System.Collections;

/// <summary>
/// A class to extend the transform component.
/// </summary>
public static class TransformExtensions
{
    /// <summary>
    /// Enforces the bounds.
    /// </summary>
    /// <param name="transform">Transform.</param>
    /// <param name="mainCamera">Main camera.</param>
    /// <param name="renderer">Renderer.</param>
    public static void EnforceBounds(this Transform transform, Camera mainCamera, Renderer renderer)
    {
        // Current positions.
        Vector2 currentPosition = transform.position;
        Vector2 currentCameraPosition = mainCamera.transform.position;
        Vector2 boundSize = renderer.bounds.size / 2;

        // Get X distances.
        float xDistance = mainCamera.aspect * mainCamera.orthographicSize;
        float xMax = currentCameraPosition.x + xDistance - boundSize.x;
        float xMin = currentCameraPosition.x - xDistance + boundSize.x;

        // Fix vertical bounds
        if (currentPosition.x < xMin || currentPosition.x > xMax)
        {
            currentPosition.x = Mathf.Clamp(currentPosition.x, xMin, xMax);
        }

        // Get Y distances.
        float yDistance = mainCamera.orthographicSize;
        float yMax = currentCameraPosition.y + yDistance - boundSize.y;
        float yMin = currentCameraPosition.y - yDistance + boundSize.y;

        // Fix vertical bounds
        if (currentPosition.y < yMin || currentPosition.y > yMax)
        {
            currentPosition.y = Mathf.Clamp(currentPosition.y, yMin, yMax);
        }

        // Set position.
        transform.position = currentPosition;
    }
}