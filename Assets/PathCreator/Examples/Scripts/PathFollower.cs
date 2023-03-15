using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 3;
        float distanceTravelled;

        [SerializeField] public AudioClip antagonist;
        [SerializeField] public AudioSource aS;

        float auxTimer = 6;

        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }

            if(GetComponent<Walk9>())
                GetComponent<Walk9>().Run();

        }

        void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);


                if(distanceTravelled >= 8 && distanceTravelled <= 12f)
                {
                    GetComponent<Walk9>().Jump();
                }
                else if (distanceTravelled >= 19 && distanceTravelled <= 24f)
                {
                    GetComponent<Walk9>().Jump();
                }
                else if (distanceTravelled >= 30 && distanceTravelled <= 38f)
                {
                    GetComponent<Walk9>().Jump();
                }
                else
                {
                    GetComponent<Walk9>().ResetJump();

                }
                //transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }

            if(auxTimer <= 0)
            {
                auxTimer = 6;
                aS.PlayOneShot(antagonist);
            }
            else
            {
                auxTimer -= Time.deltaTime;
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

        public void RestartRun()
        {
            distanceTravelled = 0;
        }
    }
}