using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VH.Engine.Levels {

    public interface IMapGenerator {

        Map Generate(int width, int height);

        Position GenerateFeature(char feature);

    }
}
