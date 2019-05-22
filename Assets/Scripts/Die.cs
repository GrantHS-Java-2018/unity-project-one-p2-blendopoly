using UnityEngine;

namespace Spaces {
 
    public class Die : MonoBehaviour
    {
        public int faceShowing = 1;
        public Vector3[] angles = new Vector3[6];
        public int[] yAngles;
        public float percent;
        public PlayerHandler handler;
        public bool rolling = false;
        public int turnFactor;
        private float resolutionX = 914;
        private float resolutionY = 374;
        private Vector3 position;

        void Start()
        {
            position = transform.localPosition;
            Debug.Log(position.x);
        }

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
            if (resolutionX != Screen.width || resolutionY != Screen.height)
            {
                updateAngles();
                updateScale();
                transform.localPosition = new Vector3(Screen.width * position.x / 918f, Screen.height * position.y / 374f,position.z);
                resolutionX = Screen.width;
                resolutionY = Screen.height;
            }
        }

        private void setRotation()
        {
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, angles[faceShowing - 1], percent);
            if (percent < 1)
            {
                percent += 0.05f;
            }
        }

        private void updateAngles()
        {
            for (int i = 0; i < angles.Length; ++i)
            {
                angles[i].y = yAngles[i] - Screen.width * turnFactor / 914f + (187f * turnFactor/-Screen.height + (turnFactor / 45) * 25);
            }
        }

        private void updateScale()
        {
            float x = Screen.width * 40f / 914f;
            float y = Screen.height * 40f / 374f;
            float length = (x + y) / 2f;
            transform.localScale = new Vector3(length,length,length);
        }
        
    }
}