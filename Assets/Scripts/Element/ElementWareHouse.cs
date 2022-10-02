using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Element
{
    public sealed class ElementWareHouse
    {
        #region SingletonConfiguration

        private static readonly Lazy<ElementWareHouse> lazy =
       new Lazy<ElementWareHouse>(() => new ElementWareHouse());

        public static ElementWareHouse Instance
        { get { return lazy.Value; } }

        #endregion SingletonConfiguration

        public Dictionary<Type, List<Element>> elementsOnWarehouse = new Dictionary<Type, List<Element>>();

        public void InitWarehouse()
        {
            elementsOnWarehouse.Add(typeof(Table), ElementSpawner.SpawnElements<Table>(Config.CompanyConfiguration.Instance.TableQuantiy));
            elementsOnWarehouse.Add(typeof(Workbech), ElementSpawner.SpawnElements<Workbech>(Config.CompanyConfiguration.Instance.WorkbenchQuantiy));
            elementsOnWarehouse.Add(typeof(VendingMachine), ElementSpawner.SpawnElements<VendingMachine>(Config.CompanyConfiguration.Instance.VendingMachineQuantiy));
        }

        public Element isAElemenReadyAndAssign<T>()
        {
            List<Element> list;
            if (elementsOnWarehouse.TryGetValue(typeof(T), out list))
            {
                foreach (var element in list)
                {
                    if (element.isRealised())
                    {
                        return element;
                    }
                }
            }
            return null; //All elements busy
        }
    }
}