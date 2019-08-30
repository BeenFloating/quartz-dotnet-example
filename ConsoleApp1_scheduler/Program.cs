using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace ConsoleApp1_scheduler
{
    class Program
    {
        static void Main(string[] args)
        {


            // construct a scheduler factory
            ISchedulerFactory schedFact = new StdSchedulerFactory();






            // get a scheduler, start the schedular before triggers or anything else
            IScheduler sched = schedFact.GetScheduler();
            sched.Start();





            // create job
            IJobDetail job = JobBuilder.Create<SimpleJob>()
                    .WithIdentity("job0", "group0")
                    .Build();



            // Trigger the job to run now, and then repeat every 10 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger0", "group0")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();



            // create job
            IJobDetail job1 = JobBuilder.Create<SimpleJob1>()
                    .WithIdentity("job1", "group1")
                    .Build();



            // Trigger the job to run now, and then repeat every 10 seconds
            ITrigger trigger1 = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(7)
                    .RepeatForever())
                .Build();







            // Schedule the job using the job and trigger 
            sched.ScheduleJob(job, trigger);
            sched.ScheduleJob(job1, trigger1);



        }
    }

    /// &lt;summary&gt;
    /// SimpleJOb is just a class that implements IJOB interface. It implements just one method, Execute method
    /// &lt;/summary&gt;
   



    public class SimpleJob : Quartz.IJob
    {
        public int everyXMin { get; set; }
        public int everyXSec { get; set; }
        public int everyXHour { get; set; }

               

        void IJob.Execute(IJobExecutionContext context)
        {

         
            //throw new NotImplementedException();
            Console.WriteLine("Hello, JOb executed 5 sec");
        }
    }


    public class SimpleJob1 : IJob
    {
        public int everyXMin { get; set; }
        public int everyXSec { get; set; }
        public int everyXHour { get; set; }





        void IJob.Execute(IJobExecutionContext context)
        {


            //throw new NotImplementedException();
            Console.WriteLine("Hello, JOb executed 7 sec");
        }
    }











}
    

