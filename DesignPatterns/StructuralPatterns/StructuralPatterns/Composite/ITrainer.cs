using System.Collections;
using System.Collections.Generic;

namespace Composite
{
    internal interface ITrainer : IPerson
    {
        void SetMark(IStudent student);

        void AddPerson(IPerson person);

    }
}