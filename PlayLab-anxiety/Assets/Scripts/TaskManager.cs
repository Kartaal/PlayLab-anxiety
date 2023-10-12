using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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

            // Ensure number to uncheck doesn't exceed total checked count
            var maxUncheck = Math.Min(checkedTasks.Count, Random.Range(1, 3));
            Debug.Log($"Unchecking {maxUncheck}...");

            for (int i = 0; i < maxUncheck; i++)
            {
                int indexToUncheck = (int) (checkedTasks.Count * Random.value);
                var task = checkedTasks[indexToUncheck];
                task.UncheckTask();
                checkedTasks.Remove(task);
            }
        }
    }

    public void TriggerOnApplicationPause()
    {
        OnApplicationPause(true);
    }

    public void ToggleAllTasks()
    {
        foreach (var task in tasks)
        {
            task.toggleTaskCheck();
        }
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
