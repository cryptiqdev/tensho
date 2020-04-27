using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Tensho.Data;

namespace Tensho
{
    [ServiceContract]
    public interface ITensho
    {
        [OperationContract]
        string Post(Encounter encounter);

		[OperationContract]
		string Get(string device);
	}
}
