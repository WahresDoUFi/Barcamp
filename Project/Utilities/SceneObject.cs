using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcamp.Utilities
{
    internal abstract class SceneObject
    {
        public required Scene scene;
        public abstract void Start();
        public abstract void Update();
    }
}
