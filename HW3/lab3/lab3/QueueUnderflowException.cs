using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
 

namespace lab3
{
    public class QueueUnderflowException : Exception
    
    {
        private static readonly long serialVersionUID = 1L;

        public QueueUnderflowException() : base() 
        {
            
        }


        public QueueUnderflowException(string message) : base(message)
        {


        }
    }
}
