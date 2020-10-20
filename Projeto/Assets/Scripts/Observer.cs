using UnityEngine;

public abstract class Observer
{
    public abstract void Notify();
}

public class Subject : Observer
{

    public override void Notify()
    {
        GameObject[] allObjects = Object.FindObjectsOfType<GameObject>();
        foreach (GameObject o in allObjects)
        {
            Debug.Log(o.ToString());
            if (o.ToString() == "EnemyBulletGO(Clone) (UnityEngine.GameObject)")
            {
                Object.Destroy(o);              
            }
        }    
    }

    /*public void AddObserver(GameObject observer)
    {
        observers.Add(observer);
    }

    //Remove observer from the list
    public void RemoveObserver(GameObject observer)
    {
        observers.Remove(observer);
    }*/
}
