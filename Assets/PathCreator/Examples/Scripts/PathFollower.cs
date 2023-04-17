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
        [SerializeField] float distanceTravelled;

        [SerializeField] public AudioClip antagonist;
        [SerializeField] public AudioSource aS;

        float auxTimer = 6;

        public bool canGo;

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

                GetComponent<Animator>().ResetTrigger("Idle");
                GetComponent<Animator>().SetTrigger("Run");

                if (distanceTravelled >= 12.5f && distanceTravelled <= 14f)
                {
                    GetComponent<Animator>().SetTrigger("Jump");
                }
                else if (distanceTravelled >= 24 && distanceTravelled <= 26f)
                {
                    GetComponent<Animator>().SetTrigger("Jump");
                }
                else if (distanceTravelled >= 36.5 && distanceTravelled <= 38f)
                {
                    GetComponent<Animator>().SetTrigger("Jump");
                }
                else
                {
                    GetComponent<Animator>().ResetTrigger("Jump");
                }
            }
            else
            {
                GetComponent<Animator>().SetTrigger("Idle");

            }

            if (auxTimer <= 0)
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