using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "CreateNewSave", fileName = "Save")]
public class Save_SO : ScriptableObject
{
    public List<Job_SO> jobSave;
    public int Gold;
    public int CurrentRole;

}
