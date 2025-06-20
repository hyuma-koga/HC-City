using UnityEngine;

public class PlayerCounter : MonoBehaviour
{
    [SerializeField] private int playerToBreak = 5;

    public int GetPlayerToBreak() => playerToBreak;

    private int currentStuckPlayer = 0;
    private TargetBreaker breaker;

    private void Awake()
    {
        breaker = GetComponent<TargetBreaker>();
    }

    public void AddPlayer()
    {
        currentStuckPlayer++;
        Debug.Log($"刺さり本数：{currentStuckPlayer}/{playerToBreak}");

        if (currentStuckPlayer >= playerToBreak)
        {
            breaker?.TriggerBreak();
        }
    }
}