using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TeacherController : MonoBehaviour
{
    [SerializeField] private GameObject teacherObj;

    public List<float> lookTimingList;

    private void CalculateLookTiming()
    {
        float divTime = GameManager.Instance.curStage.teacher.watchingTime + 3f + 4f;
    }

}
