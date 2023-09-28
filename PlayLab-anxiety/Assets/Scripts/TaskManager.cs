using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private GameObject taskPrefab;
    [SerializeField] private GameObject ghostTask;

    public void CreateNewTask()
    {
        int newTaskIndex = ghostTask.transform.GetSiblingIndex();
        
        GameObject newTask = Instantiate(taskPrefab, transform);
        newTask.transform.SetSiblingIndex(newTaskIndex);
    }
}
