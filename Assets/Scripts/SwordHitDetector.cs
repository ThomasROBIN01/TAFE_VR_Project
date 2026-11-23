using UnityEngine;

public class SwordHitDetector : MonoBehaviour
{
    [SerializeField] private BoxCollider[] bladeSections;

    private Vector3[] previousPositions;
    private Quaternion[] previousRotations;

    [SerializeField] private LayerMask targetLayers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the previousPositions and previousRotations arrays with the same length as the bladeSections array:
        previousPositions = new Vector3[bladeSections.Length];
        previousRotations = new Quaternion[bladeSections.Length];

        // Get the initial position and orientation of the blade sections and store them in the previousPositions and previousRotations arrays:
        for (int i = 0; i < bladeSections.Length; i++)
        {
            previousPositions[i] = bladeSections[i].transform.position;
            previousRotations[i] = bladeSections[i].transform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check each Box Collider representing a section of the katana blade.
        for (int i = 0; i < bladeSections.Length; i++)
        {
            // Get the current world-space position and orientation of the blade section:
            Vector3 currentPosition = bladeSections[i].transform.position;

            Quaternion currentRotation = bladeSections[i].transform.rotation;

            // Calculate the movement vector between the previous and current frames.
            // Subtracting the previous position from the current position gives both the direction and the displacement of the blade section.
            Vector3 movementDirection = currentPosition - previousPositions[i];

            // Calculate how far the blade section has travelled, in world units.
            // This is the magnitude (Euclidean length) of the movement vector.
            float distance = movementDirection.magnitude;

            // Distance between the 2 vectors is calculated with the Euclidean distance:
            // float distance = Mathf.Sqrt (movementDirection.x * movementDirection.x 
            //                            + movementDirection.y * movementDirection.y
            //                            + movementDirection.z * movementDirection.z);
            // or:
            // float distance = Vector3.Distance(previousPosition, currentPosition);


            // Only perform a BoxCast if the blade section has moved sufficiently.
            if (distance > 0.0001f)
            {
                // Normalize the movement direction vector to get a unit vector (magnitude of 1) for the BoxCast below:
                Vector3 directionNormalised = movementDirection.normalized;

                // Calculate the dimensions of the box used by Physics.BoxCast().
                //
                // BoxCollider.size contains the box dimensions in local space.
                // Since one of our katanas has been significantly scaled down, these dimensions don't necessarily match its size in world space.
                Vector3 localBoxDimensions = bladeSections[i].size;

                // To account for this, we use transform.lossyScale, which gives the approximate world-space scale, including scaling inherited from parent GameObjects
                // (unlike localScale, which only represents the GameObject's own scaling):
                Vector3 bladeSectionWorldScale = bladeSections[i].transform.lossyScale;

                // Vector3.Scale() multiplies the corresponding components: (size.x * scale.x, size.y * scale.y, size.z * scale.z).
                // Dividing by 2 gives the half-extents required by Physics.BoxCast(), which expects half the box's width, height and depth.
                Vector3 halfBoxDimensions = Vector3.Scale(localBoxDimensions, bladeSectionWorldScale) / 2f;

                // Perform the BoxCast to detect any collisions along the path of the blade section's movement:
                // Sweep the box from its previous position towards its current position.
                // The BoxCast uses the section's previous orientation and checks whether any collider lies along its movement path.
                bool hasHitSomething = Physics.BoxCast(previousPositions[i],
                                                        halfBoxDimensions,
                                                        directionNormalised,
                                                        out RaycastHit hit,
                                                        previousRotations[i],
                                                        distance,
                                                        targetLayers,                       // Only check for collisions with objects in the specified target layers.
                                                        QueryTriggerInteraction.Collide);   //  ensures that trigger colliders,such as those on our targets, are included in the query.

                if (hasHitSomething)
                {
                    // Log the name of the object that was hit by the BoxCast:
                    Debug.Log("A katana hits: " + hit.collider.name);
                }
            }
            

            // Update the previous position and orientation of the blade section for the next frame:
            previousPositions[i] = currentPosition;
            previousRotations[i] = currentRotation;
        }
    }
}
