using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private GameObject taskPrefab;
    [SerializeField] private GameObject ghostTask;

    private List<Task> tasks;

    private void Awake()
    {
        tasks = new List<Task>(GetComponentsInChildren<Task>());
    }

    public void CreateNewTask()
    {
        int newTaskIndex = ghostTask.transform.GetSiblingIndex();
        
        GameObject newTask = Instantiate(taskPrefab, transform);
        newTask.transform.SetSiblingIndex(newTaskIndex);
        
        tasks.Add(newTask.GetComponent<Task>());
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        Debug.Log($"Paused the app? {pauseStatus}");
        
        if (pauseStatus)
        {
            var checkedTasks = FindCheckedTasks();

            foreach (var checkedTask in checkedTasks)
            {
                checkedTask.UncheckTask();
            }
        }
    }

    public void TriggerOnApplicationPause()
    {
        OnApplicationPause(true);
    }

    private static bool FindChecked(Task task)
    {
        if (task.GetComponentInChildren<Toggle>().isOn)
        {
            return true;
        }
        
        return false;
    }

    private List<Task> FindCheckedTasks()
    {
        return tasks.FindAll(FindChecked);
    }
}
