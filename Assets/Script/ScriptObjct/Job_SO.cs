using UnityEngine;

[CreateAssetMenu(menuName = "CreateNewJob", fileName = "Job")]
public class Job_SO : ScriptableObject
{
    public int job;
    public string jobName;
    public int exprience;
    public int HPGrowth;
    public float SpeedGrowth;
    public int OriginHP;
    public float originSpeed;

}
