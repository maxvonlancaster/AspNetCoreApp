using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPlayground.Interview 
{
    // 1. Abstract class vs interface:
    // Ac provide flexibility, interface - no - have to implement all of it
    // You should use an interface if you want a contract on some behavior or functionality. You should 
    // not use an interface if you need to write the same code for the interface methods. In this case, 
    // you should use an abstract class, define the method once, and reuse it as needed. Do use interfaces 
    // to decouple your application’s code from specific implementations of it, or to restrict access to 
    // members of a certain type.
    public interface ISample
    {
        void Sample();
    }

    public abstract class AbsClass
    {
        public abstract void Sample();
        public void SampleTwo() { }
    }

    public class FirstClass : AbsClass
    {
        public override void Sample()
        {
            SampleTwo();
            throw new NotImplementedException();
        }
    }

    public class SecondClass : ISample
    {
        public void Sample()
        {
            throw new NotImplementedException();
        }
    }


    // 2. Difference between object and class:
    // A class is a comprehensive data type that is the primary building block, or template, of OOP. Class 
    // defines attributes and methods of objects, and contains an object’s behavior and data. An object, 
    // however, represents an instance of class. As a basic unit of a system, objects have identity and 
    // behavior as well as attributes.


    // 3. MSMQ
    // Microsoft Message Queuing, or MSMQ, is technology for asynchronous messaging. Whenever there's need 
    // for two or more applications (processes) to send messages to each other without having to immediately 
    // know results, MSMQ can be used. MSMQ can communicate between remote machines, even over Internet. 
    // It's free and comes with Windows, but is not installed by default.


    // 4. .Net standart 
    // .NET Standard is a formal specification of .NET APIs that are intended to be available on all .NET 
    // implementations. The motivation behind .NET Standard is to establish greater uniformity in the .NET ecosystem.
    // The various .NET implementations target specific versions of .NET Standard. Each .NET implementation version 
    // advertises the highest .NET Standard version it supports, a statement that means it also supports previous versions. 
    // For example, .NET Framework 4.6 implements .NET Standard 1.3, which means that it exposes all APIs defined in .NET 
    // Standard versions 1.0 through 1.3. Similarly, .NET Framework 4.6.1 implements .NET Standard 1.4, while .NET 
    // Core 1.0 implements .NET Standard 1.6.
    // 1.0 1.1 1.2 1.3 1.4 1.5 1.6 2.0 2.1(core 3)


    // 5. Difference between Task and Thread in .NET 
    // Thread represents an actual OS-level thread, with its own stack and kernel resources. Thread allows the 
    // highest degree of control; you can Abort() or Suspend() or Resume() a thread, you can observe its state, 
    // and you can set thread-level properties like the stack size, apartment state, or culture. ThreadPool is 
    // a wrapper around a pool of threads maintained by the CLR.
    public static class ThreadUsage 
    {
        public static void ThreadOne() 
        {
        
        }
    }

    // The Task class from the Task Parallel Library offers the best of both worlds.Like the ThreadPool, a task 
    // does not create its own OS thread.Instead, tasks are executed by a TaskScheduler; the default scheduler simply 
    // runs on the ThreadPool.Unlike the ThreadPool, Task also allows you to find out when it finishes, and (via 
    // the generic Task) to return a result.
    public static class TaskUsage 
    {
        public static void TaskOne() 
        {
        
        }
    }


    // 6. Azure WebJobs
    // WebJobs is a feature of Azure App Service that enables you to run a program or script in the same context as
    // a web app, API app, or mobile app. There is no additional cost to use WebJobs.
    // The Azure WebJobs SDK is a framework that simplifies the task of writing background processing code that runs 
    // in Azure WebJobs.It includes a declarative binding and trigger system that works with Azure Storage Blobs, 
    // Queues and Tables as well as Service Bus. You could also trigger Azure WebJob using Kudu API.




    public class Interview
    {

        // When passing by value (without ref) method does not get a variable, but its copy
        // when ref -> method gets address of the variable in memory
        public void PassByReferenceAndValue()
        {
            int a = 5;
            Increment(a); // i=6
            Console.WriteLine("a={0}", a); // a=5

            a = 5;
            IncrementReference(ref a); // i=6
            Console.WriteLine("a={0}", a); // a=6

            int z;
            Sum(10, 10, out z);
            Console.WriteLine("Sum={0}", z); // z=20
        }

        // value passed
        private void Increment(int i)
        {
            i++;
            Console.WriteLine("i={0}", i);
        }

        // reference passed
        private void IncrementReference(ref int i)
        {
            i++;
            Console.WriteLine("i={0}", i);
        }

        private void Sum(int x, int y, out int a)
        {
            a = x + y; // not allowed to leave unassigned if out - compiler error 
        }

        // pass by refernce, but you can not change content inside method
        private void IncrementInt(in int i)
        {
            // following will be compile error
            //i = 10;
        }
    }
}
