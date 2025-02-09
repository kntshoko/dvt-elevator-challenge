using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProgram.Models
{
    public class InputResultModel
    {
        public string message;
        public int value;
        public bool valid;
        public bool exit;

        public InputResultModel(string message, int value, bool valid, bool exit)
        {
            this.message = message;
            this.value = value;
            this.valid = valid;
            this.exit = exit;
        }
    }
}
