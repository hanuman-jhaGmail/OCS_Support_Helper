using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_N_D_Project
{
    public enum SexType { Male, Female };
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Mail { get; set; }
        public SexType Sex { get; set; }

        public override string ToString()
        {
            return this.Name + ", " + this.Age + " years old";
        }
    }
}
