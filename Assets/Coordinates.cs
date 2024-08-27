using UnityEngine;

public class Coordinates : MonoBehaviour
{
    public Vector3 currentPlatform;

    // Method to get random coordinates on the edge of the platform
    public Vector3 GetRandomEdgeCoordinate()
    {
        int randomEdge = Random.Range(0, 4);

        Vector3 newPosition = currentPlatform;

        switch (randomEdge)
        {
            case 0: // Top edge
                newPosition.x += 9;
                break;
            case 1: // Bottom edge
                newPosition.x -= 9;
                break;
            case 2: // Left edge
                newPosition.z -= 9;
                break;
            case 3: // Right edge
                newPosition.z += 9;
                break;
        }

        return newPosition;
    }
}
