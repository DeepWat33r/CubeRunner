using UnityEngine;

namespace Cubes
{
    public class CubeController : MonoBehaviour
    {
        public Collider interactionCollider;
    
        void Start()
        {
            interactionCollider.enabled = false;
        }

        void Update()
        {
            if(transform.parent != null && transform.parent.CompareTag("Player"))
            {
                interactionCollider.enabled = true;
            }
            else
            {
                interactionCollider.enabled = false;
            }
        }
    }
}
