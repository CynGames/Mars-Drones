using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matching_Phase_Spawner : Spawner
{
    //con que frencuencia se deben activar/instanciara objetos?
    protected float spawnFrequency = 0.25f;

    protected override IEnumerator SpawnObject()
    {
        //desactiva el flag
        isEmpty = false;

        while (QueueAssembler.QueuedElements.Count > 0 && !GameManager.isPaused)
        {
            string goName = QueueAssembler.QueuedElements.Peek().ToString().Replace("(UnityEngine.GameObject)", "").Trim();
            GameObject go = null;

            SpawnMechanism(goName, ref go);

            //espera
            yield return new WaitForSecondsRealtime(spawnFrequency);
        }

        //activa el flag
        isEmpty = true;
    }

    protected override void SpawnMechanism(string goName, ref GameObject go)
    {
        if (QueueAssembler.QueuedElements.Peek().scene.IsValid())
        {
            //Si el objeto existe en la escena, cachearlo. 
            go = QueueAssembler.QueuedElements.Dequeue();
        }
        else
        {
            //Sino instanciarlo y cachearlo
            go = Instantiate(QueueAssembler.QueuedElements.Dequeue());
            go.AddComponent<Matching_Phase_Element_Behaviour>();
        }

        //Si el objeto cacheardo no es nulo, moverlo a la posicion correcta.
        if (go)
        {
            go.name = goName;
            SpawnLocation.PositionElement(go);
        }
    }
}
