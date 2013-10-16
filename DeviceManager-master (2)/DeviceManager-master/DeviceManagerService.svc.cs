//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System.Data.Common.CommandTrees;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace DeviceManagerService
{
    public class DeviceManagerService : DataService<DeviceDatabaseClassesDataContext>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            config.SetEntitySetAccessRule("*", EntitySetRights.All);
            config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
        }

        DeviceDatabaseClassesDataContext db = new DeviceDatabaseClassesDataContext();
        
        [WebGet(UriTemplate = "?name='{name}'")]
        public IQueryable<Device> GetDevicesByName(string name)
        {
            IQueryable<Device> x =
                from d in db.Devices
                where d.Name.Contains(name)
                select d;
            //var query = from cust in db.
            return x.AsQueryable();
        }

        [WebGet(UriTemplate = "?id={id}")]
        public IQueryable<Device> GetDevicesById(int id)
        {
            var x = from d in db.Devices
                    where d.ID.Equals(id)
                    select d;
            return x.AsQueryable();
        }

        public IQueryable<Device> GetDevicesByParent(int pid)
        {
            var nodes = from n in db.Nodes
                    where n.ParentID == pid
                    select n.Device;
            return nodes.AsQueryable();
        }
    }
}
