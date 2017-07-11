/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES
 
        private TrackableBehaviour mTrackableBehaviour;

        #endregion // PRIVATE_MEMBER_VARIABLES

        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS

        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>

        public Canvas canvas;

        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            canvas.SendMessage("Tracked");
            //Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            //Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
            //Canvas[] canvasObjects = GetComponentsInChildren<Canvas>();

            // Enable Canvas:
           // foreach (Canvas canvas in canvasObjects)
            //{
                //canvas.enabled = true;
           //     canvas.SendMessage("Tracked");
           // }

            // Enable rendering:
            // foreach (Renderer component in rendererComponents)
            // {
            //   component.enabled = true;
            // }

            // Enable colliders:
            //  foreach (Collider component in colliderComponents)
            //{
            //    component.enabled = true;
            // }
        }


        private void OnTrackingLost()
        {
            canvas.SendMessage("NotTracked");
            //  Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            // Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
            //  Canvas[] canvasObjects = GetComponentsInChildren<Canvas>();

            // Disable Canvas:
            //  foreach (Canvas canvas in canvasObjects)
            //  {
            // canvas.enabled = false;
            //      canvas.SendMessage("NotTracked");
            //  }

            // Disable rendering:
            // foreach (Renderer component in rendererComponents)
            //  {
            //  component.enabled = false;
            //}

            // Disable colliders:
            //foreach (Collider component in colliderComponents)
            // {
            //    component.enabled = false;
        }

        #endregion // PRIVATE_METHODS
    }
}
