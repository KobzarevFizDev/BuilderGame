using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuilderGame.BuildSystem
{

    public class BuildGridsRepository
    {
        public BuildGrid[] Grids { private set; get; }
        public BuildGridsRepository(BuildGrid[] grids)
        {
            Grids = grids;
        }

        public BuildCell GetCellByCameraDirection(Ray ray)
        {
            for (int i = 0; i < Grids.Length; i++)
            {
                BuildCell cell = Grids[i].GetCellByCameraDirection(ray);
                if (cell != null)
                    return cell;
            }
            return null;
        }
    }
}
