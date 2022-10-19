using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Filled", menuName = "Generation Type/Filled", order = 51)]
public class GenerationTypeFiled : GenerationType
{
    public override Block[,] Generate(GeneratedObject objectGenerated, Block[,] worldArray)
    {
        bool objectIsCorrectness = CheckCorrectness(objectGenerated.InitialDepth, objectGenerated.FinishDepth, worldArray.GetLength(1));
        
        if (objectIsCorrectness == true)
        {
            for (int y = objectGenerated.InitialDepth; y < objectGenerated.FinishDepth; y++)
            {
                for (int x = 0; x < worldArray.GetLength(0); x++)
                {
                    int random = Random.Range(0, 100);

                    if (random <= objectGenerated.density)
                    {
                        worldArray[x, y] = objectGenerated.Object;
                    }
                }
            }
        }
       
        return worldArray;
    }

    private bool CheckCorrectness(int initialDepth, int finishDepth, int worldHeight)
    {
        if (initialDepth >= 0 && finishDepth <= worldHeight)
        {
            return true;
        }

        return false;
    }
}
