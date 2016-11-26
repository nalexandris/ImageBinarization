using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintTest01.Chaincode_processing
{
    class ContourElement
    {
        public ContourElement()
        {

        }

        /// <summary>
        /// For now these represent specific pixels
        /// </summary>
        public int X { get; set; }
        public int Y { get; set; }
        public float Angle { get; set; }
        public float Curvature { get; set; }
    }
}
