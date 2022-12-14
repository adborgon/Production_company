using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Config
{
    // Thread Safe Singleton from https://csharpindepth.com/articles/singleton
    public sealed class CompanyConfiguration
    {
        #region SingletonConfiguration

        private static CompanyConfiguration instance = null;
        private static readonly object padlock = new object();

        public static CompanyConfiguration Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CompanyConfiguration();
                    }
                    return instance;
                }
            }
        }

        #endregion SingletonConfiguration

        #region Company Configuration Varibles

        //Company

        public int VendingMachineQuantiy = 2;
        public int TableQuantiy = 1;
        public int WorkbenchQuantiy = 1;

        //Vending Machine Config

        public int VendingMachineWaitingTime = 5;
        public int VendingMachineMaxWorkers = 3;

        //Worker

        public int WorkerTableWaiting = 10;
        public int WorkerWorkbenchWaiting = 4;
        public int WorkerAngryWaiting = 2;

        #endregion Company Configuration Varibles
    }
}