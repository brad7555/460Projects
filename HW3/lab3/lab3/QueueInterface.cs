using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    public interface IQueueInterface<T>
    {
        T Push(T element);

        T Pop(); /*Add in QueueInterface exception*/

        T Peek(); /*Add in QueueInterface exception*/

        Boolean IsEmpty();  


    }
}
