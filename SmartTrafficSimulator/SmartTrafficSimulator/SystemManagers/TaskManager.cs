using SmartTrafficSimulator.SystemObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartTrafficSimulator.SystemManagers
{
    class TaskManager
    {
        List<SimulationTask> newSimulationTaskList = new List<SimulationTask>();

        Queue<SimulationTask> simulationQueue = new Queue<SimulationTask>();
        Queue<SimulationTask> finishQueue = new Queue<SimulationTask>();

        SimulationTask currentTask = null;

        public void Initialize()
        {
            newSimulationTaskList.Clear();
            simulationQueue.Clear();
            finishQueue.Clear();
        }

        public List<SimulationTask> GetSimulationTaskList()
        {
            return newSimulationTaskList;
        }

        public Queue<SimulationTask> GetFinishQueue()
        {
            return finishQueue;
        }

        public SimulationTask GetCurrentTask()
        {
            return currentTask;
        }

        public void SetCurrentTask(SimulationTask simulationTask)
        {
            currentTask = simulationTask;
        }

        public Queue<SimulationTask> GetSimulationQueue()
        {
            return simulationQueue;
        }

        public void AddSimulationTask(SimulationTask newSimulationTask)
        {
            newSimulationTaskList.Add(newSimulationTask);
        }

        public void DeleteSimulationTask(int index)
        {
            newSimulationTaskList.RemoveAt(index);
        }

        public void ClearSimulationTaskList()
        {
            newSimulationTaskList.Clear();
        }

        public void TaskListToQueue()
        {
            foreach (SimulationTask st in newSimulationTaskList)
            {
                simulationQueue.Enqueue(st);
            }
            newSimulationTaskList.Clear();
        }

        public SimulationTask GetNextSimulationTask()
        {
            if (currentTask != null)
                finishQueue.Enqueue(currentTask);

            if (simulationQueue.Count > 0)
            {
                currentTask = simulationQueue.Dequeue();
                return currentTask;
            }
            else
            {
                //currentTask = null;
                Simulator.UI.AddMessage("System", "Simulation queue has no task");
                return null;
            }
        }

        public  void ClearSimulationTaskQueun()
        {
            simulationQueue.Clear();
        }

    }
}
