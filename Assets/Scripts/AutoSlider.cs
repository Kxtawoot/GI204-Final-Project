using UnityEngine;

public class AutoSlider : MonoBehaviour
{
    public float speed = 2f;

    private SliderJoint2D slider;
    private JointMotor2D motor;

    private float direction = 1f;

    void Start()
    {
        slider = GetComponent<SliderJoint2D>();
        motor = slider.motor;
        slider.useMotor = true;
    }

    void Update()
    {
        // ตรวจสอบว่าใช้ Limits หรือไม่
        if (slider.useLimits)
        {
            float pos = slider.jointTranslation;
            float lower = slider.limits.min;
            float upper = slider.limits.max;

            // ถ้าถึงขอบ → กลับทิศทาง
            if (pos <= lower + 0.1f || pos >= upper - 0.1f)
            {
                direction *= -1f;
            }
        }

        motor.motorSpeed = speed * direction;
        slider.motor = motor;
    }
}
