using UnityEngine;
using System.Collections;


namespace Com.MyCompany.MyGame
{
    public class PlayerAnimatorManager : MonoBehaviour
    {
        #region Private Fields


        [SerializeField]
        private float directionDampTime = 1000f;


        #endregion




        #region MonoBehaviour Callbacks

        private Animator animator;
        // Use this for initialization
        void Start()
        {
            animator = GetComponent<Animator>();

            if (!animator)
            {
                Debug.LogError("Player Animator Mantager is missing animator component", this);
            }
        }


        // Update is called once per frame
        void Update()
        {
            if (!animator)
            {
                return;
            }

            // deal with Jumping
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            // only allow jumping if we are running.
            if (stateInfo.IsName("Base Layer.Run"))
            {
                // When using trigger parameter
                if (Input.GetButtonDown("Fire2"))
                {
                    animator.SetTrigger("Jump");
                }
            }


            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            if (v < 0)
            {
                v = 0;
            }
            animator.SetFloat("Speed", h * h + v * v);
            animator.SetFloat("Direction", 10 * h, directionDampTime, Time.deltaTime);

        }
    }


    #endregion
}
