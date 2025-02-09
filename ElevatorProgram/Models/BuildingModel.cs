using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProgram.Models
{
    public class BuildingModel
    {

        public int id;
        public int currentFloor;
        public BuildingModel(int id, int currentFloor)
        {
            this.id = id;
            this.currentFloor = currentFloor;
        }

    }
}
