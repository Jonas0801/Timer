using UnityEngine;

public delegate void TestEvent();

public class Timer : MonoBehaviour
{
    [Tooltip("Frames per second")]
    public float frameRate = 12;
    private float nextFrameTime = 0;

    public static TestEvent @event;

    private void Start()
    {
        @event = Demo;
    }

    // Update is called once per frame
    void Update()
    {
        TimerUpdate();
    }

    private void TimerUpdate()
    {
        if (Time.time - nextFrameTime > (1f / frameRate))
        {
            @event?.Invoke();
            //calculate the time of the next frame.
            nextFrameTime += 1f / frameRate;
        }
    }

    public void Demo()
    {
        Debug.Log("Hello world");
    }

    private void OnDisable()
    {
        @event = null;
    }

    private void OnDestroy()
    {
        @event = null;
    }
}
