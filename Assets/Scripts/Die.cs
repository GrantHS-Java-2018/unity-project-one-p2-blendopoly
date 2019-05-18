using UnityEngine;

namespace Spaces {
 
    public class Die : MonoBehaviour
    {
        public int faceShowing = 1;
        public Vector3[] angles = new Vector3[6];
        public float percent;
        public PlayerHandler handler;
        public bool rolling = false;

        public void roll(int value)
        {
            rolling = true;
            if (faceShowing == value)
            {
                transform.localEulerAngles = new Vector3(180,180,180) + angles[faceShowing - 1];
            }
            faceShowing = value;
            percent = 0;
        }

        void Update()
        {
            rolling = percent < 1;
            setRotation();
        }

        private void setRotation()
        {
            //transform.localEulerAngles = angles[faceShowing];
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, angles[faceShowing - 1], percent);
            if (percent < 1)
            {
                percent += 0.05f;
            }
        }
        
    }
}