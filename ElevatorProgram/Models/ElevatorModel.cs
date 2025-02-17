using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProgram.Models
{
    class ElevatorModel
    {
        public int id;
        public int currentFloor;

        public string direction;
        public ElevatorModel(int id, int currentFloor)
        {
            this.id = id;
            this.currentFloor = currentFloor;
            this.direction = "up";
        }
    }
}
