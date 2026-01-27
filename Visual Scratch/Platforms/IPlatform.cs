using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Visual_Scratch.Platforms
{
    public interface IPlatform
    {
        string Name { get; set; }
        string Description { get; set; }
        string Author { get; set; }

        void Build();

        

    }
}
